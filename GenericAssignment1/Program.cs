using System;
using System.Collections.Generic;

namespace GenericAssignment1
{
   
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------Inventry Management System---------\n\n");
            var inventryList = new InventryList();
            while (true)
            {
                Console.WriteLine("Enter 1 for =>Print the total number of products in the list");
                Console.WriteLine("Enter 2 for =>Add The Product in the enventry system And Count the number in the list!");
                Console.WriteLine("Enter 3 for =>Print all the products of which have the type.");
                Console.WriteLine("Enter 4 for =>Remove the product by name which have quantity 0 And Count the number of the product in the list.");
                Console.WriteLine("Enter 5 for =>Add the product by quantity.");
                Console.WriteLine("Enter 6 for =>Buy the products.");
                Console.WriteLine("Enter Any other number to Exit");


                int query = int.Parse(Console.ReadLine());
               
                switch (query)
                {
                    case 1:
                        Console.WriteLine($"The number of the product in the List is = {inventryList.Count}\n");
                        break;
                    case 2:
                        var product = AddProduct();
                        inventryList.Add(product);
                        break;
                    case 3:
                        Console.WriteLine("Enter the type");
                        string type = Console.ReadLine();
                        var productsByTypes = inventryList.GetByType(type);
                        PrintProducts(productsByTypes);
                        break;
                    case 4:
                        Console.WriteLine("Enter the name of the product which you want to delete ");
                        string name = Console.ReadLine();
                        inventryList.Remove(name);
                        Console.WriteLine($"number of the products which has left {inventryList.Count}");
                        break;
                    case 5:
                        Console.WriteLine("Enter the name of the product");
                        string name2 = Console.ReadLine();
                        Console.WriteLine("Enter the quantity that you want to add!");
                        int quantity = int.Parse(Console.ReadLine());
                        int newQunatity = inventryList.Add(name2, quantity);
                        Console.WriteLine($"New quantity of the {name2} = {newQunatity}");
                        break;
                    case 6:
                        double totalPrice = buyProduct(inventryList);
                        int roundUp = (int)Math.Round(totalPrice);
                        Console.WriteLine($"Total Price is (in Round Figure) = {roundUp}\n");
                        break;
                    default:
                        System.Environment.Exit(0);
                        break;

                }
            }

        }

        private static double buyProduct(InventryList inventryList)
        {
            var isContinue = true;
            double ans = 0.0;
            while (isContinue)
            {
                Console.WriteLine("Enter the product name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the qunatity");
                int qunatity = int.Parse(Console.ReadLine());
                double buyPrice=inventryList.Buy(name, qunatity);
                if(buyPrice==-1)
                {
                    Console.WriteLine("Product not exist in the list");
                }
                else if(buyPrice==0)
                {
                    Console.WriteLine("you are buying more quantity !");
                }
                if(buyPrice>0)
                    ans += buyPrice;
                Console.WriteLine("Do you want to more buy Press Yes otherwise No");
                string yesOrNo = Console.ReadLine();
                if(yesOrNo.ToUpper()=="YES")
                {
                    isContinue = true;
                }
                else
                {
                    isContinue = false;
                }
            }
            return ans;
            
        }

        private static void PrintProducts(List<Product> products)
        {
            Console.WriteLine("List of products\n");
            Console.WriteLine("Name,  Price,  Quantity, Type");
            foreach(var product in products)
            {
                Console.WriteLine($"{product.Name}, {product.Price}, {product.Quantity}, {product.Type}");
            }
            Console.WriteLine();
            return;
        }

        private static Product AddProduct()
        {
            Console.WriteLine("Enter the Name of the Product");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the Price of the of the Product Per Kg");
            double price = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Quantity of the of the Product in Kg");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Type of the of the Product");
            string type = Console.ReadLine();
            var product = new Product();
            product.Name = name;
            product.Price = price;
            product.Quantity = quantity;
            product.Type = type;
            return product;

        }
        


    }
    
}
