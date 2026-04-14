namespace DgsTakipSistemi_DGSTS_
{
    partial class FormCalisma
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
            lblTarih = new Label();
            dtpTarih = new DateTimePicker();
            lblDers = new Label();
            cmbDers = new ComboBox();
            lblSaat = new Label();
            label2 = new Label();
            nudSaat = new NumericUpDown();
            txtNot = new TextBox();
            btnKaydet = new Button();
            btnSil = new Button();
            dgvCalismalar = new DataGridView();
            lblKonu = new Label();
            cmbKonu = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)nudSaat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCalismalar).BeginInit();
            SuspendLayout();
            // 
            // lblTarih
            // 
            lblTarih.AutoSize = true;
            lblTarih.Location = new Point(35, 24);
            lblTarih.Name = "lblTarih";
            lblTarih.Size = new Size(43, 20);
            lblTarih.TabIndex = 0;
            lblTarih.Text = "Tarih:";
            // 
            // dtpTarih
            // 
            dtpTarih.Location = new Point(104, 24);
            dtpTarih.Name = "dtpTarih";
            dtpTarih.Size = new Size(250, 27);
            dtpTarih.TabIndex = 1;
            // 
            // lblDers
            // 
            lblDers.AutoSize = true;
            lblDers.Location = new Point(36, 72);
            lblDers.Name = "lblDers";
            lblDers.Size = new Size(42, 20);
            lblDers.TabIndex = 2;
            lblDers.Text = "Ders:";
            // 
            // cmbDers
            // 
            cmbDers.FormattingEnabled = true;
            cmbDers.Items.AddRange(new object[] { "Matematik", "Geometri", "Türkçe" });
            cmbDers.Location = new Point(104, 69);
            cmbDers.Name = "cmbDers";
            cmbDers.Size = new Size(229, 28);
            cmbDers.TabIndex = 3;
            // 
            // lblSaat
            // 
            lblSaat.AutoSize = true;
            lblSaat.Location = new Point(37, 171);
            lblSaat.Name = "lblSaat";
            lblSaat.Size = new Size(41, 20);
            lblSaat.TabIndex = 4;
            lblSaat.Text = "Saat:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 216);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 5;
            label2.Text = "Konu Notu:";
            // 
            // nudSaat
            // 
            nudSaat.DecimalPlaces = 1;
            nudSaat.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            nudSaat.Location = new Point(105, 164);
            nudSaat.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            nudSaat.Name = "nudSaat";
            nudSaat.Size = new Size(150, 27);
            nudSaat.TabIndex = 6;
            // 
            // txtNot
            // 
            txtNot.Location = new Point(139, 209);
            txtNot.Multiline = true;
            txtNot.Name = "txtNot";
            txtNot.Size = new Size(194, 34);
            txtNot.TabIndex = 7;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(37, 270);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(94, 29);
            btnKaydet.TabIndex = 8;
            btnKaydet.Text = "💾 Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click_1;
            // 
            // btnSil
            // 
            btnSil.Location = new Point(260, 270);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(94, 29);
            btnSil.TabIndex = 9;
            btnSil.Text = "🗑 Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // dgvCalismalar
            // 
            dgvCalismalar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCalismalar.Location = new Point(12, 311);
            dgvCalismalar.Name = "dgvCalismalar";
            dgvCalismalar.RowHeadersWidth = 51;
            dgvCalismalar.Size = new Size(734, 127);
            dgvCalismalar.TabIndex = 10;
            // 
            // lblKonu
            // 
            lblKonu.AutoSize = true;
            lblKonu.Location = new Point(35, 124);
            lblKonu.Name = "lblKonu";
            lblKonu.Size = new Size(46, 20);
            lblKonu.TabIndex = 11;
            lblKonu.Text = "Konu:";
            // 
            // cmbKonu
            // 
            cmbKonu.FormattingEnabled = true;
            cmbKonu.Location = new Point(104, 116);
            cmbKonu.Name = "cmbKonu";
            cmbKonu.Size = new Size(229, 28);
            cmbKonu.TabIndex = 12;
            // 
            // FormCalisma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(758, 450);
            Controls.Add(cmbKonu);
            Controls.Add(lblKonu);
            Controls.Add(dgvCalismalar);
            Controls.Add(btnSil);
            Controls.Add(btnKaydet);
            Controls.Add(txtNot);
            Controls.Add(nudSaat);
            Controls.Add(label2);
            Controls.Add(lblSaat);
            Controls.Add(cmbDers);
            Controls.Add(lblDers);
            Controls.Add(dtpTarih);
            Controls.Add(lblTarih);
            Name = "FormCalisma";
            Text = "FormCalisma";
            ((System.ComponentModel.ISupportInitialize)nudSaat).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCalismalar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTarih;
        private DateTimePicker dtpTarih;
        private Label lblDers;
        private ComboBox cmbDers;
        private Label lblSaat;
        private Label label2;
        private NumericUpDown nudSaat;
        private TextBox txtNot;
        private Button btnKaydet;
        private Button btnSil;
        private DataGridView dgvCalismalar;
        private Label lblKonu;
        private ComboBox cmbKonu;
    }
}