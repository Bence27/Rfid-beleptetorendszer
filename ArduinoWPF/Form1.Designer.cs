
namespace ArduinoWPF
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_log = new System.Windows.Forms.TextBox();
            this.but_kilep = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.but_belep = new System.Windows.Forms.Button();
            this.but_felvitel = new System.Windows.Forms.Button();
            this.lv = new System.Windows.Forms.ListView();
            this.Nev = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RFID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.but_torles = new System.Windows.Forms.Button();
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.pic = new System.Windows.Forms.PictureBox();
            this.cbname = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_log
            // 
            this.tb_log.Location = new System.Drawing.Point(24, 92);
            this.tb_log.Margin = new System.Windows.Forms.Padding(6);
            this.tb_log.Multiline = true;
            this.tb_log.Name = "tb_log";
            this.tb_log.Size = new System.Drawing.Size(556, 535);
            this.tb_log.TabIndex = 0;
            // 
            // but_kilep
            // 
            this.but_kilep.Location = new System.Drawing.Point(24, 703);
            this.but_kilep.Margin = new System.Windows.Forms.Padding(6);
            this.but_kilep.Name = "but_kilep";
            this.but_kilep.Size = new System.Drawing.Size(252, 78);
            this.but_kilep.TabIndex = 1;
            this.but_kilep.Text = "Kilépés";
            this.but_kilep.UseVisualStyleBackColor = true;
            this.but_kilep.Click += new System.EventHandler(this.but_kilep_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(110, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 55);
            this.label1.TabIndex = 2;
            this.label1.Text = "LOG";
            // 
            // but_belep
            // 
            this.but_belep.Location = new System.Drawing.Point(328, 703);
            this.but_belep.Margin = new System.Windows.Forms.Padding(6);
            this.but_belep.Name = "but_belep";
            this.but_belep.Size = new System.Drawing.Size(256, 78);
            this.but_belep.TabIndex = 3;
            this.but_belep.Text = "Belépés";
            this.but_belep.UseVisualStyleBackColor = true;
            this.but_belep.Click += new System.EventHandler(this.but_belep_Click);
            // 
            // but_felvitel
            // 
            this.but_felvitel.Location = new System.Drawing.Point(666, 441);
            this.but_felvitel.Margin = new System.Windows.Forms.Padding(6);
            this.but_felvitel.Name = "but_felvitel";
            this.but_felvitel.Size = new System.Drawing.Size(246, 78);
            this.but_felvitel.TabIndex = 4;
            this.but_felvitel.Text = "Felvitel";
            this.but_felvitel.UseVisualStyleBackColor = true;
            this.but_felvitel.Click += new System.EventHandler(this.but_felvitel_Click);
            // 
            // lv
            // 
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nev,
            this.RFID});
            this.lv.FullRowSelect = true;
            this.lv.GridLines = true;
            this.lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv.HideSelection = false;
            this.lv.Location = new System.Drawing.Point(666, 92);
            this.lv.Margin = new System.Windows.Forms.Padding(6);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(608, 270);
            this.lv.TabIndex = 9;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            // 
            // Nev
            // 
            this.Nev.DisplayIndex = 1;
            this.Nev.Text = "Név";
            this.Nev.Width = 150;
            // 
            // RFID
            // 
            this.RFID.DisplayIndex = 0;
            this.RFID.Text = "RFID";
            this.RFID.Width = 150;
            // 
            // but_torles
            // 
            this.but_torles.Location = new System.Drawing.Point(1020, 441);
            this.but_torles.Margin = new System.Windows.Forms.Padding(6);
            this.but_torles.Name = "but_torles";
            this.but_torles.Size = new System.Drawing.Size(258, 78);
            this.but_torles.TabIndex = 10;
            this.but_torles.Text = "Törlés";
            this.but_torles.UseVisualStyleBackColor = true;
            this.but_torles.Click += new System.EventHandler(this.but_torles_Click);
            // 
            // mySqlDataAdapter1
            // 
            this.mySqlDataAdapter1.DeleteCommand = null;
            this.mySqlDataAdapter1.InsertCommand = null;
            this.mySqlDataAdapter1.SelectCommand = null;
            this.mySqlDataAdapter1.UpdateCommand = null;
            // 
            // pic
            // 
            this.pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic.Location = new System.Drawing.Point(666, 561);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(608, 220);
            this.pic.TabIndex = 11;
            this.pic.TabStop = false;
            this.pic.Visible = false;
            // 
            // cbname
            // 
            this.cbname.FormattingEnabled = true;
            this.cbname.Location = new System.Drawing.Point(666, 387);
            this.cbname.Name = "cbname";
            this.cbname.Size = new System.Drawing.Size(608, 33);
            this.cbname.TabIndex = 12;
            this.cbname.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 829);
            this.Controls.Add(this.cbname);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.but_torles);
            this.Controls.Add(this.lv);
            this.Controls.Add(this.but_felvitel);
            this.Controls.Add(this.but_belep);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.but_kilep);
            this.Controls.Add(this.tb_log);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kezelő felület";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_log;
        private System.Windows.Forms.Button but_kilep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button but_belep;
        private System.Windows.Forms.Button but_felvitel;
        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader Nev;
        private System.Windows.Forms.ColumnHeader RFID;
        private System.Windows.Forms.Button but_torles;
        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.ComboBox cbname;
    }
}

