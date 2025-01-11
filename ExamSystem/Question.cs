using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public abstract class Question
    {
        public abstract string Header { get; set; }
        public abstract string Body { get; set; }
        public abstract int Mark { get; set; }
        public List<Answer> Answers { get; set; }
        public Answer CorrectAnswers { get; set; }
        public abstract void ShowQuestion();
        public override string ToString()
        => $"{Header} => {Body}       {Mark} marks";
    }
}
