using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        const int mazeWidth = 20;
        const int mazeHeight = 10;
        const int timeLimitInSeconds = 60; // Лимит времени в секундах

        char[,] maze = GenerateMaze(mazeWidth, mazeHeight);
        bool[,] discoveredCells = new bool[mazeWidth, mazeHeight];
        int playerPosX = 1, playerPosY = 1;

        Stopwatch timer = new Stopwatch();
        timer.Start();

        while (true)
        {
            Console.Clear();
            RenderMaze(maze, discoveredCells, playerPosX, playerPosY);

            // Рассчитываем оставшееся время
            int elapsedSeconds = (int)timer.Elapsed.TotalSeconds;
            int timeLeft = timeLimitInSeconds - elapsedSeconds;

            // Проверяем, не истекло ли время
            if (timeLeft <= 0)
            {
                Console.Clear();
                RenderMaze(maze, discoveredCells, playerPosX, playerPosY);
                Console.WriteLine("Время вышло! Вы проиграли.");
                break;
            }

            Console.WriteLine($"Оставшееся время: {timeLeft} секунд.");
            Console.WriteLine("Используйте клавиши W, A, S, D для движения. Нажмите Q для выхода.");

            // Обработка ввода игрока
            char userInput = Console.ReadKey(true).KeyChar;
            if (userInput == 'q') break;

            int nextPosX = playerPosX, nextPosY = playerPosY;
            switch (userInput)
            {
                case 'w': nextPosY--; break;
                case 'a': nextPosX--; break;
                case 's': nextPosY++; break;
                case 'd': nextPosX++; break;
                default: continue;
            }

            if (maze[nextPosX, nextPosY] != '#') // Проверка, чтобы не столкнуться со стеной
            {
                playerPosX = nextPosX;
                playerPosY = nextPosY;
                discoveredCells[nextPosX, nextPosY] = true; // Открываем новую клетку

                if (maze[nextPosX, nextPosY] == 'X') // Если нашли выход
                {
                    Console.Clear();
                    RenderMaze(maze, discoveredCells, playerPosX, playerPosY);
                    Console.WriteLine($"Поздравляем! Вы нашли выход за {elapsedSeconds} секунд!");
                    break;
                }
            }
        }

        timer.Stop();
    }

    static char[,] GenerateMaze(int width, int height)
    {
        char[,] maze = new char[width, height];
        Random rng = new Random();

        // Инициализируем лабиринт стенами
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                maze[x, y] = '#';
            }
        }

        // Функция для создания путей в лабиринте
        void CreatePath(int x, int y)
        {
            maze[x, y] = ' '; // Создаем путь
            int[] directions = { 0, 1, 2, 3 }; // 0: Вверх, 1: Вправо, 2: Вниз, 3: Влево
            ShuffleArray(directions, rng);

            foreach (int direction in directions)
            {
                int newX = x, newY = y;
                switch (direction)
                {
                    case 0: newX = x; newY = y - 2; break; // Вверх
                    case 1: newX = x + 2; newY = y; break; // Вправо
                    case 2: newX = x; newY = y + 2; break; // Вниз
                    case 3: newX = x - 2; newY = y; break; // Влево
                }

                if (newX > 0 && newX < width - 1 && newY > 0 && newY < height - 1 && maze[newX, newY] == '#')
                {
                    maze[newX, newY] = ' ';
                    maze[(x + newX) / 2, (y + newY) / 2] = ' '; // Убираем стену между клетками
                    CreatePath(newX, newY);
                }
            }
        }

        CreatePath(1, 1); // Стартовая позиция (1,1)

        // Устанавливаем выход
        maze[width - 2, height - 2] = 'X';

        // Гарантируем доступность старта
        maze[1, 1] = ' ';

        return maze;
    }

    static void ShuffleArray(int[] array, Random rng)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            (array[i], array[j]) = (array[j], array[i]);
        }
    }

    static void RenderMaze(char[,] maze, bool[,] discovered, int playerX, int playerY)
    {
        for (int y = 0; y < maze.GetLength(1); y++)
        {
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                if (x == playerX && y == playerY)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('R'); // Игрок
                    Console.ResetColor();
                }
                else if (discovered[x, y])
                {
                    Console.Write(maze[x, y]); // Открытые клетки
                }
                else
                {
                    Console.Write('#'); // Скрытые клетки
                }
            }
            Console.WriteLine();
        }
    }
}

