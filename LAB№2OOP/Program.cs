using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Завдання 1
        Console.Write("Введiть розмiр масиву N: ");
        int N = int.Parse(Console.ReadLine());

        double[] array = new double[N];

        Console.WriteLine("Введiть елементи масиву:");
        for (int i = 0; i < N; i++)
        {
            Console.Write($"Елемент {i + 1}: ");
            array[i] = double.Parse(Console.ReadLine());
        }

        int minindex = Array.IndexOf(array, array.Min());
        Console.WriteLine($"Номер мiнiмального елемента: {minindex}");
        Console.WriteLine("--------------------------------------------------------------------------");

        int firstNegativeIndex = Array.FindIndex(array, x => x < 0);
        int secondNegativeIndex = Array.FindIndex(array, firstNegativeIndex + 1, i => i < 0);
        if (firstNegativeIndex == -1 || secondNegativeIndex == -1)
        {
            Console.WriteLine("У масивi немає двох вiд'ємних елементiв.");
        }
        else
        {
            double sumBetweenNegatives = 0;
            for (int i = firstNegativeIndex + 1; i < secondNegativeIndex; i++)
            {
                sumBetweenNegatives += array[i];
            }
            Console.WriteLine($"Сума елементiв мiж першим i другим вiд'ємними елементами: {sumBetweenNegatives}");
        }
        Console.WriteLine("--------------------------------------------------------------------------");

        var segment1 = new ArraySegment<double>(array, 0, N);
        var segment2 = new ArraySegment<double>(array, 0, N);

        segment1 = segment1.Where(x => Math.Abs(x) <= 10).ToArray();
        segment2 = segment2.Where(x => Math.Abs(x) > 10).ToArray();

        var finalArray = segment1.Concat(segment2).ToArray();

        Console.WriteLine("Результат перетворення масиву:");
        foreach (var element in finalArray)
        {
            Console.WriteLine(element);
        }
        Console.WriteLine("--------------------------------------------------------------------------");

        // Завдання 2
        int[,] matrix = {
            { 1, -2, 3, -4 },
            { -5, 6, -7, 8 },
            { -9, 10, -11, 12 }
        };
        Console.WriteLine("Задана матриця: ");
        Console.WriteLine("1, -2, 3, -4 ");
        Console.WriteLine( "-5, 6, -7, 8" );
        Console.WriteLine("-9, 10, -11, 12");
        Console.WriteLine("--------------------------------------------------------------------------");

        int rowCount = matrix.GetLength(0);
        int colCount = matrix.GetLength(1);
        int[] columnCharacteristics = new int[colCount];

        for (int col = 0; col < colCount; col++)
        {
            int characteristic = 0;
            for (int row = 0; row < rowCount; row++)
            {
                int value = matrix[row, col];
                if (value < 0 && value % 2 != 0)
                {
                    characteristic += Math.Abs(value);
                }
            }
            columnCharacteristics[col] = characteristic;
        }

        int[][] sortedColumns = new int[colCount][];
        for (int i = 0; i < colCount; i++)
        {
            int minCharacteristic = columnCharacteristics.Min();
            int minIndex = Array.IndexOf(columnCharacteristics, minCharacteristic);
            sortedColumns[i] = new int[rowCount];
            for (int row = 0; row < rowCount; row++)
            {
                sortedColumns[i][row] = matrix[row, minIndex];
            }
            columnCharacteristics[minIndex] = int.MaxValue;
        }

        Console.WriteLine("Матриця пiсля перестановки стовпцiв:");
        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < colCount; col++)
            {
                Console.Write(sortedColumns[col][row] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("--------------------------------------------------------------------------");

        // Завдання 3
        Console.WriteLine("Введiть текстовий рядок:");
        string inputText = Console.ReadLine();

        int digitCount = inputText.Count(char.IsDigit);

        char[] priholos = { 'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ' };

        string[] words = inputText.Split(new[] { ' ', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        var priholosWords = words.Where(w => priholos.Contains(char.ToLower(w[0]))).ToArray();

        var tweenWords = words.Where(w => w.Length < 2 || w[0] != w[w.Length - 1]).ToArray();

        Console.WriteLine($"Кiлькiсть цифр у текстi: {digitCount}");
        Console.WriteLine("--------------------------------------------------------------------------");
        Console.WriteLine("Слова, що починаються з приголосних лiтер:");
        Console.WriteLine(string.Join(", ", priholosWords));
        Console.WriteLine("--------------------------------------------------------------------------");
        Console.WriteLine("Текст пiсля видалення слiв, якi починаються i закiнчуються на одну й ту ж лiтеру:");
        Console.WriteLine(string.Join(" ", tweenWords));
    }
}
