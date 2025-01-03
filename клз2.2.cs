using System;
using System.Diagnostics;

class Program
{
    // Функция для вычисления факториала методом итерации
    static long CalculateFactorialIteratively(int n)
    {
        long factorial = 1;
        for (int i = 2; i <= n; i++)
            factorial *= i;
        return factorial;
    }

    // Функция для вычисления факториала методом рекурсии
    static long CalculateFactorialRecursively(int n)
    {
        if (n == 0 || n == 1)
            return 1;
        return n * CalculateFactorialRecursively(n - 1);
    }

    // Функция для вычисления чисел Фибоначчи методом итерации
    static long CalculateFibonacciIteratively(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;

        long firstPrevious = 1, secondPrevious = 0;
        for (int i = 2; i <= n; i++)
        {
            long current = firstPrevious + secondPrevious;
            secondPrevious = firstPrevious;
            firstPrevious = current;
        }
        return firstPrevious;
    }

    // Функция для вычисления чисел Фибоначчи методом рекурсии
    static long CalculateFibonacciRecursively(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;
        return CalculateFibonacciRecursively(n - 1) + CalculateFibonacciRecursively(n - 2);
    }

    static void Main()
    {
        int upperLimit = 35;  // Максимальное значение для проверки
        var stopwatch = new Stopwatch();

        Console.WriteLine("Сравнение времени выполнения для расчета факториала:");
        for (int i = 1; i <= upperLimit; i++)
        {
            // Измерение времени для итеративного расчета факториала
            stopwatch.Restart();
            CalculateFactorialIteratively(i);
            stopwatch.Stop();
            long iterativeTime = stopwatch.ElapsedMilliseconds;

            // Измерение времени для рекурсивного расчета факториала
            stopwatch.Restart();
            CalculateFactorialRecursively(i);
            stopwatch.Stop();
            long recursiveTime = stopwatch.ElapsedMilliseconds;

            Console.WriteLine($"n = {i}: Итеративный: {iterativeTime} мс, Рекурсивный: {recursiveTime} мс");
        }

        Console.WriteLine("\nСравнение времени выполнения для чисел Фибоначчи:");
        for (int i = 0; i <= upperLimit; i++)
        {
            // Измерение времени для итеративного расчета Фибоначчи
            stopwatch.Restart();
            CalculateFibonacciIteratively(i);
            stopwatch.Stop();
            long iterativeFibonacciTime = stopwatch.ElapsedMilliseconds;

            // Измерение времени для рекурсивного расчета Фибоначчи
            stopwatch.Restart();
            CalculateFibonacciRecursively(i);
            stopwatch.Stop();
            long recursiveFibonacciTime = stopwatch.ElapsedMilliseconds;

            Console.WriteLine($"n = {i}: Итеративный: {iterativeFibonacciTime} мс, Рекурсивный: {recursiveFibonacciTime} мс");
        }
    }
}