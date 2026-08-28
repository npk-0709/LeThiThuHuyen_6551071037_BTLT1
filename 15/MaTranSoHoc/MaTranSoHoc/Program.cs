using System;

namespace ArithmeticMatrixApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("LeThiThuHuyen_6551071037");
            int[,] matrix = new int[3, 3];
            int sumAll = 0, sumMainDiag = 0, sumSubDiag = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"matrix[{i},{j}] = ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                    sumAll += matrix[i, j];
                    if (i == j) sumMainDiag += matrix[i, j];
                    if (i + j == 2) sumSubDiag += matrix[i, j];
                }
            }

            Console.WriteLine("Original Matrix:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++) Console.Write(matrix[i, j] + "\t");
                Console.WriteLine();
            }

            Console.WriteLine($"Total Sum: {sumAll}\nMain Diagonal: {sumMainDiag}\nSub Diagonal: {sumSubDiag}");

            int maxRowSum = int.MinValue, minColSum = int.MaxValue;
            for (int i = 0; i < 3; i++)
            {
                int rSum = 0, cSum = 0;
                for (int j = 0; j < 3; j++) { rSum += matrix[i, j]; cSum += matrix[j, i]; }
                if (rSum > maxRowSum) maxRowSum = rSum;
                if (cSum < minColSum) minColSum = cSum;
            }
            Console.WriteLine($"Max Row Sum: {maxRowSum} | Min Column Sum: {minColSum}");

            Console.WriteLine("Transposed Matrix:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++) Console.Write(matrix[j, i] + "\t");
                Console.WriteLine();
            }
        }
    }
}