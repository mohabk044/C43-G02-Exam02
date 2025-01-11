using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class PracticalExam : Exam
    {
        public override DateTime ExamTime { get; set; }
        public override int QusetinNumber { get; set; }



        public override void ShowExam()
        {
            Console.WriteLine("--------------- Practical Exam ---------------");
            Console.WriteLine();
            foreach (var question in Questions)
            {
                question.ShowQuestion();

                Console.WriteLine();

                Console.WriteLine("----------------------------------");

                Console.WriteLine();
            }
        }
        public void CorrectAnswers()
        {
            foreach (var item in Questions)
            {

                Console.WriteLine($"the Question : {item.Body}");
                if (item.CorrectAnswers != null)
                {
                    Console.WriteLine($"the correct Answer is {item.CorrectAnswers.answer}");
                }
                else
                {
                    Console.WriteLine("no answers available ");
                }
                Console.WriteLine();
                Console.WriteLine("---------");
                Console.WriteLine();
            }
        }



    }
}
