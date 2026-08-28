using System;
using System.Linq;

namespace TextAnalyzerApp
{
    enum AnalysisType { Character = 1, Word = 2, Line = 3 }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("LeThiThuHuyen_6551071037");
            string[] lines = new string[50];
            int lineCount = 0, wordCount = 0, charCount = 0;
            int[] letterCount = new int[26];

            Console.WriteLine("Enter text (type END to stop):");
            try
            {
                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "END") break;
                    lines[lineCount++] = input;

                    charCount += input.Replace(" ", "").Length;
                    string[] words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    wordCount += words.Length;

                    foreach (char c in input.ToLower())
                    {
                        if (c >= 'a' && c <= 'z') letterCount[c - 'a']++;
                    }
                }
            }
            catch (IndexOutOfRangeException) { Console.WriteLine("Exceeded 50 lines limit!"); }

            Console.WriteLine("Select analysis view: 1.Character 2.Word 3.Line");
            AnalysisType type = (AnalysisType)int.Parse(Console.ReadLine());

            switch (type)
            {
                case AnalysisType.Character:
                    Console.WriteLine($"Total characters (excluding spaces): {charCount}");
                    var top5 = letterCount.Select((count, index) => new { Char = (char)(index + 'a'), Count = count })
                                          .OrderByDescending(x => x.Count).Take(5);
                    Console.WriteLine("Top 5 characters:");
                    foreach (var item in top5) if (item.Count > 0) Console.WriteLine($"{item.Char}: {item.Count}");
                    break;
                case AnalysisType.Word:
                    Console.WriteLine($"Total words: {wordCount}");
                    var allWords = string.Join(" ", lines.Take(lineCount)).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (allWords.Length > 0)
                    {
                        Console.WriteLine($"Longest word: {allWords.OrderByDescending(w => w.Length).First()}");
                        Console.WriteLine($"Shortest word: {allWords.OrderBy(w => w.Length).First()}");
                    }
                    break;
                case AnalysisType.Line:
                    Console.WriteLine($"Total lines: {lineCount}");
                    for (int i = 0; i < lineCount; i++)
                    {
                        string cleanLine = lines[i].Replace(" ", "").ToLower();
                        string reversed = new string(cleanLine.Reverse().ToArray());
                        Console.WriteLine($"Line {i + 1} is Palindrome: {cleanLine == reversed}");
                    }
                    break;
            }
        }
    }
}