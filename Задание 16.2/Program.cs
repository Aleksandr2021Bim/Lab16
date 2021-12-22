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

namespace Задание_16._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsontext = "";
            
            using (StreamReader sr = new StreamReader("../../../../../Products.joson"))
            {
                jsontext = sr.ReadToEnd();
            }

            Product[] products = JsonSerializer.Deserialize<Product[]>(jsontext);

            Product maxProduct = products[0];
            foreach (Product p in products)
            {
                if (p.Price > maxProduct.Price) maxProduct = p;
            }
            if (maxProduct != null)

                Console.WriteLine("Самый дорогой товар: {0} {1:f2}", maxProduct.Name, maxProduct.Price);
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
