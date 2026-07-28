using System;

class ExpenseTracker
{
    static void Main()
    {
        double totalExpense = 0;

        try
        {
            Console.Write("Enter the number of expenses: ");
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.Write("Enter expense " + i + ": ");
                double expense = Convert.ToDouble(Console.ReadLine());

                if (expense < 0)
                {
                    throw new Exception("Expense cannot be negative.");
                }

                totalExpense += expense;
            }


            Console.WriteLine("\nTotal Expense: " + totalExpense);
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter a valid number.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Error: Number is too large.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        Console.WriteLine("\nProgram Ended.");
        Console.ReadLine();
    }
}
