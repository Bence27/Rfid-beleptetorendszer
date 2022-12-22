using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using AForge.Video;
using AForge.Video.DirectShow;



namespace ArduinoWPF
{

    public struct struct_adatok   // struktúra az adatoknak
    {
       public string nev;
       public string rfid;
    };


    public partial class Form1 : Form
    {

        SerialPort serialPort;

        

        static string connectionString = "SERVER=localhost;DATABASE=arduino;UID=root;PASSWORD=;";  //adatbázishoz csatlakozó string

        struct_adatok[] adatok = new struct_adatok[1]; //tömb az elemeknek

        string rfid = string.Empty;

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;



        public Form1()
        {
            InitializeComponent();
            serialPort = new SerialPort("COM3", 9600); //port beálítása
        }


        private void but_kilep_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private async void but_belep_Click(object sender, EventArgs e)
        {
            
            serialPort.ReadTimeout = 10000;  //timeout beálítása
            bool haveRFID = false;
            cbname.SelectedIndex = 1;
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbname.SelectedIndex].MonikerString); //kamera beálítása


            try                                                                   // port nyitása
            {
                serialPort.Open();
            }
            catch
            {
                Console.WriteLine("Nem lehet megnyitni a COM portot");
            }

            tb_log.Text += "Érintse a beléptetőhöz a kártyát"+Environment.NewLine;

            while(serialPort.IsOpen)
            {
                try                                 //Serial beolvasása
                {
                    rfid = serialPort.ReadLine();
                    rfid = rfid.Replace("\r", "");
                    if (!string.IsNullOrEmpty(rfid))   //ha beolvasás sikeres port zárása
                    {
                        haveRFID = true;
                        serialPort.Close();
                    }
                }
                catch (TimeoutException)             // időtullépés vizsgálat
                {
                    serialPort.Close();
                    MessageBox.Show("A beolvasási idő lejárt!", "Idő túllépés");
                }
            }

            if (haveRFID)
            {
                int index = -1;   // a keresett elem indexe ha van
                for (int i = 0; i < adatok.Length; i++)
                {
                    if(adatok[i].rfid==rfid)
                    {
                        index = i;
                    }
                }

                if (index != -1)    //ha van találat
                {
                    tb_log.Text += adatok[index].nev + " RFID:" + rfid + Environment.NewLine;  //szöveg kiirás a tb_log ba
                    try
                    {
                        serialPort.Open();
                        serialPort.WriteLine("G");   //parancs elküldése az arduinonak
                        serialPort.Close();

                    }
                    catch
                    {
                        Console.WriteLine("Nem lehet a portot megnyitni");
                    }
                }
                else  //ha nincs találat
                {
                    tb_log.Text += "Ismeretlen" + " RFID:" + rfid + Environment.NewLine;  //szöveg kiirás a tb_log ba

                    try
                    {
                        videoCaptureDevice.Start();
                        videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;  //kép készítése
                        serialPort.Open();
                        serialPort.WriteLine("R");  //parancs elküldése az arduinonak
                        serialPort.Close();
                    }
                    catch
                    {
                        Console.WriteLine("Nem lehet a portot megnyitni");
                    }

                    await Task.Delay(3000);
                    videoCaptureDevice.Stop();
                    MessageBox.Show("A rendszer képet készített önről!", "Illetéktelen belépés");
                }
            }
        }


        private void but_felvitel_Click(object sender, EventArgs e)
        {
            Felvitel ujablak = new Felvitel();
            ujablak.Owner = this;
            ujablak.ShowDialog();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);  //csatlakoztatott kamera betöltése
            foreach(FilterInfo filterInfo in filterInfoCollection)   
                cbname.Items.Add(filterInfo.Name);
            cbname.SelectedIndex = 0;


            MySqlConnection connection = new MySqlConnection(connectionString);  //csatlakozás adatbázishoz
            string sql = "SELECT * FROM felvett";
            struct_adatok adat;
            MySqlCommand cmd = new MySqlCommand(sql, connection);   //adatok lekérése
            connection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                adat.nev = reader.GetString("Nev");
                adat.rfid = reader.GetString("RFID");   //adatok beolvasása majd hozzáadása az adatok tömbhöz és a listviewhez
                adatok = adatok.Append(adat).ToArray();
                ListViewItem item = new ListViewItem(adat.nev);
                item.SubItems.Add(adat.rfid);
                lv.Items.Add(item);
            }
            connection.Close();

            adatok = adatok.Skip(1).ToArray();
        }


        private void but_torles_Click(object sender, EventArgs e)
        {
            if(lv.SelectedItems.Count != 0)  //van e kiválasztott elem
            {
                string nev = lv.SelectedItems[0].Text;
                string rfid = lv.SelectedItems[0].SubItems[1].Text;   //kiválasztott elemek eltárolása
                lv.SelectedItems[0].Remove();
                TorlesMentes(nev, rfid);    //Törlésmentés hívása kiválasztott elemek átadása
                MessageBox.Show("A kiválasztott elem sikeresen törölve lett!", "Sikeres törlés!");

            }
            else
            {
                MessageBox.Show("Válasszon ki egy elemet a törlés elött!", "Hiba!");
            }
        }


        private struct_adatok[] TorlesMentes(string nev,string rfid)
        {
            adatok = adatok.Where(x => x.rfid != rfid).ToArray();   //adatok tömb frissitése
            MySqlConnection connection = new MySqlConnection(connectionString);
            string sql = "DELETE FROM felvett Where RFID='"+rfid+"'"; //adatbázis frissitése
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            try
            {
                serialPort.Open();
                serialPort.WriteLine("B");
                serialPort.Close();

            }
            catch
            {
                Console.WriteLine("Nem lehet a portot megnyitni");
            }
            return adatok;
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            lv.Items.Clear();    //listview elemek frissitése
            MySqlConnection connection = new MySqlConnection(connectionString);
            string sql = "SELECT * FROM felvett";
            struct_adatok adat;
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            connection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                adat.nev = reader.GetString("Nev");
                adat.rfid = reader.GetString("RFID");
                adatok = adatok.Append(adat).ToArray();
                ListViewItem item = new ListViewItem(adat.nev);
                item.SubItems.Add(adat.rfid);
                lv.Items.Add(item);
            }
            connection.Close();
        }


        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pic.Image = (Bitmap)eventArgs.Frame.Clone();

            if (pic.Image != null)
            {
                System.Threading.Thread.Sleep(500);
                pic.Image.Save("C:\\Kepek\\"+rfid+".png", System.Drawing.Imaging.ImageFormat.Png);  // kép mentése
            }
            pic.Image = null;
        }
    }
}
