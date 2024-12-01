using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Book> books = new List<Book>();
    static List<Rental> rentals = new List<Rental>();
    static void Main(string[] args)
    {
        while (true)
        {
            ShowHeader("KÜTÜPHANE PROGRAMI");
            Console.WriteLine("1. Kitap Ekle");
            Console.WriteLine("2. Kitap Kirala");
            Console.WriteLine("3. Kitap İade");
            Console.WriteLine("4. Kitap Arama");
            Console.WriteLine("5. Raporlama");
            Console.WriteLine("H. Yardım");
            Console.WriteLine("0. Çıkış");
            Console.Write("Seçiminizi yapın: ");
            string choice = Console.ReadLine();
            switch (choice.ToUpper())
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    RentBook();
                    break;
                case "3":
                    ReturnBook();
                    break;
                case "4":
                    SearchBook();
                    break;
                case "5":
                    GenerateReport();
                    break;
                case "H":
                    ShowHelp();
                    break;
                case "0":
                    ShowMessage("Çıkış yapılıyor...", ConsoleColor.Yellow);
                    return;
                default:
                    ShowMessage("Geçersiz seçim. Lütfen 1-5 arası bir seçenek girin.", ConsoleColor.Red);
                    break;
            }
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
    static void ShowHelp()
    {
        ShowHeader("YARDIM MENÜSÜ");
        Console.WriteLine("1. Kitap Ekleme: Kitap adı, yazar adı, yayınevi ve stok bilgisi girilerek kitap eklenir.");
        Console.WriteLine("2. Kitap Kiralama: Mevcut kitaplardan birini seçip kaç gün kiralayacağınız belirlenir.");
        Console.WriteLine("3. Kitap İade: Kiralanan kitapları iade edebilirsiniz.");
        Console.WriteLine("4. Arama: Kitap adı ya da yazar adı ile kitap arayabilirsiniz.");
        Console.WriteLine("5. Raporlama: Kitaplar ve kiralama raporları görüntülenir.");
        Console.WriteLine("6. Günlük Kiralama Bedeli: 5 TL'dir.");
        Console.WriteLine("7. Maksimum Kiralama Süresi: 7 gündür.");
    }
    static void AddBook()
    {
        ShowHeader("KITAP EKLE");
        Console.Write("Kitap Adı: ");
        string title = Console.ReadLine();
        Console.Write("Yazar Adı: ");
        string author = Console.ReadLine();
        Console.Write("Yayın Yılı: ");
        int year = int.Parse(Console.ReadLine());
        Console.Write("Stok Miktarı: ");
        int stock = int.Parse(Console.ReadLine());
        var existingBook = books.FirstOrDefault(b => b.Title == title && b.Author == author);
        if (existingBook != null)
        {
            existingBook.Stock += stock;
            ShowMessage("Mevcut kitap bulundu. Stok artırıldı.", ConsoleColor.Green);
        }
        else
        {
            books.Add(new Book { Title = title, Author = author, Year = year, Stock = stock });
            ShowMessage("Yeni kitap başarıyla eklendi.", ConsoleColor.Green);
        }
    }
    static void RentBook()
    {
        ShowHeader("KİTAP KİRALA");
        if (!books.Any())
        {
            ShowMessage("Kütüphanede kitap bulunmamaktadır.", ConsoleColor.Red);
            return;
        }
        Console.WriteLine("Mevcut Kitaplar:");
        for (int i = 0; i < books.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {books[i].Title} - {books[i].Author} (Stok: {books[i].Stock})");
        }
        Console.Write("Kiralamak istediğiniz kitabın numarasını seçin: ");
        int bookIndex = int.Parse(Console.ReadLine()) - 1;
        if (bookIndex < 0 || bookIndex >= books.Count || books[bookIndex].Stock <= 0)
        {
            ShowMessage("Geçersiz seçim veya stok yetersiz.", ConsoleColor.Red);
            return;
        }
        Console.Write("Kaç gün kiralamak istiyorsunuz? (Maksimum 7 gün): ");
        int days = int.Parse(Console.ReadLine());
        if (days > 7)
        {
            ShowMessage("Kiralama süresi maksimum 7 gün olmalıdır.", ConsoleColor.Red);
            return;
        }
        decimal cost = days * 5;
        Console.Write($"Bütçeniz nedir? (Gerekli ücret: {cost} TL): ");
        decimal budget = decimal.Parse(Console.ReadLine());
        if (budget < cost)
        {
            ShowMessage("Bütçeniz yetersiz. Kiralama işlemi yapılamadı.", ConsoleColor.Red);
            return;
        }
        Console.Write("Adınız: ");
        string userName = Console.ReadLine();
        books[bookIndex].Stock--;
        rentals.Add(new Rental
        {
            UserName = userName,
            RentedBook = books[bookIndex],
            RentDate = DateTime.Now,
            ReturnDate = DateTime.Now.AddDays(days)
        });
        ShowMessage($"Kitap başarıyla kiralandı. Ödediğiniz tutar: {cost} TL. İade tarihi: {DateTime.Now.AddDays(days):yyyy-MM-dd}.", ConsoleColor.Green);
    }
    static void ReturnBook()
    {
        ShowHeader("KİTAP İADE");
        Console.Write("Adınız: ");
        string userName = Console.ReadLine();
        var userRentals = rentals.Where(r => r.UserName == userName).ToList();
        if (!userRentals.Any())
        {
            ShowMessage("Bu isimle kiralanmış bir kitap bulunamadı.", ConsoleColor.Red);
            return;
        }
        Console.WriteLine("Kiralanan Kitaplar:");
        for (int i = 0; i < userRentals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {userRentals[i].RentedBook.Title} (İade Tarihi: {userRentals[i].ReturnDate:yyyy-MM-dd})");
        }
        Console.Write("İade etmek istediğiniz kitabın numarasını seçin: ");
        int rentalIndex = int.Parse(Console.ReadLine()) - 1;
        if (rentalIndex < 0 || rentalIndex >= userRentals.Count)
        {
            ShowMessage("Geçersiz seçim. Lütfen tekrar deneyin.", ConsoleColor.Red);
            return;
        }
        var rental = userRentals[rentalIndex];
        rental.RentedBook.Stock++;
        rentals.Remove(rental);
        ShowMessage("Kitap başarıyla iade edildi.", ConsoleColor.Green);
    }
    static void SearchBook()
    {
        ShowHeader("KİTAP ARAMA");
        Console.WriteLine("1. Kitap Adına Göre");
        Console.WriteLine("2. Yazar Adına Göre");
        Console.Write("Seçiminiz: ");
        if (!int.TryParse(Console.ReadLine(), out int searchType) || (searchType != 1 && searchType != 2))
        {
            ShowMessage("Geçersiz seçim. Lütfen 1 veya 2 girin.", ConsoleColor.Red);
            return;
        }
        Console.Write("Arama terimini girin: ");
        string searchTerm = Console.ReadLine();
        var results = searchType == 1
            ? books.Where(b => b.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList()
            : books.Where(b => b.Author.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();

        if (!results.Any())
        {
            ShowMessage("Hiçbir sonuç bulunamadı.", ConsoleColor.Red);
            return;
        }
        Console.WriteLine("Arama Sonuçları:");
        foreach (var book in results)
        {
            Console.WriteLine($"{book.Title} - {book.Author} ({book.Year}) | Stok: {book.Stock}");
        }
    }
    static void GenerateReport()
    {
        ShowHeader("RAPORLAMA");
        Console.WriteLine("1. Tüm Kitaplar");
        Console.WriteLine("2. Kirada Olan Kitaplar");
        Console.Write("Seçiminizi yapın: ");
        string choice = Console.ReadLine();
        if (choice == "1")
        {
            Console.WriteLine("Tüm Kitaplar:");
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} - {book.Author} ({book.Year}) | Stok: {book.Stock}");
            }
        }
        else if (choice == "2")
        {
            Console.WriteLine("Kirada Olan Kitaplar:");
            foreach (var rental in rentals)
            {
                Console.WriteLine($"{rental.RentedBook.Title} - {rental.UserName} (İade Tarihi: {rental.ReturnDate:yyyy-MM-dd})");
            }
        }
        else
        {
            ShowMessage("Geçersiz seçim. Lütfen 1 veya 2 girin.", ConsoleColor.Red);
        }
    }
    static void ShowHeader(string title)
    {
        Console.Clear();
        Console.WriteLine(title);
        Console.WriteLine(new string('=', title.Length));
    }
    static void ShowMessage(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}
class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public int Stock { get; set; }
}
class Rental
{
    public string UserName { get; set; }
    public Book RentedBook { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime ReturnDate { get; set; }
}   