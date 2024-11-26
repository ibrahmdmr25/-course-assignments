using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> ogrenciListe = new List<string> { "Ahmet", "Mehmet" };
        int ogrencisayi = ogrenciListe.Count;

        Console.WriteLine("Geziye katılacak öğrencilerin listesini yönetmek için:");
        Console.WriteLine("1 - Yeni öğrenci ekle");
        Console.WriteLine("2 - Toplam eklenen öğrenci sayısını gör");
        Console.WriteLine("3 - Aracı kontrol et");
        Console.WriteLine("0 - Programdan çık");

        while (true)
        {
            Console.WriteLine("\nBir işlem seçin:");
            int karar = Convert.ToInt32(Console.ReadLine());

            switch (karar)
            {
                case 1:
                    Console.WriteLine("Eklemek istediğiniz öğrencinin adını yazın:");
                    string yeniOgrenci = Console.ReadLine();
                    ogrenciListe.Add(yeniOgrenci);
                    ogrencisayi++;
                    Console.WriteLine($"{yeniOgrenci} listeye eklendi.");
                    break;

                case 2:
                    Console.WriteLine($"Toplam eklenen öğrenci sayısı: {ogrencisayi}");
                    Console.WriteLine("Öğrenciler:");
                    foreach (var ogrenci in ogrenciListe)
                    {
                        Console.WriteLine("- " + ogrenci);
                    }
                    break;

                case 3:
                    Console.WriteLine("Araç kapasitesini girin:");
                    int kapasite = Convert.ToInt32(Console.ReadLine());

                    if (ogrencisayi <= kapasite)
                    {
                        Console.WriteLine("Tüm öğrenciler araca sığabilir.");
                    }
                    else
                    {
                        Console.WriteLine($"Aracın kapasitesi yetersiz! {ogrencisayi - kapasite} kişi dışarıda kalacak.");
                    }
                    break;

                case 0:
                    Console.WriteLine("Programdan çıkılıyor...");
                    return;

                default:
                    Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyin.");
                    break;
            }
        }
    }
}