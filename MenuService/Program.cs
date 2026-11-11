using System;
using System.Collections.Generic;
using System.Linq;

public record MenuItem(int Id, string Name, string Category, decimal Price);

class Program
{
    static void Main(string[] args)
    {
        List<MenuItem> myMenuItems = new List<MenuItem>
        {
            new MenuItem(1, "Burger", "Food", 10.5m),
            new MenuItem(2, "Pizza", "Food", 15.0m),
            new MenuItem(3, "Coke", "Drink", 2.5m),
            new MenuItem(4, "Water", "Drink", 1.0m),
            new MenuItem(5, "Salad", "Food", 8.0m),
            new MenuItem(6, "Fries", "Food", 3.5m),
            new MenuItem(7, "Ice Cream", "Dessert", 4.0m)
        };

        Console.WriteLine("=== 1. WHERE Clause (Food Items) ===");
        var foodItems = myMenuItems.Where(i => i.Category == "Food").ToList();
        foreach (var item in foodItems)
        {
            Console.WriteLine($"Food Item Name: {item.Name}");
        }

        Console.WriteLine("\n=== 2. SELECT Clause (Prices) ===");
        var prices = myMenuItems.Select(i => i.Price).ToList();
        foreach (var price in prices)
        {
            Console.WriteLine($"Price: {price:C}");
        }

        Console.WriteLine("\n=== 3. ANY Clause ===");
        bool hasExpensiveItems = myMenuItems.Any(i => i.Price > 10.0m);
        Console.WriteLine($"Has expensive items (> 10.0): {hasExpensiveItems}");

        Console.WriteLine("\n=== 4. ALL Clause ===");
        bool allItemsAreExpensive = myMenuItems.All(i => i.Price > 10.0m);
        Console.WriteLine($"All items are expensive (> 10.0): {allItemsAreExpensive}");

        Console.WriteLine("\n=== 5. FIRSTORDEFAULT Clause ===");
        var expensiveItem = myMenuItems.FirstOrDefault(i => i.Price > 20.0m);

        if (expensiveItem != null)
        {
            Console.WriteLine($"First item with price greater than 20.0: {expensiveItem.Name}");
        }
        else
        {
            Console.WriteLine("No item found with price greater than 20.0.");
        }

        Console.WriteLine("\n=== 6. ORDERBY and ORDERBYDESCENDING Clause ===");
        var orderedByPrice = myMenuItems.OrderBy(i => i.Price).ToList();
        foreach (var item in orderedByPrice)
        {
            Console.WriteLine($"Ordered by Price (Asc): {item.Name} - {item.Price:C}");
        }

        Console.WriteLine("--------------------------------------------------");

        var orderedByDesPrice = myMenuItems.OrderByDescending(i => i.Price).ToList();
        foreach (var item in orderedByDesPrice)
        {
            Console.WriteLine($"Ordered by Price (Desc): {item.Name} - {item.Price:C}");
        }

        Console.WriteLine("\n=== 7. SKIP and TAKE (Pagination) ===");
        var theLast4Items = myMenuItems.Skip(3).Take(4).ToList();
        Console.WriteLine($"Count of subset items (Skipping 3, Taking 4): {theLast4Items.Count}");
        foreach (var item in theLast4Items)
        {
            Console.WriteLine($"- {item.Name} ({item.Category}): {item.Price:C}");
        }

        Console.WriteLine("\n=== 8. SUM and AVERAGE Clause ===");
        var sumOfPrices = myMenuItems.Sum(i => i.Price);
        var averageOfPrices = myMenuItems.Average(i => i.Price);
        Console.WriteLine($"Sum of Prices: {sumOfPrices:C}, Average of Prices: {averageOfPrices:C}");
    }
}