using System;

class Program
{
    static void Main()
    {
        // Kullanıcıdan iki sayı al
        Console.WriteLine("Birinci sayıyı giriniz: ");
        int sayi1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("İkinci sayıyı giriniz: ");
        int sayi2 = Convert.ToInt32(Console.ReadLine());

        // İki sayıyı topla 
        int toplam = sayi1 + sayi2;
        
        // Sonucu ekrana yazdır
        Console.WriteLine("Toplam: " + toplam/2);
    }
}

