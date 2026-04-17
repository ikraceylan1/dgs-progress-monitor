namespace DgsTakipSistemi_DGSTS_
{
    partial class FormDeneme
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
            dtpTarih = new DateTimePicker();
            btnKaydet = new Button();
            btnSil = new Button();
            dgvDenemeler = new DataGridView();
            lblMatD = new Label();
            lblMatY = new Label();
            lblTurkceD = new Label();
            lblTurkceY = new Label();
            lblSayisalNet = new Label();
            lblSay = new Label();
            lblSozelNet = new Label();
            lblEA = new Label();
            nudMatDogru = new NumericUpDown();
            nudMatYanlis = new NumericUpDown();
            nudTurkDogru = new NumericUpDown();
            nudTurkYanlis = new NumericUpDown();
            lblSoz = new Label();
            lblDeneme = new Label();
            txtDenemeAdi = new TextBox();
            lblObp = new Label();
            nudObp = new NumericUpDown();
            lblEaNet = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDenemeler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMatDogru).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMatYanlis).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTurkDogru).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTurkYanlis).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudObp).BeginInit();
            SuspendLayout();
            // 
            // dtpTarih
            // 
            dtpTarih.Location = new Point(529, 68);
            dtpTarih.Name = "dtpTarih";
            dtpTarih.Size = new Size(210, 27);
            dtpTarih.TabIndex = 0;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(269, 460);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(66, 28);
            btnKaydet.TabIndex = 9;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnSil
            // 
            btnSil.Location = new Point(577, 460);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(59, 28);
            btnSil.TabIndex = 10;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // dgvDenemeler
            // 
            dgvDenemeler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDenemeler.Location = new Point(11, 495);
            dgvDenemeler.Name = "dgvDenemeler";
            dgvDenemeler.RowHeadersWidth = 51;
            dgvDenemeler.Size = new Size(899, 116);
            dgvDenemeler.TabIndex = 11;
            // 
            // lblMatD
            // 
            lblMatD.AutoSize = true;
            lblMatD.Location = new Point(170, 217);
            lblMatD.Name = "lblMatD";
            lblMatD.Size = new Size(84, 20);
            lblMatD.TabIndex = 12;
            lblMatD.Text = "Mat Doğru:";
            // 
            // lblMatY
            // 
            lblMatY.AutoSize = true;
            lblMatY.Location = new Point(451, 217);
            lblMatY.Name = "lblMatY";
            lblMatY.Size = new Size(79, 20);
            lblMatY.TabIndex = 13;
            lblMatY.Text = "Mat Yanlış:";
            // 
            // lblTurkceD
            // 
            lblTurkceD.AutoSize = true;
            lblTurkceD.Location = new Point(170, 264);
            lblTurkceD.Name = "lblTurkceD";
            lblTurkceD.Size = new Size(101, 20);
            lblTurkceD.TabIndex = 14;
            lblTurkceD.Text = "Türkçe Doğru:";
            // 
            // lblTurkceY
            // 
            lblTurkceY.AutoSize = true;
            lblTurkceY.Location = new Point(451, 264);
            lblTurkceY.Name = "lblTurkceY";
            lblTurkceY.Size = new Size(96, 20);
            lblTurkceY.TabIndex = 15;
            lblTurkceY.Text = "Türkçe Yanlış:";
            // 
            // lblSayisalNet
            // 
            lblSayisalNet.AutoSize = true;
            lblSayisalNet.Location = new Point(285, 333);
            lblSayisalNet.Name = "lblSayisalNet";
            lblSayisalNet.Size = new Size(97, 20);
            lblSayisalNet.TabIndex = 16;
            lblSayisalNet.Text = "Sayısal Net: 0";
            // 
            // lblSay
            // 
            lblSay.AutoSize = true;
            lblSay.Location = new Point(540, 333);
            lblSay.Name = "lblSay";
            lblSay.Size = new Size(84, 20);
            lblSay.TabIndex = 17;
            lblSay.Text = "DGS-SAY: 0";
            // 
            // lblSozelNet
            // 
            lblSozelNet.AutoSize = true;
            lblSozelNet.Location = new Point(285, 375);
            lblSozelNet.Name = "lblSozelNet";
            lblSozelNet.Size = new Size(88, 20);
            lblSozelNet.TabIndex = 18;
            lblSozelNet.Text = "Sözel Net: 0";
            // 
            // lblEA
            // 
            lblEA.AutoSize = true;
            lblEA.Location = new Point(540, 420);
            lblEA.Name = "lblEA";
            lblEA.Size = new Size(77, 20);
            lblEA.TabIndex = 19;
            lblEA.Text = "DGS-EA: 0";
            // 
            // nudMatDogru
            // 
            nudMatDogru.Location = new Point(275, 210);
            nudMatDogru.Name = "nudMatDogru";
            nudMatDogru.Size = new Size(150, 27);
            nudMatDogru.TabIndex = 20;
            // 
            // nudMatYanlis
            // 
            nudMatYanlis.Location = new Point(562, 210);
            nudMatYanlis.Name = "nudMatYanlis";
            nudMatYanlis.Size = new Size(150, 27);
            nudMatYanlis.TabIndex = 21;
            // 
            // nudTurkDogru
            // 
            nudTurkDogru.Location = new Point(275, 262);
            nudTurkDogru.Name = "nudTurkDogru";
            nudTurkDogru.Size = new Size(150, 27);
            nudTurkDogru.TabIndex = 22;
            // 
            // nudTurkYanlis
            // 
            nudTurkYanlis.Location = new Point(562, 264);
            nudTurkYanlis.Name = "nudTurkYanlis";
            nudTurkYanlis.Size = new Size(150, 27);
            nudTurkYanlis.TabIndex = 23;
            // 
            // lblSoz
            // 
            lblSoz.AutoSize = true;
            lblSoz.Location = new Point(540, 375);
            lblSoz.Name = "lblSoz";
            lblSoz.Size = new Size(87, 20);
            lblSoz.TabIndex = 24;
            lblSoz.Text = "DGS-SÖZ: 0";
            // 
            // lblDeneme
            // 
            lblDeneme.AutoSize = true;
            lblDeneme.Location = new Point(214, 73);
            lblDeneme.Name = "lblDeneme";
            lblDeneme.Size = new Size(95, 20);
            lblDeneme.TabIndex = 25;
            lblDeneme.Text = "Deneme Adı:";
            // 
            // txtDenemeAdi
            // 
            txtDenemeAdi.Location = new Point(338, 66);
            txtDenemeAdi.Name = "txtDenemeAdi";
            txtDenemeAdi.Size = new Size(150, 27);
            txtDenemeAdi.TabIndex = 26;
            // 
            // lblObp
            // 
            lblObp.AutoSize = true;
            lblObp.Location = new Point(311, 139);
            lblObp.Name = "lblObp";
            lblObp.Size = new Size(97, 20);
            lblObp.TabIndex = 27;
            lblObp.Text = "Obp(100'lük):";
            // 
            // nudObp
            // 
            nudObp.DecimalPlaces = 2;
            nudObp.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nudObp.Location = new Point(435, 137);
            nudObp.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            nudObp.Name = "nudObp";
            nudObp.Size = new Size(150, 27);
            nudObp.TabIndex = 28;
            nudObp.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // lblEaNet
            // 
            lblEaNet.AutoSize = true;
            lblEaNet.Location = new Point(285, 420);
            lblEaNet.Name = "lblEaNet";
            lblEaNet.Size = new Size(122, 20);
            lblEaNet.TabIndex = 29;
            lblEaNet.Text = "Eşit Ağırlık Net: 0";
            // 
            // FormDeneme
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(922, 623);
            Controls.Add(lblEaNet);
            Controls.Add(nudObp);
            Controls.Add(lblObp);
            Controls.Add(txtDenemeAdi);
            Controls.Add(lblDeneme);
            Controls.Add(lblSoz);
            Controls.Add(nudTurkYanlis);
            Controls.Add(nudTurkDogru);
            Controls.Add(nudMatYanlis);
            Controls.Add(nudMatDogru);
            Controls.Add(lblEA);
            Controls.Add(lblSozelNet);
            Controls.Add(lblSay);
            Controls.Add(lblSayisalNet);
            Controls.Add(lblTurkceY);
            Controls.Add(lblTurkceD);
            Controls.Add(lblMatY);
            Controls.Add(lblMatD);
            Controls.Add(dgvDenemeler);
            Controls.Add(btnSil);
            Controls.Add(btnKaydet);
            Controls.Add(dtpTarih);
            Name = "FormDeneme";
            Text = "FormDeneme";
            Load += FormDeneme_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDenemeler).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMatDogru).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMatYanlis).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTurkDogru).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTurkYanlis).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudObp).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpTarih;
        private Button btnKaydet;
        private Button btnSil;
        private DataGridView dgvDenemeler;
        private Label lblMatD;
        private Label lblMatY;
        private Label lblTurkceD;
        private Label lblTurkceY;
        private Label lblSayisalNet;
        private Label lblSay;
        private Label lblSozelNet;
        private Label lblEA;
        private NumericUpDown nudMatDogru;
        private NumericUpDown nudMatYanlis;
        private NumericUpDown nudTurkDogru;
        private NumericUpDown nudTurkYanlis;
        private Label lblSoz;
        private Label lblDeneme;
        private TextBox txtDenemeAdi;
        private Label lblObp;
        private NumericUpDown nudObp;
        private Label lblEaNet;
    }
}