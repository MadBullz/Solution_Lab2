using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Q1
{
    class Product
    {
        private string id;
        private string name;
        private float price;

        public string Name { get => name; set => name = value; }
        public float Price { get => price; set => price = value; }
        public string ID { get => id; set => id = value; }

        public override string ToString()
        {
            return $"{ID} - {Name} - {Price}";
        }
    }
    class Program
    {

        public static void Add(IList<Product> list)
        {
            Console.Write("Enter ID: ");
            string aID = Console.ReadLine();
            Console.Write("Enter Name: ");
            string aName = Console.ReadLine();
            Console.Write("Enter Price: ");
            float aPrice = float.Parse(Console.ReadLine());
            Product p = new Product();
            p.ID = aID;
            p.Name = aName;
            p.Price = aPrice;
            list.Add(p);
        }

        public static void Display(IList<Product> list)
        {
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        public static void Search(IList<Product> list)
        {
            Console.Write("Enter a product name to search:");
            string query = Console.ReadLine();
            List<Product> p = new List<Product>();
            foreach (var item in list)
            {
                if (item.Name.StartsWith(query.ToUpper()) || item.Name.StartsWith(query.ToLower()))
                {
                    p.Add(item);
                }
            }
            if (p.Count > 0)
            {
                foreach(var item in p)
                {
                    Console.WriteLine(item);
                }
            }
            else Console.WriteLine("Product not exist");
            Console.ReadLine();
        }

        public static void Sort(IList<Product> list)
        {
            List<Product> sortedProduct = list.OrderBy(product => product.Name).ThenByDescending(product => product.Price).ToList();
            foreach (var item in sortedProduct)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            IList<Product> list = new List<Product>() { 
                new Product(){ ID = "P002", Name="IPhone", Price=1200},
                new Product(){ ID = "P003", Name="Galaxy Note 10", Price=1000f},
                new Product(){ ID = "P001", Name="IPhone", Price=1500.5f}
            };
            while (true)
            {
                Console.Clear();
                Console.WriteLine("------- PRODUCT MANAGEMENT -------");
                Console.WriteLine("1. Add                                ");
                Console.WriteLine("2. Display                            ");
                Console.WriteLine("3. Sort                               ");
                Console.WriteLine("4. Search                             ");
                Console.WriteLine("5. Exit                               ");
                Console.Write("Enter a option: ");
                int option;
                int.TryParse(Console.ReadLine(), out option);

                switch (option)
                {
                    case 1:
                        Add(list); break;
                    case 2:
                        Console.WriteLine("Product list:");
                        Display(list); 
                        break;
                    case 3:
                        Sort(list); 
                        break;
                    case 4:
                        Search(list); 
                        break;
                    case 5:
                        System.Environment.Exit(0); 
                        break;
                    default:
                        Console.WriteLine("Try again!"); 
                        break;
                }
            }
        }
    }
}
