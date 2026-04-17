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
            TemaHelper.TemaUygula(this);
            foreach (var denemeSerisi in chartDeneme.Series)
            {
                denemeSerisi.Points.Clear();
            }

            foreach (var calismaSerisi in chartCalisma.Series)
            {
                calismaSerisi.Points.Clear();
            }

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
            // X Ekseni (Yatay) Ayarları
            chartDeneme.ChartAreas[0].AxisX.Title = "Deneme Sırası"; // Sayıların ne olduğunu belirtelim
            chartDeneme.ChartAreas[0].AxisX.Interval = 1;            // Sayıları 1, 2, 3 diye atlamadan sırayla yaz
            chartDeneme.ChartAreas[0].AxisX.LabelStyle.IsStaggered = false; // Altlı üstlü zikzak yazmayı KAPAT!

            // Y Ekseni (Dikey) Ayarları
            chartDeneme.ChartAreas[0].AxisY.Title = "DGS Puanı";

            // 1. DGS-SAY (Sayısal) Serisi - PREMIUM MAKYAJ
            Series saySeries = new Series("DGS-SAY");
            saySeries.ChartType = SeriesChartType.Spline; // Keskin Zikzak yerine Yumuşak Dalga!
            saySeries.BorderWidth = 3;                    // Daha tok bir çizgi
            saySeries.Color = Color.DodgerBlue;           // Göz yormayan tatlı bir mavi
            saySeries.MarkerStyle = MarkerStyle.Circle;   // Veri noktalarına yuvarlak boncuklar
            saySeries.MarkerSize = 8;

            // 2. DGS-SÖZ (Sözel) Serisi - PREMIUM MAKYAJ
            Series sozSeries = new Series("DGS-SÖZ");
            sozSeries.ChartType = SeriesChartType.Spline;
            sozSeries.BorderWidth = 3;
            sozSeries.Color = Color.Tomato;               // Klasik kırmızı yerine modern kırmızı
            sozSeries.MarkerStyle = MarkerStyle.Circle;
            sozSeries.MarkerSize = 8;

            // 3. DGS-EA (Eşit Ağırlık) Serisi - PREMIUM MAKYAJ
            Series eaSeries = new Series("DGS-EA");
            eaSeries.ChartType = SeriesChartType.Spline;
            eaSeries.BorderWidth = 3;
            eaSeries.Color = Color.SeaGreen;              // Klasik yeşil yerine daha şık bir yeşil
            eaSeries.MarkerStyle = MarkerStyle.Circle;
            eaSeries.MarkerSize = 8;

            List<string> satirlar = FileHelper.SatirlariOku(FileHelper.DenemePath);
            int i = 1;

            foreach (string satir in satirlar)
            {
                string[] p = satir.Split('|');

                // BUG FİX 1: 0'dan 12'ye kadar tam 13 sütunumuz var, o yüzden en az 13 olmalı!
                if (p.Length >= 13)
                {
                    double say = 0, soz = 0, ea = 0;

                    // BUG FİX 2: Doğru Sütun Numaraları! (Puanlar 10, 11 ve 12. sırada)
                    double.TryParse(p[10].Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out say);
                    double.TryParse(p[11].Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out soz);
                    double.TryParse(p[12].Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out ea);

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