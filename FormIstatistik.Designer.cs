namespace DgsTakipSistemi_DGSTS_
{
    partial class FormIstatistik
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chartCalisma = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartDeneme = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)chartCalisma).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartDeneme).BeginInit();
            SuspendLayout();
            // 
            // chartCalisma
            // 
            chartArea3.Name = "ChartArea1";
            chartCalisma.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chartCalisma.Legends.Add(legend3);
            chartCalisma.Location = new Point(12, 12);
            chartCalisma.Name = "chartCalisma";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            chartCalisma.Series.Add(series3);
            chartCalisma.Size = new Size(356, 240);
            chartCalisma.TabIndex = 0;
            chartCalisma.Text = "chart1";
            // 
            // chartDeneme
            // 
            chartArea4.Name = "ChartArea1";
            chartDeneme.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            chartDeneme.Legends.Add(legend4);
            chartDeneme.Location = new Point(413, 12);
            chartDeneme.Name = "chartDeneme";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            chartDeneme.Series.Add(series4);
            chartDeneme.Size = new Size(375, 240);
            chartDeneme.TabIndex = 1;
            chartDeneme.Text = "chart2";
            // 
            // FormIstatistik
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(chartDeneme);
            Controls.Add(chartCalisma);
            Name = "FormIstatistik";
            Text = "FormIstatistik";
            ((System.ComponentModel.ISupportInitialize)chartCalisma).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartDeneme).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartCalisma;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDeneme;
    }
}