using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace C48_G_NET69_EXAM01
{
    internal class BaseQuestion
    {
        public BaseQuestion(string headerOfQuestion, string bofyOfQuestion, decimal mark , int capacity, Answers rightAnswer)
        {
            HeaderOfQuestion = headerOfQuestion;
            BofyOfQuestion = bofyOfQuestion;
            Mark = mark;
            AnswersList = new Answers[capacity];
            RightAnswer = rightAnswer;  
        }

        public string HeaderOfQuestion { get; set; }
        public string BofyOfQuestion { get; set; }
        public decimal Mark { get; set; }
       public Answers[]? AnswersList { get; set; }
        public Answers RightAnswer { get; set; }

        public override string ToString()
        {
            return $"The Header Of THe Qyestion :{HeaderOfQuestion} the bodyof the Question : {BofyOfQuestion} , the Mark is {Mark}";
        }
        public string McqQuestionHeaderWritten(string headerquestion)
        {
            if (string.IsNullOrWhiteSpace(headerquestion))
            {

                throw new Exception("ERROR!! You have to enter the header correctly");

            }
            HeaderOfQuestion = headerquestion;
            return HeaderOfQuestion;


        }
        public string McqQuestionbodyofquestionrWritten(string Bodyofquestion)
        {
            if (string.IsNullOrWhiteSpace(Bodyofquestion))
            {

                throw new Exception("BodyofQuestion can not be whitespace or null");

            }
            BofyOfQuestion = Bodyofquestion;
            return BofyOfQuestion;


        }
        public decimal? McqQuestionMarkWritten(decimal mark)
        {
            if (mark <= 0  )
            {

                throw new Exception("Mark can not be 0 or null");

            }
            Mark = mark;
            return Mark;


        }
        public bool GetTheRightAnswer(int rightAnswerId)
        {
            for (int i = 0; i < AnswersList?.Length; i++)
            {
                if (AnswersList[i].AnswerId == rightAnswerId)
                {
                    RightAnswer = AnswersList[i];
                    return true;
                }
            }
            return false;
        }
    }
}
