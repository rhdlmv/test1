using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Distinct
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new List<Book>()
            {
                new Book { Name = "bookName1",Serial= "serial1",Price= 5.5d},
                new Book { Name = "bookName1",Serial= "serial2",Price= 6.5d},
                new Book { Name = "bookName1",Serial= "serial3",Price= 7.5d},
                new Book { Name = "bookName2",Serial= "serial4",Price= 8.5d},
                new Book { Name = "bookName3",Serial= "serial5",Price= 9.5d},
                new Book { Name = "bookName4",Serial= "serial6",Price= 10.5d},
                new Book { Name = "bookName4",Serial= "serial7",Price= 10.5d},
            };

            foreach (var item in books.Distinct(b => b.Name))
            {
                Console.WriteLine("Name = {0}, Serial = {1}, Privce = {2}", item.Name, item.Serial, item.Price);
            }
            Console.ReadKey();
        }
    }

    public static class Extension
    {
        public static IEnumerable<TSource> Distinct<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                var elementValue = keySelector(element);
                if (seenKeys.Add(elementValue))
                {
                    yield return element;
                }
            }
        }
    }

    public class Book
    {
        public string Name { get; set; }
        public string Serial { get; set; }
        public double Price { get; set; }
    }
}
