using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class FinalExam : Exam
    {
        public override DateTime ExamTime { get; set; }
        public override int QusetinNumber { get; set; }

        public override void ShowExam()
        {
            Console.WriteLine("--------------- Final Exam ---------------");
            Console.WriteLine();

            foreach (var question in Questions)
            {
                question.ShowQuestion();
                Console.WriteLine();
                Console.WriteLine("----------------------------------");
                Console.WriteLine();
            }
        }

        public void ShowExamResults(int[] selectedAnswers)
        {
            int mark = 0;
            Console.WriteLine("--------------- Final Exam Status ---------------");
            Console.WriteLine();

            //Console.WriteLine("1) the Questions");
            //foreach (var item in Questions)
            //{

            //    Console.WriteLine($"the Question : {item.Body}");
            //    if (item.CorrectAnswers != null)
            //    {
            //        Console.WriteLine($"the correct Answer is => {item.CorrectAnswers.answer}");
            //    }
            //    else
            //    {
            //        Console.WriteLine("no answers available ");
            //    }
            //    Console.WriteLine();
            //    Console.WriteLine("---------");
            //    Console.WriteLine();
            //}


            for (int i = 0; i < Questions.Count; i++)
            {
                var question = Questions[i];
                Console.WriteLine(question.ToString());

                Console.WriteLine("Answers:");
                for (int j = 0; j < question.Answers.Count; j++)
                {
                    Console.WriteLine($"{j + 1}. {question.Answers[j].answer}");
                }

                Console.WriteLine($"Your Answer number => {selectedAnswers[i]}");
                Console.WriteLine($"Correct Answer => {question.CorrectAnswers.answer}");

                if (question.CorrectAnswers.AnswerId == selectedAnswers[i])
                {
                    mark += question.Mark;
                }

                Console.WriteLine();
                Console.WriteLine("----------------------------------");
                Console.WriteLine();
            }

            int totalMarks = Questions.Sum(q => q.Mark);
            double percentege = ((double)mark / totalMarks) * 100;

            Console.WriteLine("---------------your status---------------");
            Console.WriteLine();
            Console.WriteLine($"Total Score: {mark} out of {totalMarks}");
            Console.WriteLine($"Percentage: {percentege}%");

            if (percentege >= 85)
            {
                Console.WriteLine("congratulation your grade is Exellent");
            }
            else if (percentege >= 75 && percentege < 85)
            {
                Console.WriteLine("your grade is Very Good");
            }
            else if (percentege >= 65 && percentege < 75)
            {
                Console.WriteLine("your grade is Good");
            }
            else if (percentege >= 50 && percentege < 65)
            {
                Console.WriteLine("your grade is makbool");
            }
            else
            {
                Console.WriteLine("you are failed");
            }
        }
    }
}
