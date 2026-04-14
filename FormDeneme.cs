using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DgsTakipSistemi_DGSTS_
{
    public partial class FormDeneme : Form
    {
        public FormDeneme()
        {
            InitializeComponent();
            this.Load += FormDeneme_Load;
            nudMatDogru.ValueChanged += NetHesapla;
            nudMatYanlis.ValueChanged += NetHesapla;
            nudTurkDogru.ValueChanged += NetHesapla;
            nudTurkYanlis.ValueChanged += NetHesapla;
            nudObp.ValueChanged += NetHesapla;
        }

        private void FormDeneme_Load(object sender, EventArgs e)
        {
            ListeyiYukle();
        }

        private void NetHesapla(object sender, EventArgs e)
        {
            decimal sayisalNet = nudMatDogru.Value - (nudMatYanlis.Value / 4);
            decimal sozelNet = nudTurkDogru.Value - (nudTurkYanlis.Value / 4);
            if (sayisalNet < 0) sayisalNet = 0;
            if (sozelNet < 0) sozelNet = 0;

            decimal aobp = nudObp.Value * 0.8m * 0.6m;

            decimal dgsSay = 148m + (sayisalNet * 3.43m) + (sozelNet * 0.58m) + aobp;
            decimal dgsSoz = 130m + (sozelNet * 2.93m) + (sayisalNet * 0.68m) + aobp;
            decimal dgsEA = 139m + (sayisalNet * 2.06m) + (sozelNet * 1.76m) + aobp;

            lblSayisalNet.Text = "Sayısal Net: " + sayisalNet.ToString("0.00");
            lblSozelNet.Text = "Sözel Net: " + sozelNet.ToString("0.00");
            lblSay.Text = "DGS-SAY: " + dgsSay.ToString("0.00");
            lblSoz.Text = "DGS-SÖZ: " + dgsSoz.ToString("0.00");
            lblEA.Text = "DGS-EA: " + dgsEA.ToString("0.00");
        }

        private void ListeyiYukle()
        {
            dgvDenemeler.Rows.Clear();
            dgvDenemeler.Columns.Clear();

            dgvDenemeler.Columns.Add("Tarih", "Tarih");
            dgvDenemeler.Columns.Add("Ad", "Deneme Adı");
            dgvDenemeler.Columns.Add("MatD", "Mat D");
            dgvDenemeler.Columns.Add("MatY", "Mat Y");
            dgvDenemeler.Columns.Add("TurkD", "Türk D");
            dgvDenemeler.Columns.Add("TurkY", "Türk Y");
            dgvDenemeler.Columns.Add("OBP", "OBP");
            dgvDenemeler.Columns.Add("SayNet", "Say.Net");
            dgvDenemeler.Columns.Add("SozNet", "Söz.Net");
            dgvDenemeler.Columns.Add("SAY", "DGS-SAY");
            dgvDenemeler.Columns.Add("SOZ", "DGS-SÖZ");
            dgvDenemeler.Columns.Add("EA", "DGS-EA");

            List<string> satirlar = FileHelper.SatirlariOku(FileHelper.DenemePath);
            foreach (string satir in satirlar)
            {
                string[] p = satir.Split('|');
                if (p.Length >= 12)
                    dgvDenemeler.Rows.Add(p[0], p[1], p[2], p[3], p[4], p[5], p[6], p[7], p[8], p[9], p[10], p[11]);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string ad = txtDenemeAdi.Text.Trim().Replace("|", "-");
            if (string.IsNullOrEmpty(ad))
            {
                MessageBox.Show("Lütfen deneme adı girin!", "Uyarı");
                return;
            }

            decimal sayisalNet = nudMatDogru.Value - (nudMatYanlis.Value / 4);
            decimal sozelNet = nudTurkDogru.Value - (nudTurkYanlis.Value / 4);
            if (sayisalNet < 0) sayisalNet = 0;
            if (sozelNet < 0) sozelNet = 0;

            decimal aobp = nudObp.Value * 0.8m * 0.6m;
            decimal dgsSay = 148m + (sayisalNet * 3.43m) + (sozelNet * 0.58m) + aobp;
            decimal dgsSoz = 130m + (sozelNet * 2.93m) + (sayisalNet * 0.68m) + aobp;
            decimal dgsEA = 139m + (sayisalNet * 2.06m) + (sozelNet * 1.76m) + aobp;

            string satir = $"{dtpTarih.Value:yyyy-MM-dd}|{ad}|{nudMatDogru.Value}|{nudMatYanlis.Value}|{nudTurkDogru.Value}|{nudTurkYanlis.Value}|{nudObp.Value}|{sayisalNet:0.00}|{sozelNet:0.00}|{dgsSay:0.00}|{dgsSoz:0.00}|{dgsEA:0.00}";
            FileHelper.SatirEkle(FileHelper.DenemePath, satir);

            txtDenemeAdi.Clear();
            nudMatDogru.Value = 0;
            nudMatYanlis.Value = 0;
            nudTurkDogru.Value = 0;
            nudTurkYanlis.Value = 0;
            nudObp.Value = 0;

            ListeyiYukle();
            MessageBox.Show("Deneme kaydedildi!", "Bilgi");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvDenemeler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen satır seçin!", "Uyarı");
                return;
            }

            DataGridViewRow satir = dgvDenemeler.SelectedRows[0];
            string silinecek = $"{satir.Cells[0].Value}|{satir.Cells[1].Value}|{satir.Cells[2].Value}|{satir.Cells[3].Value}|{satir.Cells[4].Value}|{satir.Cells[5].Value}|{satir.Cells[6].Value}|{satir.Cells[7].Value}|{satir.Cells[8].Value}|{satir.Cells[9].Value}|{satir.Cells[10].Value}|{satir.Cells[11].Value}";
            FileHelper.SatirSil(FileHelper.DenemePath, silinecek);
            ListeyiYukle();
        }
    }
}