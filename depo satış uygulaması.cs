using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SatisDepoUygulamasi
{
    public class Urun
    {
        public string Ad { get; set; }
        public decimal AlisFiyati { get; set; }
        public int Miktar { get; set; }
    }

    public class Borc
    {
        public decimal Miktar { get; set; }
        public DateTime AlisTarihi { get; set; }
        public DateTime GeriOdemeTarihi { get; set; }
    }

    class Program
    {
        static List<Urun> urunler = new List<Urun>();
        static List<Borc> borclar = new List<Borc>();
        static decimal kasa = 3500; 
        static string veriDosyasi = "veriler.txt";
        static string faturaKlasoru = "Faturalar";

        static void Main(string[] args)
        {
            YedektenYukle();
            Directory.CreateDirectory(faturaKlasoru);
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("=== Satış Depo Uygulaması ===");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("1. Ürün Ekle");
                Console.WriteLine("2. Ürünleri Listele");
                Console.WriteLine("3. Kasa Durumunu Görter");
                Console.WriteLine("4. Borç Durumunu Göster");
                Console.WriteLine("5. Çıkış ve Kaydet");
                Console.ResetColor();
                Console.Write("Lütfen bir işlem seçiniz: ");
                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1": UrunEkle(); break;
                    case "2": UrunleriListele(); break;
                    case "3": KasaDurumuGoster(); break;
                    case "4": BorcDurumuGoster(); break;
                    case "5": CikisYap(); return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Hatalı seçim! Geçerli bir seçenek giriniz.");
                        Console.ResetColor();
                        break;
                }

                Console.WriteLine("Devam etmek için herhangi bir tuşa basın...");
                Console.ReadKey();
            }
        }
        static void YedektenYukle()
        {
            if (File.Exists(veriDosyasi))
            {
                var satirlar = File.ReadAllLines(veriDosyasi);
                foreach (var satir in satirlar)
                {
                    var veriler = satir.Split(',');
                    if (veriler[0] == "Urun")
                    {
                        urunler.Add(new Urun
                        {
                            Ad = veriler[1],
                            AlisFiyati = decimal.Parse(veriler[2]),
                            Miktar = int.Parse(veriler[3])
                        });
                    }
                    else if (veriler[0] == "Borc")
                    {
                        borclar.Add(new Borc
                        {
                            Miktar = decimal.Parse(veriler[1]),
                            AlisTarihi = DateTime.Parse(veriler[2]),
                            GeriOdemeTarihi = DateTime.Parse(veriler[3])
                        });
                    }
                    else if (veriler[0] == "Kasa")
                    {
                        kasa = decimal.Parse(veriler[1]);
                    }
                }
            }
        }
        static void YedekKaydet()
        {
            var satirlar = new List<string>();
            foreach (var urun in urunler)
            {
                satirlar.Add($"Urun,{urun.Ad},{urun.AlisFiyati},{urun.Miktar}");
            }
            foreach (var borc in borclar)
            {
                satirlar.Add($"Borc,{borc.Miktar},{borc.AlisTarihi},{borc.GeriOdemeTarihi}");
            }
            satirlar.Add($"Kasa,{kasa}");
            File.WriteAllLines(veriDosyasi, satirlar);
        }
        static void UrunEkle()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=== Ürün Ekle ===");
            Console.ResetColor();
            var yeniUrun = new Urun();
            Console.Write("Ürün adı: ");
            yeniUrun.Ad = Console.ReadLine();
            Console.Write("Alış fiyatı: ");
            yeniUrun.AlisFiyati = decimal.Parse(Console.ReadLine());
            Console.Write("Miktar: ");
            yeniUrun.Miktar = int.Parse(Console.ReadLine());

            if (kasa >= yeniUrun.AlisFiyati * yeniUrun.Miktar)
            {
                kasa -= yeniUrun.AlisFiyati * yeniUrun.Miktar;
                urunler.Add(yeniUrun);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Ürün başarıyla eklendi!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Yeterli paranız yok. Borç almayı düşünün.");
                Console.ResetColor();
            }
        }
        static void UrunleriListele()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=== Ürün Listesi ===");
            Console.ResetColor();

            if (urunler.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Henüz ürün eklenmedi.");
                Console.ResetColor();
                return;
            }
            foreach (var urun in urunler)
            {
                Console.WriteLine($"Ad: {urun.Ad}, Alış Fiyatı: {urun.AlisFiyati:C}, Miktar: {urun.Miktar}");
            }
        }
        static void KasaDurumuGoster()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=== Kasa Durumu ===");
            Console.ResetColor();

            Console.WriteLine($"Şuan ki kasa bakiyesi: {kasa:C}");
        }
        static void BorcDurumuGoster()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=== Borç Durumu ===");
            Console.ResetColor();
            if (borclar.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Henüz borç alınmadı.");
                Console.ResetColor();
                return;
            }
            foreach (var borc in borclar)
            {
                Console.WriteLine($"Borc: {borc.Miktar:C}, Geri Ödeme Tarihi: {borc.GeriOdemeTarihi.ToShortDateString()}");
            }
        }
        static void CikisYap()
        {
            YedekKaydet();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Çıkılıyor... Değişiklikler kaydedildi.");
            Console.ResetColor();
        }
    }
}