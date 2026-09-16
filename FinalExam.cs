using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C48_G_NET69_EXAM01
{
    internal class FinalExam : Exam
    {
        public FinalExam(int timeOfExam, int numberOfQuestions) : base(timeOfExam, numberOfQuestions)
        {
        }
        public override void ShowExam()
        {
            decimal totalGrade = 0;
            int[] studentAnswers = new int[questions.Length];

            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine($"Question {i + 1}");
                Console.WriteLine($"Header: {questions[i].HeaderOfQuestion}");
                Console.WriteLine($"Body: {questions[i].BofyOfQuestion}");
                Console.WriteLine($"Mark: {questions[i].Mark}");

                for (int j = 0; j < questions[i].AnswersList?.Length; j++)
                {
                    Console.WriteLine(
                        $"{questions[i].AnswersList?[j].AnswerId} - " +
                        $"{questions[i].AnswersList?[j].AnswerText}"
                    );
                }

                Console.WriteLine("Enter Your Answer:");

                if (!int.TryParse(Console.ReadLine(), out studentAnswers[i]))
                {
                    throw new Exception("Answer must be a valid number.");
                }

                if (studentAnswers[i] == questions[i].RightAnswer.AnswerId)
                {
                    totalGrade += questions[i].Mark;
                }

                Console.WriteLine("-------------------------");
            }

            Console.WriteLine("===== Final Exam Result =====");

            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine($"Question {i + 1}: {questions[i].BofyOfQuestion}");

                Console.WriteLine(
                    $"Your Answer ID: {studentAnswers[i]}"
                );

                Console.WriteLine(
                    $"Right Answer: {questions[i].RightAnswer.AnswerId} - " +
                    $"{questions[i].RightAnswer.AnswerText}"
                );

                Console.WriteLine("-------------------------");
            }

            Console.WriteLine($"Your Total Grade: {totalGrade}");
        }
    }
}
