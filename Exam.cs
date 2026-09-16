using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C48_G_NET69_EXAM01
{
    internal abstract class Exam
    {
        public Exam(int timeOfExam, int numberOfQuestions)
        {
            TimeOfExam = timeOfExam;
            NumberOfQuestions = numberOfQuestions;
            questions = new BaseQuestion[numberOfQuestions];

        }

        public int TimeOfExam { get; set; }
        public int NumberOfQuestions { get; set; }
        public BaseQuestion[] questions { get; set; }
        public abstract void ShowExam();


        public bool AddQuestion(BaseQuestion question)
        {
            for (int i = 0; i < questions.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(question.HeaderOfQuestion) || string.IsNullOrWhiteSpace(question.BofyOfQuestion) )
                {
                    throw new Exception("Headerofquestion or the BofyOfQuestion is invalid");
                }

                if (questions[i] is null)
                {
                    questions[i] = question;
                    
                    return true;

                }

            }
            return false;
        }



    }
}
