using ExamSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Exam Exam { get; set; }
        public Question Question { get; set; }

        public void CreateExam()
        {
            Console.WriteLine("Enter subject name: ");
            Name = Console.ReadLine();

            int ExamType = GetValidatedInput("please select Exam type => Final Exam = 1 || Practical exam = 2", 1, 2);

            if (ExamType == 1)
            {
                Exam = new FinalExam();
                Exam.QusetinNumber = GetValidatedInput("please enter the number of questions you want to create", 1, int.MaxValue);
                Exam.Questions = new List<Question>();

                Console.Clear();

                for (int i = 0; i < Exam.QusetinNumber; i++)
                {
                    int QuestionType = GetValidatedInput($"type of Qusetion [{i + 1}]     MCQ = 1  ||  True & False = 2", 1, 2);

                    string header = $"Question{i + 1}";
                    Console.WriteLine($"enter the body of Question [{i + 1}]");
                    string body = Console.ReadLine();

                    int mark = GetValidatedInput($"enter the mark of Question [{i + 1}]", 0, int.MaxValue);

                    if (QuestionType == 1)
                    {
                        Question = new MCQ_Question
                        {
                            Header = header,
                            Body = body,
                            Mark = mark,
                            Answers = new List<Answer>()
                        };

                        int ChoicesNumber = GetValidatedInput($"the number of choices for Question [{i + 1}]", 1, int.MaxValue);

                        for (int j = 0; j < ChoicesNumber; j++)
                        {
                            Console.WriteLine($"enter the Choice [{j + 1}] of Question [{i + 1}] ");
                            string AnswerText = Console.ReadLine();
                            Question.Answers.Add(new Answer { AnswerId = j + 1, answer = AnswerText });
                        }

                        int correct = GetValidatedInput($"enter the number of the correct answer for Question [{i + 1}]", 1, ChoicesNumber);
                        Question.CorrectAnswers = Question.Answers.Find(a => a.AnswerId == correct);
                        Console.Clear();
                    }
                    else
                    {
                        Question = new TF_Question
                        {
                            Header = header,
                            Body = body,
                            Mark = mark,
                            Answers = new List<Answer>
                            {
                                new Answer {AnswerId = 1 , answer = "True" },
                                new Answer {AnswerId = 2 , answer = "False" }
                            }
                        };
                        int correct = GetValidatedInput("enter the correct answer =>  True = 1  ||  False = 2", 1, 2);
                        Question.CorrectAnswers = Question.Answers.Find(a => a.AnswerId == correct);
                    }
                    Exam.Questions.Add(Question);
                    Console.Clear();
                }
            }
            else
            {
                Exam = new PracticalExam();
                Exam.QusetinNumber = GetValidatedInput("please enter the number of questions you want to create", 1, int.MaxValue);
                Exam.Questions = new List<Question>();
                Console.Clear();

                for (int i = 0; i < Exam.QusetinNumber; i++)
                {
                    string header = $"Question{i + 1}";
                    Console.WriteLine($"enter the body of Question [{i + 1}]");
                    string body = Console.ReadLine();

                    int mark = GetValidatedInput($"enter the mark of Question [{i + 1}]", 0, int.MaxValue);

                    Question = new MCQ_Question
                    {
                        Header = header,
                        Body = body,
                        Mark = mark,
                        Answers = new List<Answer>()
                    };

                    int ChoicesNumber = GetValidatedInput($"number of choices for Question [{i + 1}]", 1, int.MaxValue);

                    for (int j = 0; j < ChoicesNumber; j++)
                    {
                        Console.WriteLine($"enter the Choice [{j + 1}] of Question [{i + 1}] ");
                        string AnswerText = Console.ReadLine();
                        Question.Answers.Add(new Answer { AnswerId = j + 1, answer = AnswerText });
                    }

                    int correct = GetValidatedInput($"enter the correct answer number of Question [{i + 1}]", 1, ChoicesNumber);
                    Question.CorrectAnswers = Question.Answers.Find(a => a.AnswerId == correct);
                    Exam.Questions.Add(Question);
                    Console.Clear();
                }
                Console.Clear();
            }
        }

        private int GetValidatedInput(string prompt, int minValue, int maxValue)
        {
            int value;
            bool validInput = false;
            while (!validInput)
            {
                try
                {
                    Console.WriteLine(prompt);
                    value = int.Parse(Console.ReadLine());
                    if (value >= minValue && value <= maxValue)
                    {
                        validInput = true;
                        return value;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input. Please enter a number between {minValue} and {maxValue}.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
            return -1; // This line will never be reached because the loop will continue until valid input is given
        }

        public override string ToString()
        {
            return $"Subject name is {Name}";
        }
    }
}

