using System;

namespace RefOutParamsApp
{
    class Program
    {
        static void Swap(ref int a, ref int b)
        {
            int temp = a; a = b; b = temp;
        }

        static void SplitNumber(double n, out long integerPart, out double decimalPart)
        {
            integerPart = (long)Math.Truncate(n);
            decimalPart = n - integerPart;
        }

        static int CalculateSum(params int[] numbers)
        {
            int sum = 0;
            foreach (int i in numbers) sum += i;
            return sum;
        }

        static void Main()
        {
            Console.WriteLine("LeThiThuHuyen_6551071037");
            int x = 5, y = 10;
            Swap(ref x, ref y);
            Console.WriteLine($"Swapped: x={x}, y={y}");

            SplitNumber(15.75, out long intPart, out double decPart);
            Console.WriteLine($"Split 15.75: Integer={intPart}, Decimal={decPart}");

            Console.WriteLine($"Sum using params: {CalculateSum(1, 2, 3, 4, 5)}");
        }
    }
}