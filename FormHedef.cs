using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace DgsTakipSistemi_DGSTS_
{
    public partial class FormHedef : Form
    {
        string dosyaYolu = FileHelper.HedefPath;
        public FormHedef()
        {
            InitializeComponent();
            this.FormClosing += FormHedef_FormClosing;

            // EFSANE TAKTİK: Butonların çift tetiklenmesini (bug'ı) önlemek ve
            // tamamen ölmelerini engellemek için önce eylemi siliyoruz, sonra ekliyoruz.
            btnEkle.Click -= btnEkle_Click;
            btnEkle.Click += btnEkle_Click;


            btnIptal.Click -= btnIptal_Click;
            btnIptal.Click += btnIptal_Click;

            cmbSinavYili.SelectedIndexChanged -= cmbSinavYili_SelectedIndexChanged;
            cmbSinavYili.SelectedIndexChanged += cmbSinavYili_SelectedIndexChanged;
        }

        private void FormHedef_Load(object sender, EventArgs e)
        {
            TemaHelper.TemaUygula(this);
            int buYil = DateTime.Now.Year;
            cmbSinavYili.Items.Clear();
            for (int y = buYil; y <= buYil + 5; y++)
                cmbSinavYili.Items.Add(y.ToString());
            cmbSinavYili.SelectedIndex = 0;

            cmbDersler.Items.Clear();
            string[] dersler = { "Matematik", "Geometri", "Türkçe" };
            cmbDersler.Items.AddRange(dersler);
            cmbDersler.SelectedIndex = 0;

            nudCalisma.Minimum = 1;
            nudCalisma.Maximum = 16;
            nudCalisma.Value = 6;

            nudTestAdet.Minimum = 1;
            nudTestAdet.Maximum = 100;
            nudTestAdet.Value = 20;

            dgvHedefler.Columns.Clear();
            dgvHedefler.Columns.Add("Ders", "Ders");
            dgvHedefler.Columns.Add("Saat", "Günlük Saat");
            dgvHedefler.Columns.Add("GunlukTest", "Günlük Test");
            dgvHedefler.Columns["Ders"].Width = 120;
            dgvHedefler.Columns["Saat"].Width = 100;
            dgvHedefler.Columns["GunlukTest"].Width = 100;
            dgvHedefler.AllowUserToAddRows = false;

            YukleKayitliHedefler();
            KalanGunHesapla();
        }

        private void cmbSinavYili_SelectedIndexChanged(object sender, EventArgs e)
        {
            KalanGunHesapla();
        }

        private void KalanGunHesapla()
        {
            if (cmbSinavYili.SelectedItem == null) return;
            int yil = int.Parse(cmbSinavYili.SelectedItem.ToString());

            // Senin orijinal ayarladığın 6. aya (Haziran) geri alındı!
            DateTime sinavTarihi = new DateTime(yil, 6, 1);
            int kalanGun = (sinavTarihi - DateTime.Now.Date).Days;
            lblKalanGun.Text = kalanGun > 0
                ? $"Sınava yaklaşık {kalanGun} gün kaldı 🎯"
                : "Bu yılın sınavı geçti.";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (cmbDersler.SelectedItem == null) return;

            string ders = cmbDersler.SelectedItem.ToString();
            int yeniSaat = (int)nudCalisma.Value;
            int yeniTest = (int)nudTestAdet.Value;

            bool dersBulundu = false;

            // 1. Tabloda var mı diye bakıyoruz
            foreach (DataGridViewRow row in dgvHedefler.Rows)
            {
                if (row.Cells["Ders"].Value?.ToString() == ders)
                {
                    string mevcutSaatStr = row.Cells["Saat"].Value?.ToString().Replace(" saat", "") ?? "0";
                    if (int.TryParse(mevcutSaatStr, out int mevcutSaat))
                    {
                        int toplamSaat = mevcutSaat + yeniSaat;
                        if (toplamSaat > 16) toplamSaat = 16;
                        row.Cells["Saat"].Value = $"{toplamSaat} saat";
                    }

                    int mevcutTest = Convert.ToInt32(row.Cells["GunlukTest"].Value);
                    row.Cells["GunlukTest"].Value = mevcutTest + yeniTest;

                    dersBulundu = true;
                    break;
                }
            }

            // 2. Yoksa yeni ekliyoruz
            if (!dersBulundu)
            {
                dgvHedefler.Rows.Add(ders, $"{yeniSaat} saat", yeniTest);
            }

            dgvHedefler.ClearSelection();

            // 3. EFSANE DOKUNUŞ: Her ekleme/güncelleme sonrası arka planda SESSİZCE dosyaya kaydet!
            VerileriDosyayaKaydet();
        }
            
            
        

        private void VerileriDosyayaKaydet()
        {
            if (cmbSinavYili.SelectedItem == null) return;

            try
            {
                using (StreamWriter sw = new StreamWriter(dosyaYolu))
                {
                    sw.WriteLine($"{cmbSinavYili.SelectedItem};{nudCalisma.Value}");

                    foreach (DataGridViewRow row in dgvHedefler.Rows)
                    {
                        if (row.Cells["Ders"].Value != null)
                        {
                            string ders = row.Cells["Ders"].Value.ToString();
                            string saat = row.Cells["Saat"].Value?.ToString() ?? "0 saat";
                            string test = row.Cells["GunlukTest"].Value?.ToString() ?? "0";
                            sw.WriteLine($"{ders};{saat};{test}");
                        }
                    }
                }
            }
            catch { }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            if (dgvHedefler.Rows.Count > 0 && dgvHedefler.SelectedRows.Count > 0)
            {
                dgvHedefler.Rows.Remove(dgvHedefler.SelectedRows[0]);
                dgvHedefler.ClearSelection();

                // Sildikten sonra da dosyadan kalıcı olarak uçurmak için sessizce kaydet!
                VerileriDosyayaKaydet();
            }
            else
            {
                MessageBox.Show("Lütfen tablodan silmek istediğiniz dersi seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void FormHedef_FormClosing(object sender, FormClosingEventArgs e)
        {
            VerileriDosyayaKaydet();
        }

        private void YukleKayitliHedefler()
        {
            if (File.Exists(dosyaYolu))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(dosyaYolu))
                    {
                        string ilkSatir = sr.ReadLine();
                        if (ilkSatir != null)
                        {
                            string[] ayarlar = ilkSatir.Split(';');
                            if (ayarlar.Length == 2)
                            {
                                if (cmbSinavYili.Items.Contains(ayarlar[0]))
                                    cmbSinavYili.SelectedItem = ayarlar[0];

                                if (int.TryParse(ayarlar[1], out int saat) && saat >= 1 && saat <= 16)
                                    nudCalisma.Value = saat;
                            }
                        }

                        string satir;
                        dgvHedefler.Rows.Clear();
                        while ((satir = sr.ReadLine()) != null)
                        {
                            string[] hucreler = satir.Split(';');
                            if (hucreler.Length == 3)
                            {
                                dgvHedefler.Rows.Add(hucreler[0], hucreler[1], hucreler[2]);
                            }
                        }
                        dgvHedefler.ClearSelection(); // Yükleme sonrası seçimi sıfırla
                    }
                }
                catch { }
            }
        }
    }
}