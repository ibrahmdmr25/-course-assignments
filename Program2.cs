using System;
class Program
{
static void Main()
{
   //Üçgene ait üç kenar ölçüsü giriniz
   Console.WriteLine("Birinci kenar bilgisini giriniz:");
   int kenar1 = Convert.ToInt16(Console.ReadLine());
   Console.WriteLine("İkinci kenar bilgisini giriniz:");
   int kenar2 = Convert.ToInt16(Console.ReadLine());
   Console.WriteLine("Üçüncü kenar bilgisini giriniz:");
   int kenar3 = Convert.ToInt16(Console.ReadLine());

   //Verilen bilgilerle üçgenin çevresinİ hesapla
   int toplam =  kenar1 + kenar2 + kenar3;

   //Bir kenar bilgisi giriniz 
   Console.WriteLine("Kenar bilgisini giriniz: ");
   int kenar = Convert.ToInt16(Console.ReadLine());

   //Verilen bilgiyle karenin alanını hesapla
   int toplam2 = kenar*kenar;
   
   //Verilen bilgileri ekrana yazdır 
    Console.WriteLine("Üçgenin çevresi : " + toplam);
    Console.WriteLine("Karenin alanı : " + toplam2);
}
}
