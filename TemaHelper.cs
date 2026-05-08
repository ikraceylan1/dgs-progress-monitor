using System;
using System.Drawing;
using System.Windows.Forms;

namespace DgsTakipSistemi_DGSTS_
{
    public static class TemaHelper
    {
        
        public static bool KaranlikModAcik = true;

        public static void TemaUygula(Form form)
        {
            if (KaranlikModAcik)
            {
                form.BackColor = Color.FromArgb(30, 30, 30); 
                form.ForeColor = Color.White;
            }
            else
            {
                form.BackColor = Color.FromArgb(236, 236, 241);
                form.ForeColor = Color.FromArgb(45, 45, 48);
            }
            KontrolleriBoyayalim(form.Controls, KaranlikModAcik);
        }

        private static void KontrolleriBoyayalim(Control.ControlCollection kontroller, bool karanlikMi)
        {
            foreach (Control ctrl in kontroller)
            {
                
                if (ctrl is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = karanlikMi ? Color.White : Color.FromArgb(200, 200, 200);
                    btn.ForeColor = Color.White;

                    switch (btn.Name)
                    {
                        case "btnGunluk":
                            btn.BackColor = karanlikMi ? Color.FromArgb(64, 158, 117) : Color.FromArgb(102, 187, 106);
                            break;
                        case "btnDeneme":
                            btn.BackColor = karanlikMi ? Color.FromArgb(208, 90, 48) : Color.FromArgb(239, 108, 0);
                            break;
                        case "btnGrafik":
                            btn.BackColor = karanlikMi ? Color.FromArgb(56, 139, 213) : Color.FromArgb(66, 165, 245);
                            break;
                        case "btnHedef":
                            btn.BackColor = karanlikMi ? Color.FromArgb(180, 83, 156) : Color.FromArgb(171, 71, 188);
                            break;
                        default:
                            btn.BackColor = karanlikMi ? Color.FromArgb(63, 63, 70) : Color.Silver;
                            break;
                        case "btnKaydet": 
                            btn.BackColor = karanlikMi ? Color.FromArgb(46, 125, 50) : Color.FromArgb(76, 175, 80);  
                            break;
                        case "btnSil":    
                            btn.BackColor = karanlikMi ? Color.FromArgb(191, 54, 12) : Color.FromArgb(230, 81, 0); 
                            break;
                        case "btnEkle": 
                            btn.BackColor = karanlikMi ? Color.FromArgb(46, 125, 50) : Color.FromArgb(76, 175, 80); 
                            break;
                        case "btnIptal":    
                            btn.BackColor = karanlikMi ? Color.FromArgb(191, 54, 12) : Color.FromArgb(230, 81, 0); 
                            break;
                    }
                }
               
                else if (ctrl is TextBox || ctrl is NumericUpDown || ctrl is DateTimePicker)
                {
                    ctrl.BackColor = karanlikMi ? Color.FromArgb(45, 45, 48) : Color.White;
                    ctrl.ForeColor = karanlikMi ? Color.White : Color.Black;
                }
                // --- Tablo (DataGridView) ---
                else if (ctrl is DataGridView dgv)
                {
                    dgv.BackgroundColor = karanlikMi ? Color.FromArgb(30, 30, 30) : Color.White;
                    dgv.GridColor = karanlikMi ? Color.FromArgb(60, 60, 60) : Color.LightGray;
                    dgv.EnableHeadersVisualStyles = false;
                    dgv.BorderStyle = BorderStyle.None; 

                    
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = karanlikMi ? Color.FromArgb(45, 45, 48) : Color.LightGray;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = karanlikMi ? Color.White : Color.Black;

                   
                    dgv.RowHeadersDefaultCellStyle.BackColor = karanlikMi ? Color.FromArgb(45, 45, 48) : Color.LightGray;

                    // Hücre içi renkler
                    dgv.DefaultCellStyle.BackColor = karanlikMi ? Color.FromArgb(35, 35, 35) : Color.White;
                    dgv.DefaultCellStyle.ForeColor = karanlikMi ? Color.White : Color.Black;

                    // Satır seçilince başka renk yansın
                    dgv.DefaultCellStyle.SelectionBackColor = karanlikMi ? Color.FromArgb(64, 158, 117) : SystemColors.Highlight;
                    dgv.DefaultCellStyle.SelectionForeColor = Color.White;
                }
                
                else if (ctrl is CheckBox chk)
                {

                    chk.BackColor = karanlikMi ? Color.FromArgb(30, 30, 30) : Color.FromArgb(236, 236, 241);
                    chk.ForeColor = karanlikMi ? Color.White : Color.Black;
                }
                else if (ctrl is Label lbl)
                {
                  
                    lbl.ForeColor = karanlikMi ? Color.White : Color.Black;
                }
            }
        }
    }
}