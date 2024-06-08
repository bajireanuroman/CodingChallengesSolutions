using System;
using System.Numerics;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("No command-line arguments provided.");
            return;
        }

        string option = args[0];
        string filePath = args[1];

        if (string.IsNullOrEmpty(option))
        {
            Console.WriteLine("The option is either null or empty.");
            return;
        }

        if (string.IsNullOrEmpty(filePath))
        {
            Console.WriteLine("The filePath is either null or empty.");
            return;
        }

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"File does not exist: {filePath}");
            return;
        }

        string fileName = GetSubstringAfterLastSlash(filePath);

        if (option == "-c")
        {
            byte[]? bytes = GetBytes(filePath);
            if (bytes != null)
            {
                Console.WriteLine($"{bytes.Length} {fileName}");
            }
        }
        else if (option == "-l")
        {
            int? lines = GetLines(filePath);
            Console.WriteLine($"{lines} {fileName}");
        }
        else if (option == "-w")
        {
            int? wordsCount = GetWords(filePath);
            Console.WriteLine($"{wordsCount} {fileName}");
        }
        else if (option == "-m")
        {
            int? charactersCount = GetCharacters(filePath);
            Console.WriteLine($"{charactersCount} {fileName}");
        }
        else
        {
            Console.WriteLine("Invalid option provided.");
        }
    }

    static string GetSubstringAfterLastSlash(string input)
    {
        int lastSlashIndex = input.LastIndexOf('/');
        if (lastSlashIndex == -1 || lastSlashIndex == input.Length - 1)
        {
            return string.Empty; // No slash found or slash is the last character
        }
        return input.Substring(lastSlashIndex + 1);
    }

    public static byte[]? GetBytes(string filePath)
    {
        try
        {
            return File.ReadAllBytes(filePath);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error reading the file: {filePath}. Exception: {e.Message}");
            return null;
        }
    }

    public static int? GetLines(string filePath)
    {
        try
        {
            return File.ReadLines(filePath).Count();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error reading the file: {filePath}. Exception: {e.Message}");
            return null;
        }
    }

    public static int? GetWords(string filePath)
    {
        try
        {
            string text = File.ReadAllText(filePath);
            string[] words = text.Split(new char[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;

        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occured: {e.Message}");
            return null;
        }
    }

    public static int? GetCharacters(string filePath)
    {
        try
        {
            string text = File.ReadAllText(filePath);
            return text.Length;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occured: {e.Message}");
            return null;
        }
    }
}