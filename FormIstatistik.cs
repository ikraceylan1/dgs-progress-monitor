using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DgsTakipSistemi_DGSTS_
{
    public partial class FormIstatistik : Form
    {
        public FormIstatistik()
        {
            InitializeComponent();
            this.Load += FormIstatistik_Load;
        }

        private void FormIstatistik_Load(object sender, EventArgs e)
        {
            CalismaGrafiginiYukle();
            DenemeGrafiginiYukle();
        }

        private void CalismaGrafiginiYukle()
        {
            chartCalisma.Series.Clear();
            chartCalisma.Titles.Clear();
            chartCalisma.Titles.Add("Derse Göre Çalışma Süresi (Saat)");

            Series series = new Series("Çalışma");
            series.ChartType = SeriesChartType.Pie;

            Dictionary<string, double> dersSaatleri = new Dictionary<string, double>();

            List<string> satirlar = FileHelper.SatirlariOku(FileHelper.CalismaPath);
            foreach (string satir in satirlar)
            {
                string[] p = satir.Split('|');
                if (p.Length >= 4)
                {
                    string ders = p[1];
                    double saat = 0;
                    double.TryParse(p[3].Replace(",", "."), System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture, out saat);

                    if (dersSaatleri.ContainsKey(ders))
                        dersSaatleri[ders] += saat;
                    else
                        dersSaatleri[ders] = saat;
                }
            }

            foreach (var item in dersSaatleri)
            {
                series.Points.AddXY(item.Key, item.Value);
            }

            chartCalisma.Series.Add(series);
            chartCalisma.Series[0]["PieLabelStyle"] = "Outside";
        }

        private void DenemeGrafiginiYukle()
        {
            chartDeneme.Series.Clear();
            chartDeneme.Titles.Clear();
            chartDeneme.Titles.Add("Deneme Net Gelişimi");

            Series saySeries = new Series("DGS-SAY");
            saySeries.ChartType = SeriesChartType.Line;
            saySeries.BorderWidth = 2;
            saySeries.Color = Color.Blue;

            Series sozSeries = new Series("DGS-SÖZ");
            sozSeries.ChartType = SeriesChartType.Line;
            sozSeries.BorderWidth = 2;
            sozSeries.Color = Color.Red;

            Series eaSeries = new Series("DGS-EA");
            eaSeries.ChartType = SeriesChartType.Line;
            eaSeries.BorderWidth = 2;
            eaSeries.Color = Color.Green;

            List<string> satirlar = FileHelper.SatirlariOku(FileHelper.DenemePath);
            int i = 1;
            foreach (string satir in satirlar)
            {
                string[] p = satir.Split('|');
                if (p.Length >= 12)
                {
                    double say = 0, soz = 0, ea = 0;
                    double.TryParse(p[9].Replace(",", "."), System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture, out say);
                    double.TryParse(p[10].Replace(",", "."), System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture, out soz);
                    double.TryParse(p[11].Replace(",", "."), System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture, out ea);

                    saySeries.Points.AddXY(i, say);
                    sozSeries.Points.AddXY(i, soz);
                    eaSeries.Points.AddXY(i, ea);
                    i++;
                }
            }

            chartDeneme.Series.Add(saySeries);
            chartDeneme.Series.Add(sozSeries);
            chartDeneme.Series.Add(eaSeries);
        }
    }
}