using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DgsTakipSistemi_DGSTS_
{
    public partial class FormCalisma : Form
    {
        public FormCalisma()
        {
            InitializeComponent();
            this.Load += FormCalisma_Load;
            cmbDers.SelectedIndexChanged += CmbDers_SelectedIndexChanged;

        }
        private void CmbDers_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbKonu.Items.Clear();
           

            if (cmbDers.SelectedItem == null) return;

            string ders = cmbDers.SelectedItem.ToString();

            if (ders == "Matematik")
            {
                cmbKonu.Items.Add("Genel Çalışma");
                cmbKonu.Items.Add("Temel Kavramlar");
                cmbKonu.Items.Add("Sayı Basamakları");
                cmbKonu.Items.Add("Bölme ve Bölünebilme");
                cmbKonu.Items.Add("Asal Sayılar, EBOB - EKOK");
                cmbKonu.Items.Add("Rasyonel ve Ondalık Sayılar");
                cmbKonu.Items.Add("Basit Eşitsizlikler");
                cmbKonu.Items.Add("Mutlak Değer");
                cmbKonu.Items.Add("Üslü Sayılar");
                cmbKonu.Items.Add("Köklü Sayılar");
                cmbKonu.Items.Add("Çarpanlara Ayırma");
                cmbKonu.Items.Add("Oran - Orantı");
                cmbKonu.Items.Add("Denklem Çözme");
                cmbKonu.Items.Add("Sayı ve Kesir Problemleri");
                cmbKonu.Items.Add("Yaş Problemleri");
                cmbKonu.Items.Add("Yüzde, Kâr-Zarar Problemleri");
                cmbKonu.Items.Add("Karışım Problemleri");
                cmbKonu.Items.Add("İşçi Problemleri");
                cmbKonu.Items.Add("Hareket Problemleri");
                cmbKonu.Items.Add("Grafik Problemleri");
                cmbKonu.Items.Add("Kümeler ve Kartezyen Çarpım");
                cmbKonu.Items.Add("Fonksiyonlar");
                cmbKonu.Items.Add("Permütasyon, Kombinasyon ve Olasılık");
                cmbKonu.Items.Add("Sayısal Mantık");
            }
            else if (ders == "Geometri")
            {
                cmbKonu.Items.Add("Genel Çalışma");
                cmbKonu.Items.Add("Geometrik Kavramlar ve Açılar");
                cmbKonu.Items.Add("Üçgenler");
                cmbKonu.Items.Add("Çokgenler ve Dörtgenler");
                cmbKonu.Items.Add("Çember ve Daire");
                cmbKonu.Items.Add("Katı Cisimler");
                cmbKonu.Items.Add("Analitik Geometri");
            }
            else
            {
                cmbKonu.Items.Add("Genel Çalışma");
                cmbKonu.Items.Add("Sözcükte Anlam");
                cmbKonu.Items.Add("Cümlede Anlam");
                cmbKonu.Items.Add("Paragraf Bilgisi");
                cmbKonu.Items.Add("Anlatım Bozuklukları");
                cmbKonu.Items.Add("Sözel Mantık");
            }
           

            cmbKonu.SelectedIndex = 0;
        }
        private void FormCalisma_Load(object sender, EventArgs e)
        {
            TemaHelper.TemaUygula(this);
            ListeyiYukle();
        }

        private void ListeyiYukle()
        {
            dgvCalismalar.Rows.Clear();
            dgvCalismalar.Columns.Clear();

            dgvCalismalar.Columns.Add("Tarih", "Tarih");
            dgvCalismalar.Columns.Add("Ders", "Ders");
            dgvCalismalar.Columns.Add("Konu", "Konu");
            dgvCalismalar.Columns.Add("Saat", "Saat");
            dgvCalismalar.Columns.Add("Not", "Not");

            dgvCalismalar.Columns["Tarih"].Width = 100;
            dgvCalismalar.Columns["Ders"].Width = 120;
            dgvCalismalar.Columns["Konu"].Width = 230;
            dgvCalismalar.Columns["Saat"].Width = 60;
            dgvCalismalar.Columns["Not"].Width = 200;

            List<string> satirlar = FileHelper.SatirlariOku(FileHelper.CalismaPath);
            foreach (string satir in satirlar)
            {
                string[] parcalar = satir.Split('|');
                if (parcalar.Length >= 5)
                    dgvCalismalar.Rows.Add(parcalar[0], parcalar[1], parcalar[2], parcalar[3], parcalar[4]);
            }
        }

       
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvCalismalar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz satırı seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Önce satırı ekrandaki tablodan (DataGridView) siliyoruz
            dgvCalismalar.Rows.Remove(dgvCalismalar.SelectedRows[0]);
            dgvCalismalar.ClearSelection();

            // 2. KURŞUN GEÇİRMEZ TAKTİK: Tablonun GÜNCEL halini al, dosyayı tamamen EZİP baştan yaz!
            // (StreamWriter'daki 'false' parametresi dosyanın içini tamamen temizleyip baştan yazar)
            using (StreamWriter sw = new StreamWriter(FileHelper.CalismaPath, false))
            {
                foreach (DataGridViewRow row in dgvCalismalar.Rows)
                {
                    // Eğer satır boş değilse dosyaya yaz
                    if (row.Cells[0].Value != null)
                    {
                        string guncelSatir = $"{row.Cells[0].Value}|{row.Cells[1].Value}|{row.Cells[2].Value}|{row.Cells[3].Value}|{row.Cells[4].Value}";
                        sw.WriteLine(guncelSatir);
                    }
                }
            }

            MessageBox.Show("Kayıt başarıyla silindi ve dosya güncellendi! 🗑️", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnKaydet_Click_1(object sender, EventArgs e)
        {
            if (cmbDers.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen ders seçin!", "Uyarı");
                return;
            }

            string tarih = dtpTarih.Value.ToString("yyyy-MM-dd");
            string ders = cmbDers.SelectedItem.ToString();
            string konu = cmbKonu.SelectedItem.ToString();
            string saat = nudSaat.Value.ToString("0.0");
            string not = txtNot.Text.Trim().Replace("|", "-");

            string satir = $"{tarih}|{ders}|{konu}|{saat}|{not}";
            FileHelper.SatirEkle(FileHelper.CalismaPath, satir);

            txtNot.Clear();
            nudSaat.Value = 1;
            cmbDers.SelectedIndex = -1;
            cmbKonu.SelectedIndex = -1;

            ListeyiYukle();
            MessageBox.Show("Kaydedildi!", "Bilgi");
        }
    }
}