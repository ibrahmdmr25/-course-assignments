using System;

class Program
{
    static void Main()
    {
        Console.Write("Bir sayı girin: ");
        int sayi = int.Parse(Console.ReadLine());
        int toplam = 0;

        for (int i = 1; i <= sayi; i++)
        {
            toplam += i;
        }

        Console.WriteLine($"{sayi}  Sayıların toplamı: {toplam}");
    }
}
        
