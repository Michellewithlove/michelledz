using System;

class EquationSolver
{
    static void Main()
    {
        Console.WriteLine("Введите коэффициенты для уравнения вида ax^2 + bx + c = 0:");

        Console.Write("a = ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("b = ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("c = ");
        double c = Convert.ToDouble(Console.ReadLine());

        // Рассмотрим различные случаи решения
        if (a == 0 && b == 0)
        {
            if (c == 0)
            {
                Console.WriteLine("Уравнение имеет бесконечное количество решений :D");
            }
            else
            {
                Console.WriteLine("Уравнение не имеет решений :(");
            }
        }
        else if (a == 0)
        {
            // Решаем линейное уравнение bx + c = 0
            double x = -c / b;
            Console.WriteLine($"Линейное уравнение. Решение: x = {x:F4}");
        }
        else
        {
            // Находим решение квадратного уравнения
            double discriminant = b * b - 4 * a * c;
            Console.WriteLine($"Дискриминант: D = {discriminant:F4}");

            if (discriminant > 0)
            {
                // Найдем два различных корня
                double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                Console.WriteLine($"Уравнение имеет два корня: x1 = {root1:F4}, x2 = {root2:F4}");
            }
            else if (discriminant == 0)
            {
                // Один корень
                double root = -b / (2 * a);
                Console.WriteLine($"Уравнение имеет один корень: x = {root:F4}");
            }
            else
            {
                // Нет вещественных корней
                Console.WriteLine("Уравнение не имеет вещественных корней.");
            }
        }
    }
}