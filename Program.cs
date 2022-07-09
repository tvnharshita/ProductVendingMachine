using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVendingMachine
{
    public class Program
    {
        public static readonly decimal colaPrice = 1.00m;
        public static readonly decimal chipsPrice = 0.50m;
        public static readonly decimal candyPrice = 0.65m;
        public static readonly decimal nickelPrice = 0.05m;
        public static readonly decimal dimePrice = 0.10m;
        public static readonly decimal quarterPrice = 0.25m;
        public static List<decimal> coinReturn = new List<decimal>();
        public static decimal initialSum = 0.00m;
        static void Main(string[] args)
        {
            Console.WriteLine("Product 1 - cola - $1.00");
            Console.WriteLine("Product 2 - chips - $0.50");
            Console.WriteLine("Product 3 - candy - $0.65");
            Console.WriteLine("Current Sum : "+initialSum);
            CallInsertCoin();            
            Console.ReadLine();
            Console.Read();
        }

        public static void CallInsertCoin()
        {
            int flagInsert = 0;
            while (flagInsert == 0)
            {
                flagInsert = InsertCoin(ref initialSum);
            }
            ChooseProduct(ref initialSum);
        }
        public static int InsertCoin(ref decimal totalSum)
        {
            decimal enteredAmount = default(decimal);
                Console.WriteLine("Please insert coin");
            try
            {
                enteredAmount = Convert.ToDecimal(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter valid decimal value");
            }
            if (enteredAmount != nickelPrice && enteredAmount != dimePrice && enteredAmount != quarterPrice)
            {
                coinReturn.Add(enteredAmount);
                Console.WriteLine("Returned coins are - ");
                foreach (decimal dec in coinReturn)
                {
                    Console.WriteLine(dec + ", ");
                }
                return 0;
            }
            else
            {
                totalSum += enteredAmount;
                Console.WriteLine("Current Sum : " + totalSum);
                return 1;
            }
        }

        public static void ChooseProduct(ref decimal initialSum)
        {
            Console.WriteLine("Please select Product..!!");
            string prodInput = Console.ReadLine();
            string prodLower = prodInput.ToLower();
            //string caseName= Enum.GetName(typeof(Products), prodLower);
            switch (prodLower)
            {
                case "cola": if(initialSum >= colaPrice)
                    {
                        Console.WriteLine("Thank you for purchasing product");
                        initialSum = 0.00m;
                    }
                    else
                    {
                        Console.WriteLine("You have insufficient balance to buy the product");
                        CallInsertCoin();
                    }
                    break;
                case "chips": if(initialSum >= chipsPrice)
                    {
                        Console.WriteLine("Thank you for purchasing product");
                        initialSum = 0.00m;
                    }
                    else
                    {
                        Console.WriteLine("You have insufficient balance to buy the product");
                        CallInsertCoin();
                    }
                    break;
                case "candy": if(initialSum>= candyPrice)
                    {
                        Console.WriteLine("Thank you for purchasing product");
                        initialSum = 0.00m;
                    }
                    else
                    {
                        Console.WriteLine("You have insufficient balance to buy the product");
                        CallInsertCoin();
                    }
                    break;
                default: Console.WriteLine("Please select from the products displayed");
                    break;
            }
        }
    }
}
