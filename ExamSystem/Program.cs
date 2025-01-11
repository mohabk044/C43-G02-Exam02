using ExaminationSystem;
using System;
using System.Diagnostics;

namespace ExamSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject();
            subject.CreateExam();
            Console.Clear();
            Console.WriteLine("Do you want to start the exam? (Y  ||  N)");
            if (char.ToUpper(Console.ReadLine()[0]) == 'Y')
            {
                Console.Clear();
                Stopwatch sw = Stopwatch.StartNew();
                subject.Exam.ShowExam();
                int[] selectedAnswers = new int[subject.Exam.QusetinNumber];
                for (int i = 0; i < subject.Exam.Questions.Count; i++)
                {
                    Console.WriteLine($"Select your answer for question [{i + 1}]:");
                    selectedAnswers[i] = int.Parse(Console.ReadLine());
                }
                sw.Stop();
                if (subject.Exam is PracticalExam prac)
                {
                    Console.Clear();
                    Console.WriteLine($"Time taken: {sw.Elapsed}");

                    prac.CorrectAnswers();
                }
                else if (subject.Exam is FinalExam fin)
                {
                    Console.Clear();
                    fin.ShowExamResults(selectedAnswers);
                    Console.WriteLine($"Time taken: {sw.Elapsed}");

                }
            }
        }
    }
}
