using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace C48_G_NET69_EXAM01
{
    internal class MCQQuestion : BaseQuestion
    {
        public MCQQuestion(string headerOfQuestion, string bofyOfQuestion, decimal mark, int capacity, Answers rightAnswer) : base(headerOfQuestion, bofyOfQuestion, mark, capacity, rightAnswer)
        {
        }

        public bool Presentingtheanswers()
        {
            for (int i = 0; i < AnswersList?.Length; i++)
            {

                Answers answers = AnswersList[i];
                Console.WriteLine($"{answers.AnswerId}-{answers.AnswerText}");

            }
            return false;
        }
        public bool FillAnswers(Answers Answer)
        {
            for (int i = 0; i < AnswersList?.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(Answer.AnswerText) || Answer.AnswerId <= 0)
                {
                    throw new Exception("AnswerText or the AnswerId is invalid");
                }

                if (AnswersList[i] is null)
                {
                    AnswersList[i] = Answer;
                    break;
                }
            }

            return false;
        }
    }
}