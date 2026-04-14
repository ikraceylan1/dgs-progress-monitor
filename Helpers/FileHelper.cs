using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace DgsTakipSistemi_DGSTS_
{
    public static class FileHelper
    {
        private static string AppFolder = Application.StartupPath;
        public static string CalismaPath = Path.Combine(AppFolder, "Data", "calismalar.txt");
        public static string DenemePath = Path.Combine(AppFolder, "Data", "denemeler.txt");
        public static string HedefPath = Path.Combine(AppFolder, "Data", "hedefler.txt");

        public static void DosyalariHazirla()
        {
            string dataKlasor = Path.Combine(AppFolder, "Data");
            if (!Directory.Exists(dataKlasor))
                Directory.CreateDirectory(dataKlasor);

            if (!File.Exists(CalismaPath)) File.Create(CalismaPath).Close();
            if (!File.Exists(DenemePath)) File.Create(DenemePath).Close();
            if (!File.Exists(HedefPath)) File.WriteAllText(HedefPath, "6.0|40.0|55.0");
        }

        public static List<string> SatirlariOku(string dosyaYolu)
        {
            var liste = new List<string>();
            if (!File.Exists(dosyaYolu)) return liste;
            foreach (string satir in File.ReadAllLines(dosyaYolu))
                if (!string.IsNullOrWhiteSpace(satir))
                    liste.Add(satir.Trim());
            return liste;
        }

        public static void SatirEkle(string dosyaYolu, string yeniSatir)
        {
            File.AppendAllText(dosyaYolu, yeniSatir + Environment.NewLine);
        }

        public static void SatirSil(string dosyaYolu, string silinecekSatir)
        {
            var satirlar = SatirlariOku(dosyaYolu);
            satirlar.Remove(silinecekSatir);
            File.WriteAllLines(dosyaYolu, satirlar);
        }

        public static void TumunuYaz(string dosyaYolu, List<string> satirlar)
        {
            File.WriteAllLines(dosyaYolu, satirlar);
        }
    }
}