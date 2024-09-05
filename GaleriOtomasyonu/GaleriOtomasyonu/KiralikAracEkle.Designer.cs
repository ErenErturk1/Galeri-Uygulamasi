namespace GaleriOtomasyonu
{
    partial class KiralikAracEkle
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
            this.components = new System.ComponentModel.Container();
            this.label15 = new System.Windows.Forms.Label();
            this.btnKiralaKaydet = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.lblSirket = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.txtHasar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMarka = new System.Windows.Forms.ComboBox();
            this.aracMarkalariBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.galeriOtomasyonuDataSet1 = new GaleriOtomasyonu.GaleriOtomasyonuDataSet();
            this.txtKM = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPlaka = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRenk = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.aracMarkalariTableAdapter1 = new GaleriOtomasyonu.GaleriOtomasyonuDataSetTableAdapters.AracMarkalariTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.aracMarkalariBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.galeriOtomasyonuDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label15.ForeColor = System.Drawing.Color.Lime;
            this.label15.Location = new System.Drawing.Point(742, 199);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(238, 25);
            this.label15.TabIndex = 83;
            this.label15.Text = "Kiralanan Araç Bilgileri;";
            // 
            // btnKiralaKaydet
            // 
            this.btnKiralaKaydet.BackColor = System.Drawing.Color.White;
            this.btnKiralaKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKiralaKaydet.Location = new System.Drawing.Point(845, 688);
            this.btnKiralaKaydet.Name = "btnKiralaKaydet";
            this.btnKiralaKaydet.Size = new System.Drawing.Size(192, 78);
            this.btnKiralaKaydet.TabIndex = 8;
            this.btnKiralaKaydet.Text = "Kirala ve \r\nKaydet";
            this.btnKiralaKaydet.UseVisualStyleBackColor = false;
            this.btnKiralaKaydet.Click += new System.EventHandler(this.btnKiralaKaydet_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Location = new System.Drawing.Point(1086, 688);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(192, 78);
            this.button2.TabIndex = 9;
            this.button2.Text = "Geri Dön";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.BackColor = System.Drawing.Color.White;
            this.btnTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTemizle.Location = new System.Drawing.Point(983, 787);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(163, 81);
            this.btnTemizle.TabIndex = 10;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = false;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // lblSirket
            // 
            this.lblSirket.AutoSize = true;
            this.lblSirket.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSirket.ForeColor = System.Drawing.Color.Cyan;
            this.lblSirket.Location = new System.Drawing.Point(936, 9);
            this.lblSirket.Name = "lblSirket";
            this.lblSirket.Size = new System.Drawing.Size(101, 36);
            this.lblSirket.TabIndex = 84;
            this.lblSirket.Text = "label2";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioButton2.ForeColor = System.Drawing.Color.White;
            this.radioButton2.Location = new System.Drawing.Point(985, 642);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(134, 33);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Hasarsız";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioButton1.ForeColor = System.Drawing.Color.White;
            this.radioButton1.Location = new System.Drawing.Point(985, 597);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(116, 33);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Hasarlı";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // txtHasar
            // 
            this.txtHasar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtHasar.Location = new System.Drawing.Point(985, 599);
            this.txtHasar.Name = "txtHasar";
            this.txtHasar.Size = new System.Drawing.Size(259, 28);
            this.txtHasar.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(765, 598);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 29);
            this.label4.TabIndex = 125;
            this.label4.Text = "Hasar Durumu:";
            // 
            // cbMarka
            // 
            this.cbMarka.DataSource = this.aracMarkalariBindingSource;
            this.cbMarka.DisplayMember = "Markalar";
            this.cbMarka.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.cbMarka.FormattingEnabled = true;
            this.cbMarka.Location = new System.Drawing.Point(985, 317);
            this.cbMarka.Name = "cbMarka";
            this.cbMarka.Size = new System.Drawing.Size(259, 30);
            this.cbMarka.TabIndex = 0;
            this.cbMarka.ValueMember = "Markalar";
            // 
            // aracMarkalariBindingSource
            // 
            this.aracMarkalariBindingSource.DataMember = "AracMarkalari";
            this.aracMarkalariBindingSource.DataSource = this.galeriOtomasyonuDataSet1;
            // 
            // galeriOtomasyonuDataSet1
            // 
            this.galeriOtomasyonuDataSet1.DataSetName = "GaleriOtomasyonuDataSet";
            this.galeriOtomasyonuDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtKM
            // 
            this.txtKM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKM.Location = new System.Drawing.Point(985, 543);
            this.txtKM.Name = "txtKM";
            this.txtKM.Size = new System.Drawing.Size(259, 28);
            this.txtKM.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(849, 543);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 29);
            this.label5.TabIndex = 124;
            this.label5.Text = "Araç KM:";
            // 
            // txtPlaka
            // 
            this.txtPlaka.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPlaka.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPlaka.Location = new System.Drawing.Point(985, 487);
            this.txtPlaka.MaxLength = 9;
            this.txtPlaka.Name = "txtPlaka";
            this.txtPlaka.Size = new System.Drawing.Size(259, 28);
            this.txtPlaka.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(802, 486);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 29);
            this.label7.TabIndex = 123;
            this.label7.Text = "Araç Plakası:";
            // 
            // txtRenk
            // 
            this.txtRenk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtRenk.Location = new System.Drawing.Point(985, 431);
            this.txtRenk.Name = "txtRenk";
            this.txtRenk.Size = new System.Drawing.Size(259, 28);
            this.txtRenk.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(818, 429);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 29);
            this.label8.TabIndex = 122;
            this.label8.Text = "Araç Rengi:";
            // 
            // txtModel
            // 
            this.txtModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtModel.Location = new System.Drawing.Point(985, 375);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(259, 28);
            this.txtModel.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(807, 372);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(159, 29);
            this.label9.TabIndex = 121;
            this.label9.Text = "Araç Modeli:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(796, 315);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(170, 29);
            this.label10.TabIndex = 120;
            this.label10.Text = "Araç Markası:";
            // 
            // aracMarkalariTableAdapter1
            // 
            this.aracMarkalariTableAdapter1.ClearBeforeFill = true;
            // 
            // KiralikAracEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.txtHasar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbMarka);
            this.Controls.Add(this.txtKM);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPlaka);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtRenk);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblSirket);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnKiralaKaydet);
            this.Controls.Add(this.label15);
            this.Name = "KiralikAracEkle";
            this.Text = "Kiralık Araç Bilgileri Ekleme Ekranı";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.KiralikAracEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.aracMarkalariBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.galeriOtomasyonuDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnKiralaKaydet;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Label lblSirket;
        private GaleriOtomasyonuDataSet galeriOtomasyonuDataSet;
        private GaleriOtomasyonuDataSetTableAdapters.AracMarkalariTableAdapter aracMarkalariTableAdapter;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox txtHasar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbMarka;
        private System.Windows.Forms.TextBox txtKM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPlaka;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRenk;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private GaleriOtomasyonuDataSet galeriOtomasyonuDataSet1;
        private System.Windows.Forms.BindingSource aracMarkalariBindingSource;
        private GaleriOtomasyonuDataSetTableAdapters.AracMarkalariTableAdapter aracMarkalariTableAdapter1;
    }
}