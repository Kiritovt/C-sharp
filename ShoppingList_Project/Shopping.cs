using System;

public class Shop
{

    public static void Main(string[] args)
    {
        bool TurnOff = false;
        List<string> ShoppingList = new(); 
        while (!TurnOff)
        {
            Console.WriteLine("===== Shopping List =====");
            int Choice = ReadChoice("1. Add Product \n2. Show Product \n3. Remove Product \n0. Exit");


            switch (Choice)
            {
                case 1:
                    Console.WriteLine("Enter the product name:");
                    string? Product = Console.ReadLine();
                    while (true)
                    {
                        if (string.IsNullOrWhiteSpace(Product))
                        {
                            Console.WriteLine("There is no product name on the entered line, please Enter the Product name");
                            Product = Console.ReadLine();
                        }
                        else
                        {
                            ShoppingList.Add(Product);
                            Console.WriteLine("Product Added Successfully.");
                            break;
                        }
                    }
                    break;

                case 2:
                    Console.WriteLine("Shopping List:");
                    if (ShoppingList.Count == 0)
                    {
                        Console.WriteLine("The Shopping List is empty");
                    } else
                    {
                         for (int i = 0; i<ShoppingList.Count; i++)
                        {
                        
                        Console.WriteLine( i + 1 + ". " + ShoppingList[i]);
                    }
                    }
                    break;

                case 3:
                    if (ShoppingList.Count == 0)
                    {
                        Console.WriteLine("The Shopping List is empty");
                    }
                    else
                    {
                        int i = 1;
                        foreach (string item in ShoppingList)
                        {
                            Console.WriteLine($"{i}. {item}");
                            i++;
                        }
                        int ItemNumber = ReadChoice("Enter the product number to remove:");
                        while (true)
                        {
                            if (ItemNumber > ShoppingList.Count || ItemNumber < 0 || ItemNumber == 0)
                            {
                                Console.WriteLine("There are no Item on the selected number.");
                                ItemNumber = ReadChoice("Enter the product number to remove:");

                            }
                            else
                            {
                                String? ItemRemoved = ShoppingList[ItemNumber - 1];
                                ShoppingList.RemoveAt(ItemNumber - 1);
                                Console.WriteLine($"You have removed the Product {ItemRemoved} successfully from the Product List.");
                                break;
                            }
                        }
                    }
                    break;

                case 0:
                    TurnOff = true;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid menu choice.");
                    break;
            }
            

        }
    }
    private static int ReadChoice(string message)
    {
        while (true)
        {
            Console.WriteLine(message);
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }

}