using System;

class Program
{
    static void Main()
    {
        Console.Write("Пожалуйста, введите число n: ");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Последовательность вычислений для числа n: ");
        while (n != 1)
        {
            Console.WriteLine(n);
            if (n % 2 == 0) // Проверка, является ли число четным
            {
                n /= 2; // Деление на два, если число четное
            }
            else
            {
                n = 3 * n + 1; // Применение формулы для нечетного числа
            }
        }
        Console.WriteLine(1); // Печать конечного значения
    }
}