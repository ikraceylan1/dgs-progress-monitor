#  DGS Takip Sistemi (Masaüstü Uygulaması)

Dikey Geçiş Sınavı (DGS) hazırlık sürecini daha verimli, planlı ve düzenli bir şekilde yönetmek amacıyla geliştirilmiş, Windows tabanlı bir masaüstü takip uygulamasıdır.

Bu proje; adayların çalışma performanslarını analiz etmelerini, eksiklerini görmelerini ve sınav gününe kadar olan süreci tek bir panelden takip etmelerini sağlar.

##  Öne Çıkan Özellikler (Ne İşe Yarar?)

Uygulama, bir DGS adayının ihtiyaç duyabileceği temel takip mekanizmalarını tek bir çatıda toplar:

- **Soru ve Konu Takip Paneli:** Matematik, Geometri ve Türkçe derslerine ait konuların ilerleme durumunu kaydeder. Hangi konudan kaç soru çözüldüğünü listeler.
- **Deneme Sınavı Analizi:** Çözülen DGS denemelerinin netlerini (Doğru/Yanlış sayılarını) hafızada tutarak adayın gelişimini izlemesini sağlar.
- **DGS Puan Hesaplama:** Önlisans Başarı Puanı (ÖBP) ve deneme netlerini kullanarak DGS Sayısal, Sözel ve Eşit Ağırlık puanlarını yaklaşık olarak hesaplar.
- **Sayaç ve Geri Sayım:** Sınava kaç gün kaldığını gösteren dinamik bir geri sayım aracı içerir.

##  Teknik Detaylar ve Kullanılan Teknolojiler

Projenin geliştirilmesinde aşağıdaki teknolojiler ve yöntemler kullanılmıştır:

- **Geliştirme Ortamı:** Visual Studio
- **Programlama Dili:** C#
- **Arayüz Teknolojisi:** .NET Windows Forms (Kullanıcı dostu ve sade bir yönetim paneli tasarımı)
- **Veri Saklama Yöntemi:** Dosya Tabanlı Depolama (Kullanıcının girdiği deneme sonuçları ve konu verileri, yerel metin dosyalarında (`.txt`) güvenli ve hızlı bir şekilde saklanır ve okunur).

##  Proje Yapısı ve Ekranlar

Uygulama, nesne yönelimli programlama (OOP) prensiplerine uygun olarak modüler form yapısıyla tasarlanmıştır:

- **Ana Ekran Formu:** Karşılama ekranı 
- **Günlük Çalışma Formu:** Ders içeriklerinin ve soru sayılarının yönetildiği alan.
- **Deneme Analiz Formu:** Geçmiş deneme sonuçlarının listelendiği arayüz ve ÖBP tabanlı puan simülasyonunu yapan hesaplama motoru.
- **İstatistik Formu:** Deneme ve çalışmalarınızı grafikler şeklinde görebildiğiniz bir form.
- **Hedef Formu:**  Geri sayım sayacının ve genel hedef durumun belirlendiği ekran.
 

---
💡 *Not: Bu uygulama; dosya yönetimi (I/O işlemleri), formlar arası veri aktarımı ve Windows Forms arayüz tasarım pratiklerini gerçek bir probleme çözüm üreterek pekiştirmek amacıyla geliştirilmiştir.*
