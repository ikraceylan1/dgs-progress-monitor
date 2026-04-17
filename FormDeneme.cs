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
            // Form açılırken anında TemaHelper'a bakar, karanlıksa siyah giyinir
            TemaHelper.TemaUygula(this);
            ListeyiYukle();
        }

        private void NetHesapla(object sender, EventArgs e)
        {
            if (nudMatDogru.Value + nudMatYanlis.Value > 50)
            {
                MessageBox.Show("Matematik doğru ve yanlışlarının toplamı 50'yi geçemez! ❌", "Sınır İhlali", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Hangi kutuyu değiştiriyorsak, onu otomatik olarak maksimum alabileceği değere çeker
                NumericUpDown tetikleyen = sender as NumericUpDown;
                if (tetikleyen != null)
                    tetikleyen.Value = 50 - (tetikleyen == nudMatDogru ? nudMatYanlis.Value : nudMatDogru.Value);
                return;
            }

            if (nudTurkDogru.Value + nudTurkYanlis.Value > 50)
            {
                MessageBox.Show("Türkçe doğru ve yanlışlarının toplamı 50'yi geçemez! ❌", "Sınır İhlali", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                NumericUpDown tetikleyen = sender as NumericUpDown;
                if (tetikleyen != null)
                    tetikleyen.Value = 50 - (tetikleyen == nudTurkDogru ? nudTurkYanlis.Value : nudTurkDogru.Value);
                return;
            }
            
           
            // --- 2. NET HESAPLAMA (Eksi netler artık serbest) ---
            decimal sayisalNet = nudMatDogru.Value - (nudMatYanlis.Value / 4);
            decimal sozelNet = nudTurkDogru.Value - (nudTurkYanlis.Value / 4);
            decimal eaNet = sayisalNet + sozelNet;
            if (sayisalNet <= 0 || sozelNet <= 0)
            {
                // Eğer kural ihlali varsa, o sahte 148 puanları silip yerine hata mesajı basıyoruz
                lblSay.Text = "DGS-SAY: Hesaplanamaz (1 Net Kuralı)";
                lblSoz.Text = "DGS-SÖZ: Hesaplanamaz (1 Net Kuralı)";
                lblEA.Text = "DGS-EA: Hesaplanamaz (1 Net Kuralı)";

                return; // İşlemi burada kesiyoruz ki alt satırlara inip o taban puanları tekrar eklemesin!
            }
            decimal aobp = nudObp.Value * 0.8m * 0.6m;

            decimal dgsSay = 148m + (sayisalNet * 3.43m) + (sozelNet * 0.58m) + aobp;
            decimal dgsSoz = 130m + (sozelNet * 2.93m) + (sayisalNet * 0.68m) + aobp;
            decimal dgsEA = 139m + (sayisalNet * 2.06m) + (sozelNet * 1.76m) + aobp;

            lblSayisalNet.Text = "Sayısal Net: " + sayisalNet.ToString("0.00");
            lblSozelNet.Text = "Sözel Net: " + sozelNet.ToString("0.00");
            lblEaNet.Text = "Eşit Ağırlık Net: " + eaNet.ToString("0.00");
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
            dgvDenemeler.Columns.Add("EaNet", "EA.Net");
            dgvDenemeler.Columns.Add("SAY", "DGS-SAY");
            dgvDenemeler.Columns.Add("SOZ", "DGS-SÖZ");
            dgvDenemeler.Columns.Add("EA", "DGS-EA");

            List<string> satirlar = FileHelper.SatirlariOku(FileHelper.DenemePath);
            foreach (string satir in satirlar)
            {
                string[] p = satir.Split('|');
                if (p.Length >= 13)
                    dgvDenemeler.Rows.Add(p[0], p[1], p[2], p[3], p[4], p[5], p[6], p[7], p[8], p[9], p[10], p[11], p[12]);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // 1. Önce kullanıcının netlerini hesaplayalım (Doğru - (Yanlış / 4))
            double matNet = (double)nudMatDogru.Value - ((double)nudMatYanlis.Value / 4.0);
            double turkceNet = (double)nudTurkDogru.Value - ((double)nudTurkYanlis.Value / 4.0);

            // 2. ÖSYM Kuralı Kontrolü: Herhangi biri 0 veya eksiyse kaydetmeyi DURDUR!
            if (matNet < 1 || turkceNet < 1)
            {
                MessageBox.Show("ÖSYM kuralları gereği DGS puanınızın hesaplanabilmesi için hem Matematik hem de Türkçe testinden en az 1 net yapmalısınız!",
                                "Kural İhlali 🛑",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                return; // return komutu, aşağıdaki kodların çalışmasını iptal eder ve işlemi anında keser!
            }
            string ad = txtDenemeAdi.Text.Trim().Replace("|", "-");
            if (string.IsNullOrEmpty(ad))
            {
                MessageBox.Show("Lütfen deneme adı girin!", "Uyarı");
                return;
            }

            decimal sayisalNet = nudMatDogru.Value - (nudMatYanlis.Value / 4);
            decimal sozelNet = nudTurkDogru.Value - (nudTurkYanlis.Value / 4);
            decimal eaNet = sayisalNet + sozelNet;
            if (sayisalNet < 0) sayisalNet = 0;
            if (sozelNet < 0) sozelNet = 0;
            if (eaNet < 0) eaNet = 0;   

            decimal aobp = nudObp.Value * 0.8m * 0.6m;
            decimal dgsSay = 148m + (sayisalNet * 3.43m) + (sozelNet * 0.58m) + aobp;
            decimal dgsSoz = 130m + (sozelNet * 2.93m) + (sayisalNet * 0.68m) + aobp;
            decimal dgsEA = 139m + (sayisalNet * 2.06m) + (sozelNet * 1.76m) + aobp;

            string satir = $"{dtpTarih.Value:yyyy-MM-dd}|{ad}|{nudMatDogru.Value}|{nudMatYanlis.Value}|{nudTurkDogru.Value}|{nudTurkYanlis.Value}|{nudObp.Value}|{sayisalNet:0.00}|{sozelNet:0.00}|{eaNet:0.00}|{dgsSay:0.00}|{dgsSoz:0.00}|{dgsEA:0.00}";
            FileHelper.SatirEkle(FileHelper.DenemePath, satir);

            txtDenemeAdi.Clear();
            nudMatDogru.Value = 0;
            nudMatYanlis.Value = 0;
            nudTurkDogru.Value = 0;
            nudTurkYanlis.Value = 0;
            nudObp.Value = 50;

            ListeyiYukle();
            MessageBox.Show("Deneme kaydedildi!", "Bilgi");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvDenemeler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz satırı seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Önce satırı ekrandan siliyoruz
            dgvDenemeler.Rows.Remove(dgvDenemeler.SelectedRows[0]);
            dgvDenemeler.ClearSelection();

            // 2. KURŞUN GEÇİRMEZ TAKTİK: Tablonun GÜNCEL halini al, dosyayı ezip baştan yaz!
            using (StreamWriter sw = new StreamWriter(FileHelper.DenemePath, false))
            {
                foreach (DataGridViewRow row in dgvDenemeler.Rows)
                {
                    if (row.Cells[0].Value != null) // Boş satır değilse
                    {
                        // SENIOR TAKTİĞİ: 13 hücreyi amele gibi tek tek yazmak yerine döngüyle birleştiriyoruz!
                        string[] hucreler = new string[13]; // 13 sütunumuz var
                        for (int i = 0; i < 13; i++)
                        {
                            hucreler[i] = row.Cells[i].Value?.ToString() ?? "";
                        }

                        // Bütün dizinin arasına "|" koyarak tek bir metin yapar. Mükemmel temizlik!
                        string guncelSatir = string.Join("|", hucreler);

                        sw.WriteLine(guncelSatir);
                    }
                }
            }

            MessageBox.Show("Deneme kaydı başarıyla silindi ve dosya güncellendi! 🗑️", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}