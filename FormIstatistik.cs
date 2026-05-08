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
            chartDeneme.ChartAreas[0].AxisX.Title = "Deneme Sırası"; 
            chartDeneme.ChartAreas[0].AxisX.Interval = 1;            
            chartDeneme.ChartAreas[0].AxisX.LabelStyle.IsStaggered = false; 

            
            chartDeneme.ChartAreas[0].AxisY.Title = "DGS Puanı";

            
            Series saySeries = new Series("DGS-SAY");
            saySeries.ChartType = SeriesChartType.Spline; 
            saySeries.BorderWidth = 3;                   
            saySeries.Color = Color.DodgerBlue;           
            saySeries.MarkerStyle = MarkerStyle.Circle;  
            saySeries.MarkerSize = 8;

            
            Series sozSeries = new Series("DGS-SÖZ");
            sozSeries.ChartType = SeriesChartType.Spline;
            sozSeries.BorderWidth = 3;
            sozSeries.Color = Color.Tomato;              
            sozSeries.MarkerStyle = MarkerStyle.Circle;
            sozSeries.MarkerSize = 8;

           
            Series eaSeries = new Series("DGS-EA");
            eaSeries.ChartType = SeriesChartType.Spline;
            eaSeries.BorderWidth = 3;
            eaSeries.Color = Color.SeaGreen;              
            eaSeries.MarkerStyle = MarkerStyle.Circle;
            eaSeries.MarkerSize = 8;

            List<string> satirlar = FileHelper.SatirlariOku(FileHelper.DenemePath);
            int i = 1;

            foreach (string satir in satirlar)
            {
                string[] p = satir.Split('|');

                
                if (p.Length >= 13)
                {
                    double say = 0, soz = 0, ea = 0;

                   
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