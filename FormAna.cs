namespace DgsTakipSistemi_DGSTS_
{
    public partial class FormAna : Form
    {
        public FormAna()
        {
            InitializeComponent();
            this.Load += FormAna_Load;
        }
        private void FormAna_Load(object sender, EventArgs e)
        {
            FileHelper.DosyalariHazirla();
        }
        private void btnGunluk_Click(object sender, EventArgs e)
        {
            FormCalisma fc = new FormCalisma();
            fc.Show();
        }

        private void btnDeneme_Click(object sender, EventArgs e)
        {
            FormDeneme fd = new FormDeneme();
            fd.Show();
        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {
            FormIstatistik fi = new FormIstatistik();
            fi.Show();
        }

        private void btnHedef_Click(object sender, EventArgs e)
        {
            FormHedef fh = new FormHedef();
            fh.Show();
        }

        private void chkTema_CheckedChanged(object sender, EventArgs e)
        {
            // 1. Hafızayı güncelle
            TemaHelper.KaranlikModAcik = chkTema.Checked;

            // 2. Kendi yazısını değiştir
            chkTema.Text = chkTema.Checked ? "🌙 Karanlık Mod" : "☀️ Aydınlık Mod";

            // 3. BÜYÜ BURADA: Sadece FormAna'yı değil, arka planda açık olan TÜM formları anında boya!
            foreach (Form acikForm in Application.OpenForms)
            {
                TemaHelper.TemaUygula(acikForm);
            }
        }
    }
}