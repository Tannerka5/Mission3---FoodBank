using System;
using System.Collections.Generic;

class Program
{
    // Global inventory list shared by all methods
    static List<FoodItem> inventory = new List<FoodItem>();

    static void Main(string[] args)
    {
        bool running = true;  // Controls menu loop

        // Main menu loop
        while (running)
        {
            Console.WriteLine("\n=== Food Bank Inventory System ===");
            Console.WriteLine("1. Add Food Item");
            Console.WriteLine("2. Delete Food Item");
            Console.WriteLine("3. Print List of Current Food Items");
            Console.WriteLine("4. Exit Program");
            Console.Write("Enter your choice (1-4): ");

            string choice = Console.ReadLine();  // Read menu choice

            // Handle user choice
            switch (choice)
            {
                case "1":
                    AddItem();     // Add new item
                    break;
                case "2":
                    DeleteItem();  // Remove existing item
                    break;
                case "3":
                    PrintItems();  // Show all items
                    break;
                case "4":
                    running = false;  // End loop and exit
                    Console.WriteLine("Exiting program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    break;
            }
        }
    }

    // Ask user for item info and add to inventory
    static void AddItem()
    {
        Console.Write("Enter food name: ");
        string name = Console.ReadLine();

        Console.Write("Enter category (e.g., Canned Goods, Dairy, Produce): ");
        string category = Console.ReadLine();

        int quantity = 0;
        bool validQuantity = false;

        // Validate quantity input
        while (!validQuantity)
        {
            Console.Write("Enter quantity: ");
            string quantityInput = Console.ReadLine();

            if (int.TryParse(quantityInput, out quantity) && quantity >= 0)
            {
                validQuantity = true;
            }
            else
            {
                Console.WriteLine("Invalid quantity. Please enter a non-negative number.");
            }
        }

        DateTime expirationDate = DateTime.MinValue;
        bool validDate = false;

        // Validate expiration date input
        while (!validDate)
        {
            Console.Write("Enter expiration date (MM/DD/YYYY): ");
            string dateInput = Console.ReadLine();

            if (DateTime.TryParse(dateInput, out expirationDate))
            {
                validDate = true;
            }
            else
            {
                Console.WriteLine("Invalid date format. Please use MM/DD/YYYY.");
            }
        }

        // Create new FoodItem and add to inventory
        FoodItem newItem = new FoodItem(name, category, quantity, expirationDate);
        inventory.Add(newItem);
        Console.WriteLine("Food item added successfully!");
    }

    // Delete an item selected by index
    static void DeleteItem()
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("No items in inventory to delete.");
            return;  // Exit if list is empty
        }

        Console.WriteLine("\nCurrent Inventory:");

        // Print each item with number
        for (int i = 0; i < inventory.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {inventory[i]}");
        }

        int itemNumber = 0;
        bool validChoice = false;

        // Validate which item to delete
        while (!validChoice)
        {
            Console.Write($"Enter the number of the item to delete (1-{inventory.Count}): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out itemNumber) && itemNumber >= 1 && itemNumber <= inventory.Count)
            {
                validChoice = true;
            }
            else
            {
                Console.WriteLine($"Invalid choice. Please enter a number between 1 and {inventory.Count}.");
            }
        }

        // Remove chosen item (convert 1-based to 0-based index)
        inventory.RemoveAt(itemNumber - 1);
        Console.WriteLine("Food item deleted successfully!");
    }

    // Print all current items in inventory
    static void PrintItems()
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("\nInventory is empty.");
            return;
        }

        Console.WriteLine("\n=== Current Food Inventory ===");

        for (int i = 0; i < inventory.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {inventory[i]}");
        }
    }
}
