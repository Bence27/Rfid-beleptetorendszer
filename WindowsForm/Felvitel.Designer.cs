
namespace ArduinoWPF
{
    partial class Felvitel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Felvitel));
            this.but_kilep = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Nev = new System.Windows.Forms.TextBox();
            this.RFIDname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.but_rfidolv = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // but_kilep
            // 
            this.but_kilep.Location = new System.Drawing.Point(143, 230);
            this.but_kilep.Name = "but_kilep";
            this.but_kilep.Size = new System.Drawing.Size(92, 52);
            this.but_kilep.TabIndex = 0;
            this.but_kilep.Text = "Kilepes";
            this.but_kilep.UseVisualStyleBackColor = true;
            this.but_kilep.Click += new System.EventHandler(this.but_kilep_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "RFID";
            // 
            // Nev
            // 
            this.Nev.Location = new System.Drawing.Point(41, 61);
            this.Nev.Name = "Nev";
            this.Nev.Size = new System.Drawing.Size(197, 20);
            this.Nev.TabIndex = 2;
            // 
            // RFIDname
            // 
            this.RFIDname.Location = new System.Drawing.Point(41, 159);
            this.RFIDname.Name = "RFIDname";
            this.RFIDname.ReadOnly = true;
            this.RFIDname.Size = new System.Drawing.Size(197, 20);
            this.RFIDname.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Név";
            // 
            // but_rfidolv
            // 
            this.but_rfidolv.Location = new System.Drawing.Point(41, 229);
            this.but_rfidolv.Margin = new System.Windows.Forms.Padding(2);
            this.but_rfidolv.Name = "but_rfidolv";
            this.but_rfidolv.Size = new System.Drawing.Size(92, 53);
            this.but_rfidolv.TabIndex = 5;
            this.but_rfidolv.Text = "RFID Olvasás & Mentés";
            this.but_rfidolv.UseVisualStyleBackColor = true;
            this.but_rfidolv.Click += new System.EventHandler(this.but_rfidolv_Click);
            // 
            // Felvitel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 291);
            this.Controls.Add(this.but_rfidolv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RFIDname);
            this.Controls.Add(this.Nev);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.but_kilep);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Felvitel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Felvitel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_kilep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Nev;
        private System.Windows.Forms.TextBox RFIDname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button but_rfidolv;
    }
}