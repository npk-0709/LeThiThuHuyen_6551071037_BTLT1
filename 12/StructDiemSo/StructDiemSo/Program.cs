using System;

namespace ScoreStructApp
{
    struct Student
    {
        public int ID;
        public string FullName;
        public double LiteratureScore, MathScore, EnglishScore;
        public double AverageScore => (LiteratureScore + MathScore + EnglishScore) / 3;
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("LeThiThuHuyen_6551071037");
            Student[] students = new Student[5];
            double maxAverage = -1;
            int maxIdIndex = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"--- Enter Student {i + 1} ---");
                students[i] = new Student();
                Console.Write("ID: "); students[i].ID = int.Parse(Console.ReadLine());
                Console.Write("Full Name: "); students[i].FullName = Console.ReadLine();
                Console.Write("Math, Literature, English scores (separated by space): ");
                string[] scores = Console.ReadLine().Split(' ');
                students[i].MathScore = double.Parse(scores[0]);
                students[i].LiteratureScore = double.Parse(scores[1]);
                students[i].EnglishScore = double.Parse(scores[2]);

                if (students[i].AverageScore > maxAverage)
                {
                    maxAverage = students[i].AverageScore;
                    maxIdIndex = i;
                }
            }

            Console.WriteLine($"\nStudent with highest score: {students[maxIdIndex].FullName} ({students[maxIdIndex].AverageScore:F2})");
            foreach (var st in students)
            {
                string rank = st.AverageScore >= 8 ? "Excellent" : st.AverageScore >= 6.5 ? "Good" : st.AverageScore >= 5 ? "Average" : "Weak";
                Console.WriteLine($"{st.ID} - {st.FullName} - Avg: {st.AverageScore:F2} - {rank}");
            }
        }
    }
}