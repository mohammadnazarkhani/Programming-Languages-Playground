using FloodFillProblem;

class Program
{
    static void Main()
    {
        // Create a sample image (2D array)
        int[,] image = new int[,]
        {
            { 1, 1, 1, 1, 1, 1, 1 },
            { 1, 2, 2, 2, 2, 2, 1 },
            { 1, 2, 3, 3, 3, 2, 1 },
            { 1, 2, 3, 3, 3, 2, 1 },
            { 1, 2, 3, 3, 3, 2, 1 },
            { 1, 2, 2, 2, 2, 2, 1 },
            { 1, 1, 1, 1, 1, 1, 1 }
        };

        FloodFill floodFill = new FloodFill();

        while (true)
        {
            Console.Clear();
            PrintImage(image);
            PrintColorOptions();
            
            Console.WriteLine("\nEnter row and column to paint (e.g., '3 4') or 'exit' to quit:");
            string? input = Console.ReadLine();
            
            if (string.IsNullOrEmpty(input) || input.ToLower() == "exit")
                break;

            string[] coordinates = input.Split(' ');
            if (coordinates.Length != 2 || 
                !int.TryParse(coordinates[0], out int row) || 
                !int.TryParse(coordinates[1], out int col))
            {
                Console.WriteLine("Invalid input! Press any key to try again...");
                Console.ReadKey();
                continue;
            }

            if (!floodFill.IsValid(image, row, col))
            {
                Console.WriteLine("Position out of bounds! Press any key to try again...");
                Console.ReadKey();
                continue;
            }

            Console.WriteLine($"Current color at position [{row},{col}] is {image[row,col]}");
            PrintColorOptions();
            Console.Write("Enter new color (number): ");
            
            if (!int.TryParse(Console.ReadLine(), out int newColor) || newColor < 1 || newColor > 5)
            {
                Console.WriteLine("Invalid color! Press any key to try again...");
                Console.ReadKey();
                continue;
            }

            floodFill.Fill(image, (row, col), newColor);
        }
    }

    static void PrintImage(int[,] image)
    {
        Console.WriteLine("Current image (showing indices):");
        Console.Write("  ");
        for (int j = 0; j < image.GetLength(1); j++)
            Console.Write($" {j}");
        Console.WriteLine();

        for (int i = 0; i < image.GetLength(0); i++)
        {
            Console.Write($"{i}: ");
            for (int j = 0; j < image.GetLength(1); j++)
            {
                ConsoleColor color = image[i,j] switch
                {
                    1 => ConsoleColor.Blue,
                    2 => ConsoleColor.Green,
                    3 => ConsoleColor.Red,
                    4 => ConsoleColor.Yellow,
                    5 => ConsoleColor.Magenta,
                    _ => ConsoleColor.White
                };

                Console.ForegroundColor = color;
                Console.Write($" {image[i,j]}");
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }

    static void PrintColorOptions()
    {
        Console.WriteLine("\nColor options:");
        PrintColorOption(1, "Blue", ConsoleColor.Blue);
        PrintColorOption(2, "Green", ConsoleColor.Green);
        PrintColorOption(3, "Red", ConsoleColor.Red);
        PrintColorOption(4, "Yellow", ConsoleColor.Yellow);
        PrintColorOption(5, "Magenta", ConsoleColor.Magenta);
    }

    static void PrintColorOption(int number, string name, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write($"{number}: {name}");
        Console.ResetColor();
        Console.Write("  ");
    }
}
