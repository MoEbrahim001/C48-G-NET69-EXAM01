using System;

namespace C48_G_NET69_EXAM01
{
    internal class PracticalExam : Exam
    {
        public PracticalExam(int timeOfExam, int numberOfQuestions)
            : base(timeOfExam, numberOfQuestions)
        {
        }

        public bool AddPracticalQuestion(MCQQuestion question)
        {
            for (int i = 0; i < questions.Length; i++)
            {
                if (questions[i] is null)
                {
                    questions[i] = question;
                    return true;
                }
            }

            return false;
        }

        public override void ShowExam()
        {
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

                if (!int.TryParse(Console.ReadLine(), out int studentAnswer))
                {
                    throw new Exception("Answer must be a valid number.");
                }

                bool answerExists = false;

                for (int j = 0; j < questions[i].AnswersList?.Length; j++)
                {
                    if (questions[i].AnswersList?[j].AnswerId == studentAnswer)
                    {
                        answerExists = true;
                        break;
                    }
                }

                if (!answerExists)
                {
                    throw new Exception("AnswerId does not exist.");
                }

                Console.WriteLine("-------------------------");
            }

            Console.WriteLine("===== Right Answers =====");

            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine(
                    $"Question {i + 1}: " +
                    $"{questions[i].RightAnswer.AnswerId} - " +
                    $"{questions[i].RightAnswer.AnswerText}"
                );
            }
        }
    }
}