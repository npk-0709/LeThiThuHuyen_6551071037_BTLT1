using System;

namespace ExceptionHandlingApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("LeThiThuHuyen_6551071037");
            while (true)
            {
                Console.Write("Enter expression (num1 operator num2) or 'exit': ");
                string input = Console.ReadLine();
                if (input.ToLower() == "exit") break;

                string[] parts = input.Split(' ');
                try
                {
                    if (parts.Length != 3) throw new FormatException("Invalid format!");
                    checked
                    {
                        int a = int.Parse(parts[0]);
                        string op = parts[1];
                        int b = int.Parse(parts[2]);

                        int result = op switch
                        {
                            "+" => a + b,
                            "-" => a - b,
                            "*" => a * b,
                            "/" => a / b,
                            _ => throw new Exception("Invalid operator!")
                        };
                        Console.WriteLine($"Result: {result}");
                    }
                }
                catch (FormatException) { Console.WriteLine("Error: Invalid number format."); }
                catch (DivideByZeroException) { Console.WriteLine("Error: Cannot divide by zero."); }
                catch (OverflowException) { Console.WriteLine("Error: Result is too large."); }
                catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
                finally { Console.WriteLine("Calculation finished.\n"); }
            }
        }
    }
}