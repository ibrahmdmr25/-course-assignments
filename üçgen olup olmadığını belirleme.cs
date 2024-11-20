using System;
internal class odev
{
static void Main()
{
//iki adet değer giriniz
Console.WriteLine("Birinci değeri giriniz:");
int sayi=Convert.ToInt16(Console.ReadLine());
Console.WriteLine("İkinci değeri giriniz:");
int sayi2=Convert.ToInt16(Console.ReadLine());

//İki sayıyı toplayınız
int toplam= sayi+sayi2;

//Toplama üçüncü bir sayı giriniz
Console.WriteLine("Üçüncü sayıyı giriniz:");
int sayi3=Convert.ToInt16(Console.ReadLine());
int toplam2=toplam+sayi3;

 // Toplam 180'e eşit mi kontrol ediyoruz.
 if (toplam2 != 180)
 {    
     Console.WriteLine("Üçgen Olamaz");
 }
else
 {
     Console.WriteLine("Bir üçgen olabilir.");
 }

}
}