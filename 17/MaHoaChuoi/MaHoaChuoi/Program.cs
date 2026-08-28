using System;

namespace StringEncryptionApp
{
    enum EncryptionType { Caesar = 1, Reverse = 2, ToggleCase = 3 }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("LeThiThuHuyen_6551071037");
            string input;
            do
            {
                try
                {
                    Console.Write("\nEnter string ('exit' to quit): ");
                    input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input)) throw new Exception("String cannot be empty!");
                    if (input.ToLower() == "exit") break;

                    Console.WriteLine("Choose encryption: 1.Caesar, 2.Reverse, 3.Toggle Case");
                    EncryptionType type = (EncryptionType)int.Parse(Console.ReadLine());

                    switch (type)
                    {
                        case EncryptionType.Caesar:
                            string caesar = "";
                            foreach (char c in input)
                            {
                                if (char.IsLetter(c))
                                {
                                    char offset = char.IsUpper(c) ? 'A' : 'a';
                                    caesar += (char)((((c + 3) - offset) % 26) + offset);
                                }
                                else caesar += c;
                            }
                            Console.WriteLine("Caesar: " + caesar);
                            break;
                        case EncryptionType.Reverse:
                            char[] charArray = input.ToCharArray();
                            Array.Reverse(charArray);
                            Console.WriteLine("Reverse: " + new string(charArray));
                            break;
                        case EncryptionType.ToggleCase:
                            string toggle = "";
                            foreach (char c in input)
                            {
                                toggle += char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c);
                            }
                            Console.WriteLine("Toggle Case: " + toggle);
                            break;
                    }
                }
                catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
            } while (true);
        }
    }
}