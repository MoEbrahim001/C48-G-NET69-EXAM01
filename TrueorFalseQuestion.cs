using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C48_G_NET69_EXAM01
{
    internal class TrueorFalseQuestion : BaseQuestion
    {
        public TrueorFalseQuestion(string headerOfQuestion, string bofyOfQuestion, decimal mark, int capacity, Answers rightAnswer) : base(headerOfQuestion, bofyOfQuestion, mark, capacity, rightAnswer)
        {
            AnswersList = new Answers[2];
            AnswersList[0] = new Answers(1, "True");
            AnswersList[1] = new Answers(2, "False");


        }

    
    }
    }

