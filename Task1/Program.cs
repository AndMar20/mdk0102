using System;

public class Program1
{
    public static void PrimeNumber(string[] args)
    {
        Console.Write("Введите натуральное число: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int result))
        {
            if (result <= 1)
                Console.WriteLine("Число не является простым.");
            else
            {
                if (result <= 3)
                    Console.WriteLine("Число является простым.");
                else
                {
                    if (result % 2 == 0 || result % 3 == 0)
                        Console.WriteLine("Число не является простым.");
                    else
                    {
                        for (int i = 5; i * 1 <= result; i += 6)
                        {
                            if (result % i == 0 || result % (i + 2) == 0)
                                Console.WriteLine("Число не является простым.");
                        }
                    }
                }
            }
        }
        else
            Console.WriteLine("Число является простым.");
    }
}
