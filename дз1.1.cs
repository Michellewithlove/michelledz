using System;

class MainProgram
{
    static void Main()
    {
        Console.WriteLine("Пожалуйста, введите натуральное число:");
        int upperLimit = int.Parse(Console.ReadLine());
        Console.WriteLine($"Простые числа до {upperLimit}:");

        for (int num = 2; num <= upperLimit; num++)
        {
            if (IsPrimeNumber(num))
            {
                Console.Write(num + " ");
            }
        }
        Console.WriteLine();
    }

    static bool IsPrimeNumber(int value)
    {
        if (value < 2) return false;
        for (int divisor = 2; divisor * divisor <= value; divisor++)
        {
            if (value % divisor == 0) return false;
        }
        return true;
    }
}