namespace DgsTakipSistemi_DGSTS_
{
    partial class FormHedef
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
            dgvHedefler = new DataGridView();
            cmbSinavYili = new ComboBox();
            btnIptal = new Button();
            lblKalanGun = new Label();
            nudCalisma = new NumericUpDown();
            cmbDersler = new ComboBox();
            nudTestAdet = new NumericUpDown();
            btnEkle = new Button();
            lblHedefDers = new Label();
            lblHedefSaat = new Label();
            lblHedefSoru = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvHedefler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCalisma).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTestAdet).BeginInit();
            SuspendLayout();
            // 
            // dgvHedefler
            // 
            dgvHedefler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHedefler.Location = new Point(12, 283);
            dgvHedefler.Name = "dgvHedefler";
            dgvHedefler.RowHeadersWidth = 51;
            dgvHedefler.Size = new Size(884, 198);
            dgvHedefler.TabIndex = 6;
            // 
            // cmbSinavYili
            // 
            cmbSinavYili.FormattingEnabled = true;
            cmbSinavYili.Location = new Point(745, 12);
            cmbSinavYili.Name = "cmbSinavYili";
            cmbSinavYili.Size = new Size(151, 28);
            cmbSinavYili.TabIndex = 7;
            // 
            // btnIptal
            // 
            btnIptal.Location = new Point(427, 220);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(94, 29);
            btnIptal.TabIndex = 9;
            btnIptal.Text = "İptal";
            btnIptal.UseVisualStyleBackColor = true;
            // 
            // lblKalanGun
            // 
            lblKalanGun.AutoSize = true;
            lblKalanGun.Location = new Point(745, 61);
            lblKalanGun.Name = "lblKalanGun";
            lblKalanGun.Size = new Size(50, 20);
            lblKalanGun.TabIndex = 10;
            lblKalanGun.Text = "label1";
            // 
            // nudCalisma
            // 
            nudCalisma.Location = new Point(279, 94);
            nudCalisma.Name = "nudCalisma";
            nudCalisma.Size = new Size(150, 27);
            nudCalisma.TabIndex = 11;
            // 
            // cmbDersler
            // 
            cmbDersler.FormattingEnabled = true;
            cmbDersler.Location = new Point(278, 42);
            cmbDersler.Name = "cmbDersler";
            cmbDersler.Size = new Size(151, 28);
            cmbDersler.TabIndex = 12;
            // 
            // nudTestAdet
            // 
            nudTestAdet.Location = new Point(279, 142);
            nudTestAdet.Name = "nudTestAdet";
            nudTestAdet.Size = new Size(150, 27);
            nudTestAdet.TabIndex = 13;
            // 
            // btnEkle
            // 
            btnEkle.Location = new Point(206, 220);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(94, 29);
            btnEkle.TabIndex = 14;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // lblHedefDers
            // 
            lblHedefDers.AutoSize = true;
            lblHedefDers.Location = new Point(97, 50);
            lblHedefDers.Name = "lblHedefDers";
            lblHedefDers.Size = new Size(84, 20);
            lblHedefDers.TabIndex = 15;
            lblHedefDers.Text = "Der seçiniz:";
            // 
            // lblHedefSaat
            // 
            lblHedefSaat.AutoSize = true;
            lblHedefSaat.Location = new Point(97, 101);
            lblHedefSaat.Name = "lblHedefSaat";
            lblHedefSaat.Size = new Size(122, 20);
            lblHedefSaat.TabIndex = 16;
            lblHedefSaat.Text = "Hedeflenen Saat:";
            // 
            // lblHedefSoru
            // 
            lblHedefSoru.AutoSize = true;
            lblHedefSoru.Location = new Point(97, 149);
            lblHedefSoru.Name = "lblHedefSoru";
            lblHedefSoru.Size = new Size(154, 20);
            lblHedefSoru.TabIndex = 17;
            lblHedefSoru.Text = "Çözülecek Soru Sayısı:\r\n";
            // 
            // FormHedef
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1025, 612);
            Controls.Add(lblHedefSoru);
            Controls.Add(lblHedefSaat);
            Controls.Add(lblHedefDers);
            Controls.Add(btnEkle);
            Controls.Add(nudTestAdet);
            Controls.Add(cmbDersler);
            Controls.Add(nudCalisma);
            Controls.Add(lblKalanGun);
            Controls.Add(btnIptal);
            Controls.Add(cmbSinavYili);
            Controls.Add(dgvHedefler);
            Name = "FormHedef";
            Text = "Haftalık Hedeflerim";
            Load += FormHedef_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHedefler).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCalisma).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTestAdet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvHedefler;
        private ComboBox cmbSinavYili;
        private Button btnIptal;
        private Label lblKalanGun;
        private NumericUpDown nudCalisma;
        private ComboBox cmbDersler;
        private NumericUpDown nudTestAdet;
        private Button btnEkle;
        private Label lblHedefDers;
        private Label lblHedefSaat;
        private Label lblHedefSoru;
    }
}