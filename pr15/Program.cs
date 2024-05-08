using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Будь ласка, введіть шлях до папки:");
        string folderPath = Console.ReadLine();

        // Перевірка чи шлях існує
        if (!Directory.Exists(folderPath))
        {
            Console.WriteLine("Папка не знайдена.");
            return;
        }

        // Отримання списку зображень
        var imageFiles = Directory.GetFiles(folderPath)
            .Where(file => file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                           file.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                           file.EndsWith(".gif", StringComparison.OrdinalIgnoreCase) ||
                           file.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase))
            .ToList();

        // Відображення списку зображень
        Console.WriteLine("Знайдені зображення:");
        for (int i = 0; i < imageFiles.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {Path.GetFileName(imageFiles[i])}");
        }

        // Вибір зображення для відкриття
        Console.WriteLine("Введіть номер зображення, щоб відкрити його:");
        if (int.TryParse(Console.ReadLine(), out int imageNumber) && imageNumber >= 1 && imageNumber <= imageFiles.Count)
        {
            // Відкриття зображення
            Process.Start(new ProcessStartInfo(imageFiles[imageNumber - 1]) { UseShellExecute = true });
        }
        else
        {
            Console.WriteLine("Неправильний номер зображення.");
        }
    }
}