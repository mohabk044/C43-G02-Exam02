using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class MCQ_Question : Question
    {
        public override string Header { get; set; }
        public override string Body { get; set; }
        public override int Mark { get; set; }
        public override string ToString()
        => base.ToString() + "  MCQ Question";
        public override void ShowQuestion()
        {
            Console.WriteLine(this.ToString());
            for (int i = 0; i < Answers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Answers[i].answer}");
            }
        }
    }
}
