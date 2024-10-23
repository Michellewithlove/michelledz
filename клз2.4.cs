using System;

class Программа
{
    static void ОсновнойМетод(string[] аргументы)
    {
        Console.WriteLine("Пожалуйста, задайте размер массива:");
        int размер = Convert.ToInt32(Console.ReadLine());

        int[] массив = new int[размер];

        Console.WriteLine("Введите значения для массива:");
        for (int индекс = 0; индекс < размер; индекс++)
        {
            массив[индекс] = Convert.ToInt32(Console.ReadLine());
        }

        СортировкаПузырьком(массив);

        Console.WriteLine("Отсортированный массив:");
        foreach (var элемент in массив)
        {
            Console.Write(элемент + " ");
        }
    }

    static void СортировкаПузырьком(int[] массив)
    {
        int длина = массив.Length;

        for (int проход = 0; проход < длина - 1; проход++)
        {
            Console.WriteLine($"\nПроход номер {проход + 1}:");

            for (int j = 0; j < длина - 1 - проход; j++)
            {
                if (массив[j] > массив[j + 1])
                {
                    Console.WriteLine($"  Операция {j + 1}: Меняем {массив[j]} и {массив[j + 1]} местами");

                    int временное = массив[j];
                    массив[j] = массив[j + 1];
                    массив[j + 1] = временное;
                }
                else
                {
                    Console.WriteLine($"  Операция {j + 1}: {массив[j]} и {массив[j + 1]} уже расположены правильно");
                }
            }

            Console.WriteLine("  Текущий массив: " + string.Join(", ", массив));
        }
    }
}