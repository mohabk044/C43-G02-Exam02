using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string answer { get; set; }
        public Answer()
        {

        }
        public override string ToString()
        {
            return $"Answer is : {answer}";
        }
    }
}
