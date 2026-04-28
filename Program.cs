//Task 1

//using System;
//using System.Text.RegularExpressions;

//class Program
//{
//    static void Main()
//    {
//        Random rand = new Random();
//        int[,] matrix = new int[5, 5];

//        // Заповнення масиву
//        for (int i = 0; i < 5; i++)
//            for (int j = 0; j < 5; j++)
//                matrix[i, j] = rand.Next(-100, 101);

//        // Виведення масиву
//        Console.WriteLine("Масив");
//        for (int i = 0; i < 5; i++)
//        {
//            for (int j = 0; j < 5; j++)
//                Console.Write($"{matrix[i, j],5}");
//            Console.WriteLine();
//        }

//        // Знаходження мін і макс та їх індексів
//        int minVal = matrix[0, 0], maxVal = matrix[0, 0];
//        int minPos = 0, maxPos = 0;

//        for (int i = 0; i < 5; i++)
//        {
//            for (int j = 0; j < 5; j++)
//            {
//                int pos = i * 5 + j;
//                if (matrix[i, j] < minVal) { minVal = matrix[i, j]; minPos = pos; }
//                if (matrix[i, j] > maxVal) { maxVal = matrix[i, j]; maxPos = pos; }
//            }
//        }
//        // Сума елементів між мін і макс (по лінійному обходу)
//        int start = Math.Min(minPos, maxPos) + 1;
//        int end = Math.Max(minPos, maxPos) - 1;
//        long sum = 0;

//        for (int pos = start; pos <= end; pos++)
//            sum += matrix[pos / 5, pos % 5];

//        Console.WriteLine($"\nМінімум: {minVal} на позиції [{minPos / 5}][{minPos % 5}]");
//        Console.WriteLine($"Максимум: {maxVal} на позиції [{maxPos / 5}][{maxPos % 5}]");
//        Console.WriteLine($"Сума елементів між ними: {sum}");
//    }
//}

//Task 2

using System;
using System.Text;
using System.IO;

namespace CaesarCipherApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Встановлюємо кодову сторінку 1251 для Windows кирилиці
            Console.OutputEncoding = Encoding.GetEncoding(1251);
            Console.InputEncoding = Encoding.GetEncoding(1251);
            Console.SetIn(new StreamReader(Console.OpenStandardInput(), Encoding.GetEncoding(1251)));

            char[] alphabetArr = {
                'а','б','в','г','ґ','д','е','є','ж','з','и','і','ї','й','к','л',
                'м','н','о','п','р','с','т','у','ф','х','ц','ч','ш','щ','ь','ю','я'
            };
            int n = alphabetArr.Length;

            Console.Write("Введіть фразу для шифрування: ");
            string phrase = Console.ReadLine().ToLower();

            Console.Write("Введіть крок зсуву (число): ");
            if (!int.TryParse(Console.ReadLine(), out int shift))
            {
                Console.WriteLine("Помилка: введіть ціле число.");
                return;
            }

            char[] phraseArr = phrase.ToCharArray();
            char[] encrypted = new char[phraseArr.Length];
            char[] decrypted = new char[phraseArr.Length];

            // --- ШИФРУВАННЯ ---
            for (int k = 0; k < phraseArr.Length; k++)
            {
                char ch = phraseArr[k];
                int index = Array.IndexOf(alphabetArr, ch);
                if (index != -1)
                {
                    int newPos = ((index + shift) % n + n) % n;
                    encrypted[k] = alphabetArr[newPos];
                }
                else
                {
                    encrypted[k] = ch;
                }
            }

            // --- РОЗШИФРУВАННЯ ---
            for (int k = 0; k < encrypted.Length; k++)
            {
                char ch = encrypted[k];
                int index = Array.IndexOf(alphabetArr, ch);
                if (index != -1)
                {
                    int newPos = ((index - shift) % n + n) % n;
                    decrypted[k] = alphabetArr[newPos];
                }
                else
                {
                    decrypted[k] = ch;
                }
            }

            Console.WriteLine("\n--- РЕЗУЛЬТАТ ---");
            Console.WriteLine("Оригінальна фраза:   " + phrase);
            Console.WriteLine("Зашифрована фраза:   " + new string(encrypted));
            Console.WriteLine("Розшифрована фраза:  " + new string(decrypted));

            Console.WriteLine("\nНатисніть будь-яку клавішу, щоб вийти...");
            Console.ReadKey();
        }
    }
}
