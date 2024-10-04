using System;

class Program
{
    static void Main()
    {
        // Adınızı giriniz
        Console.WriteLine("Adınızı giriniz: ");
        string adi1 = Console.ReadLine();

        // Soyadınızı giriniz
        Console.WriteLine("Soyadınızı giriniz: ");  
        string soyadi2 = Console.ReadLine();

        // Öğrenci numaranızı giriniz
        Console.WriteLine("Öğrenci numaranızı giriniz: ");
        int ogrencino = Convert.ToInt16(Console.ReadLine());  

        // Telefon numaranızı giriniz
        Console.WriteLine("Telefon numaranızı giriniz: "); 
        long telefon = Convert.ToInt64(Console.ReadLine()); 
       
        // Kullanıcıdan alınan bilgileri ekrana yazdır
        Console.WriteLine("Girdiğiniz Bilgiler:");
        Console.WriteLine("Adı: " + adi1);  
        Console.WriteLine("Soyadı: " + soyadi2);  
        Console.WriteLine("Öğrenci no: " + ogrencino);  
        Console.WriteLine("Telefon numaranız: " + telefon); 
    }
}
