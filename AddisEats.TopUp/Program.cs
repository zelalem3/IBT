using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter customer name: ");
        string name = Console.ReadLine();

        Console.Write("Enter mobile network (Ethio Telecom or Safaricom): ");
        string network = Console.ReadLine()?.Trim();

        Console.Write("Enter top-up amount in ETB: ");
        string amountInput = Console.ReadLine();

        if (!decimal.TryParse(amountInput, out decimal amount))
        {
            Console.WriteLine("Error: Invalid number format. Please enter a valid number.");
            return;
        }

        if (amount <= 0 || amount > 5000m)
        {
            Console.WriteLine("Error: Amount must be greater than 0 and cannot exceed 5,000 ETB.");
            return;
        }

        decimal bonusPercentage = network switch
        {
            "Ethio Telecom" => 0.05m,
            "Safaricom" => 0.03m,
            _ => 0.00m
        };

        decimal baseBonus = amount * bonusPercentage;

        decimal extraBonus = amount >= 1000m ? 20.00m : 0.00m;
        decimal totalBonus = baseBonus + extraBonus;
        decimal finalCredit = amount + totalBonus;

        Console.WriteLine("\n=================================");
        Console.WriteLine("          RECEIPT OUTPUT         ");
        Console.WriteLine("=================================");
        Console.WriteLine($"{"Name:",-15} {name}");
        Console.WriteLine($"{"Network:",-15} {network}");
        Console.WriteLine($"{"Amount:",-15} {amount,10:N2} ETB");
        Console.WriteLine($"{"Bonus:",-15} {totalBonus,10:N2} ETB");
        Console.WriteLine($"{"Final Credit:",-15} {finalCredit,10:N2} ETB");
        Console.WriteLine("=================================");
    }
}