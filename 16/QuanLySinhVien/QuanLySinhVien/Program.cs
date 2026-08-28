using System;

namespace StudentManagementApp
{
    struct StudentData
    {
        public string StudentID, FullName;
        public double[] Scores;
        public double AverageScore
        {
            get
            {
                double sum = 0;
                foreach (var s in Scores) sum += s;
                return sum / Scores.Length;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("LeThiThuHuyen_6551071037");
            StudentData[] studentList = new StudentData[5];
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    studentList[i] = new StudentData { Scores = new double[5] };
                    studentList[i].StudentID = "STU" + i;
                    studentList[i].FullName = "Name " + i;
                    for (int j = 0; j < 5; j++) studentList[i].Scores[j] = new Random().Next(5, 11);
                }

                for (int i = 0; i < studentList.Length - 1; i++)
                {
                    for (int j = i + 1; j < studentList.Length; j++)
                    {
                        if (studentList[i].AverageScore < studentList[j].AverageScore)
                        {
                            var temp = studentList[i];
                            studentList[i] = studentList[j];
                            studentList[j] = temp;
                        }
                    }
                }

                Console.WriteLine("Ranked List:");
                for (int i = 0; i < studentList.Length; i++)
                {
                    Console.WriteLine($"Rank {i + 1}: {studentList[i].StudentID} - {studentList[i].FullName} - Avg: {studentList[i].AverageScore:F2}");
                }

                Console.Write("Enter Student ID to search: "); string search = Console.ReadLine();
                int idx = 0; bool found = false;
                while (idx < studentList.Length)
                {
                    if (studentList[idx].StudentID == search)
                    {
                        Console.WriteLine($"Found: {studentList[idx].FullName}");
                        found = true; break;
                    }
                    idx++;
                }
                if (!found) Console.WriteLine("Not found!");

                Console.WriteLine(studentList[0].Scores[10]);
            }
            catch (IndexOutOfRangeException) { Console.WriteLine("Error: Array index out of bounds!"); }
        }
    }
}