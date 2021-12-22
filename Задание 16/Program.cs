using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web

namespace Задание_16
{
    class Program
    {
        static void Main(string[] args)
        {
            string Jsonstring = " {\"code\":\"575\":\"name\":\"кофе\":\"price\":\"200\"} ";
            Product product = JsonSerializer.Deserialize<Product>(Jsonstring);
            int[,] Product = new int[5, 3];
            for (int i = 1; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Product[5, 3] = (i + j) % 2;
                    Console.Write("{0,5 } ", Product[5, 3]);
                }

                foreach (var max in product)
                {

                }
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };

                Console.ReadKey();
            }
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
