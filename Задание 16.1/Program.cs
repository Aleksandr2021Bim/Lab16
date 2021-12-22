using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web;

namespace Задание_16._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello инженер! \nпопробуйте ввод товаров");
            
            Product[] products = new Product[5];
            for (int i = 0; i < 5; i++)
            {
                products[i] = new Product();
                Console.WriteLine("Введите код товара:");
                products[i].Code = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите название товара:");
                products[i].Name = Console.ReadLine();
                Console.WriteLine("Введите стоимость товара:");
                products[i].Price = Convert.ToInt32(Console.ReadLine());
            }

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            string outJs = JsonSerializer.Serialize(products, options);
            Console.WriteLine(outJs);

            // Для записи в текстовый файл используется класс StreamWriter 
            // ссылка //metanit.com/sharp/tutorial/5.5.php
            
            using (StreamWriter sw = new StreamWriter("../../../../../Products.joson")) 
            {
                sw.WriteLine(outJs);
            }

            Console.ReadKey();
        }
    }

    class Product
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }

    }
}
