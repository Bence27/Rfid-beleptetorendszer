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

namespace ArduinoWPF
{
    public partial class Felvitel : Form
    {
        SerialPort serialPort;

        static string connectionString = "SERVER=localhost;DATABASE=arduino;UID=root;PASSWORD=;";

        struct_adatok[] adatok = new struct_adatok[1];


        public Felvitel()
        {
            InitializeComponent();
            serialPort = new SerialPort("COM3", 9600);
        }


        private void but_kilep_Click(object sender, EventArgs e)
        {
          
            this.Close();
            Form1 form = new Form1();
            form.Activate();
        }

        private struct_adatok[] AdatbazisMentes(string nev, string rfid)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            string sql = "Insert INTO felvett (felvett.Nev, felvett.RFID) VALUES ('" + nev + "','" + rfid + "')"; //sql
            struct_adatok adat;
            adat.nev = nev;
            adat.rfid = rfid;
            adatok = adatok.Append(adat).ToArray(); //adatok tömb frissitése
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            ListViewItem item = new ListViewItem(adat.nev);
            item.SubItems.Add(adat.rfid);
            try   // arduino prancs küldése
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


        private void but_rfidolv_Click(object sender, EventArgs e)
        {
            if(Nev.Text != "")
            {
                serialPort.ReadTimeout = 10000;
                string nev = Nev.Text;
                bool haveRFID = false;
                string rfid = string.Empty;
                try
                {
                    serialPort.Open();
                }
                catch
                {
                    Console.WriteLine("Nem lehet megnyitni a COM portot");
                }


                while (serialPort.IsOpen)
                {
                    try
                    {
                        rfid = serialPort.ReadLine();
                        rfid = rfid.Replace("\r", "");
                        if (!string.IsNullOrEmpty(rfid))
                        {
                            haveRFID = true;
                            serialPort.Close();
                        }
                    }
                    catch (TimeoutException)
                    {
                        serialPort.Close();
                        MessageBox.Show("A beolvasási idő lejárt!", "Idő túllépés");
                    }
                }

                if (haveRFID)
                {
                    RFIDname.Text += rfid;
                    AdatbazisMentes(nev, rfid);
                    MessageBox.Show("Olvasás sikeres", "Siker");
                }

               

            }
            else
            {
                MessageBox.Show("Név mező kitöltése kötelező!", "Hiba");
            }
        }
    }
}
