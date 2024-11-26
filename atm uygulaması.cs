using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("ATM sistemine hoşgeldiniz. Lütfen şifrenizi giriniz:");
        int sifre = Convert.ToInt32(Console.ReadLine());
        decimal bakiye = 3500m;
        bool devam = true;

        while (devam)
        {
            Console.WriteLine("\n1 - Bakiye Görüntüle");
            Console.WriteLine("2 - Para Çek");
            Console.WriteLine("3 - Para Yatırma");
            Console.WriteLine("4 - Çıkış");
            Console.Write("Bir seçenek seçin: ");
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    Console.WriteLine($"Bakiyeniz: {bakiye:C}");
                    break;

                case "2":
                    Console.Write("Çekmek istediğiniz tutarı girin: ");
                    decimal cekilecekMiktar = Convert.ToDecimal(Console.ReadLine());

                    if (cekilecekMiktar <= bakiye)
                    {
                        bakiye -= cekilecekMiktar;
                        Console.WriteLine($"Başarıyla {cekilecekMiktar:C} çektiniz. Kalan bakiyeniz: {bakiye:C}");
                    }
                    else
                    {
                        Console.WriteLine("Yetersiz bakiye!");
                    }
                    break;

                case "3":
                    Console.Write("Yatırmak istediğiniz tutarı giriniz: ");
                    decimal yatırılacaktutar = Convert.ToDecimal(Console.ReadLine());

                    if (yatırılacaktutar > 0)
                    {
                        bakiye += yatırılacaktutar;
                        Console.WriteLine($"Başarıyla {yatırılacaktutar:C} yatırdınız. Yeni bakiyeniz: {bakiye:C}");
                    }
                    else
                    {
                        Console.WriteLine("Geçerli bir tutar giriniz!");
                    }
                    break;

                case "4":
                    Console.WriteLine("Çıkış yapılıyor. İyi günler!");
                    devam = false;
                    break;

                default:
                    Console.WriteLine("Geçersiz bir seçenek girdiniz. Lütfen tekrar deneyin.");
                    break;
            }

            if (bakiye <= 0)
            {
                Console.WriteLine("\nBakiyeniz bitti! ATM'den çıkış yapılıyor.");
                devam = false;
            }
        }
    }
}
