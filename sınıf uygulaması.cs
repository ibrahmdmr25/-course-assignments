using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class ogretmen
{
    public string Isim { get; set; }
    public List<string> Dersler { get; set; }

    public ogretmen(string isim)
    {
        Isim = isim;
        Dersler = new List<string>();
    }

    public void DersEkle(string ders)
    {
        Dersler.Add(ders);
    }

    public void DersProgramiYazdir()
    {
        Console.WriteLine($"Hoca {Isim} tarafından verilen dersler:");
        foreach (var ders in Dersler)
        {
            Console.WriteLine($"- {ders}");
        }
        Console.WriteLine($"Toplam ders sayısı: {Dersler.Count}");
    }
}

class Ogrenci
{
    public string Isim { get; set; }
    public List<string> Dersler { get; set; }

    public Ogrenci(string isim)
    {
        Isim = isim;
        Dersler = new List<string>();
    }

    public void DersEkle(string ders)
    {
        Dersler.Add(ders);
    }

    public void DersProgramiYazdir()
    {
        Console.WriteLine($"Öğrenci {Isim} tarafından alınan dersler:");
        foreach (var ders in Dersler)
        {
            Console.WriteLine($"- {ders}");
        }
        Console.WriteLine($"Toplam ders sayısı: {Dersler.Count}");
    }
}

class Sinif
{
    public string SinifAdi { get; set; }
    public List<string> Dersler { get; set; }

    public Sinif(string sinifAdi)
    {
        SinifAdi = sinifAdi;
        Dersler = new List<string>();
    }

    public void DersEkle(string ders)
    {
        Dersler.Add(ders);
    }

    public void DersProgramiYazdir()
    {
        Console.WriteLine($"Sınıf {SinifAdi} için ders programı:");
        foreach (var ders in Dersler)
        {
            Console.WriteLine($"- {ders}");
        }
        Console.WriteLine($"Toplam ders sayısı: {Dersler.Count}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Başta kullanıcıya kim olduğunu soruyoruz
        Console.WriteLine("Kim olduğunuzu seçin: Öğretmen, Öğrenci, Sınıf");
        string rol = Console.ReadLine().ToLower();

        if (rol == "Öğretmen")
        {
            ogretmen hoca = new ogretmen("Arman Atalar");
            hoca.DersEkle("Algoritma ve programlama");
            hoca.DersEkle("Yazılım tasarım mimarileri");
            hoca.DersProgramiYazdir();
        }
        else if (rol == "ogrenci")
        {
            Ogrenci ogrenci = new Ogrenci("İbrahim");
            ogrenci.DersEkle("Algoritma");
            ogrenci.DersEkle("Matematik");
            ogrenci.DersProgramiYazdir();
        }
        else if (rol == "sınıf")
        {
            Sinif sinif = new Sinif("Bilgisayar programcılığı");
            sinif.DersEkle("Algoritma ve programlama");
            sinif.DersEkle("Matematik");
            sinif.DersEkle("Yaılım tasarım mimarileri");
            sinif.DersEkle("Ofis yazılımları");
            sinif.DersEkle("Temel elektronik");
            sinif.DersProgramiYazdir();
        }
        else
        {
            Console.WriteLine("Geçersiz seçim. Lütfen 'Öğretmen', 'Öğrenci' veya 'Sınıf' giriniz.");
        }

        Console.ReadKey();
    }
}
