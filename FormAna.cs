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
            MessageBox.Show("Hedeflerim formu yakında!");
        }
    }
}