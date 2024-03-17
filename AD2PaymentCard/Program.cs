using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD2PaymentCard
{
    internal class Program
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public class Book
        {
            public string Title { get; set; }
            public int Pages { get; set; }
            public int PublicationYear { get; set; }
        }


        static void Main(string[] args)
        {
            try
            {
                log.Info("Start of Payment Block");
                PaymentCard card = new PaymentCard(100);
                Console.WriteLine(card);


                //card.EatLunch();
                Console.WriteLine(card);

                //card.DrinkCoffee();
                Console.WriteLine(card);

                card.AddMoney(49.99);
                Console.WriteLine(card);

                card.AddMoney(10000.0);
                Console.WriteLine(card);

                card.AddMoney(-10);
                Console.WriteLine(card);

                log.Info("End of Payment Block");
                log.Info("Start of Books Block");
                List<Book> books = new List<Book>();

                Console.WriteLine("Enter book information or leave the Title empty to finish:");

                while (true)
                {
                    Console.Write("Enter the Name of Book (Title): ");
                    string title = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(title))
                        break;

                    Console.Write("Enter number of Pages: ");
                    int pages = int.Parse(Console.ReadLine());

                    Console.Write("Publication year: ");
                    int year = int.Parse(Console.ReadLine());

                    books.Add(new Book { Title = title, Pages = pages, PublicationYear = year });
                }

                Console.WriteLine("Information stored successfully.");

                // Writing book information to CSV file
                string filePath = "books.csv";
                WriteToCsv(books, filePath);
                Console.WriteLine($"Book information written to {filePath}");

                // Reading book information from CSV file
                List<Book> booksFromFile = ReadFromCsv(filePath);

                // Asking user what information to print
                Console.Write("What information will be printed? ");
                string choice = Console.ReadLine();

                switch (choice.ToLower())
                {
                    case "everything":
                        foreach (var book in booksFromFile)
                        {
                            Console.WriteLine($"{book.Title}, {book.Pages} pages, {book.PublicationYear}");
                        }
                        break;
                    case "title":
                        foreach (var book in booksFromFile)
                        {
                            Console.WriteLine(book.Title);
                        }
                        break;
                    default:
                        break;

                }
                Console.ReadLine();
            } catch (Exception ex)
            {
                log.Error("Program has encountered error" + ex.Message);
            }


        }

        static void WriteToCsv(List<Book> books, string filePath)
        {
            log.Info("Inside of Write Csv Block");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var book in books)
                {
                    writer.WriteLine($"{book.Title},{book.Pages},{book.PublicationYear}");
                }
            }
        }

        static List<Book> ReadFromCsv(string filePath)
        {
            log.Info("Inside of Read Csv Block");
            List<Book> books = new List<Book>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    Book book = new Book
                    {
                        Title = parts[0],
                        Pages = int.Parse(parts[1]),
                        PublicationYear = int.Parse(parts[2])
                    };
                    books.Add(book);
                }
            }

            return books;
        }
    
    }
}
