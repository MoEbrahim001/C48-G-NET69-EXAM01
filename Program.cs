using System;

namespace C48_G_NET69_EXAM01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Subject Id:");
            int subjectId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Subject Name:");
            string subjectName = Console.ReadLine();

            Console.WriteLine("Choose Exam Type:");
            Console.WriteLine("1 - Practical");
            Console.WriteLine("2 - Final");

            int examChoice = int.Parse(Console.ReadLine());

            if (examChoice != 1 && examChoice != 2)
            {
                throw new Exception("Invalid Exam Type.");
            }

            ExamType examType = (ExamType)examChoice;

            Subject subject = new Subject(subjectId, subjectName);

            subject.CreateExam(examType);

            for (int i = 0; i < subject.ExamofSubject.NumberOfQuestions; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"===== Enter Question {i + 1} =====");

                if (examType == ExamType.Practical)
                {
                    Console.WriteLine("Enter Question Header:");
                    string header = Console.ReadLine();

                    Console.WriteLine("Enter Question Body:");
                    string body = Console.ReadLine();

                    Console.WriteLine("Enter Question Mark:");
                    decimal mark = decimal.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Number Of Choices:");
                    int capacity = int.Parse(Console.ReadLine());

                    Answers tempRightAnswer = new Answers(0, "Temp");

                    MCQQuestion mcqQuestion =
                        new MCQQuestion(
                            header,
                            body,
                            mark,
                            capacity,
                            tempRightAnswer
                        );

                    for (int j = 0; j < capacity; j++)
                    {
                        Console.WriteLine($"Enter Answer {j + 1}:");
                        string answerText = Console.ReadLine();

                        Answers answer =
                            new Answers(j + 1, answerText);

                        mcqQuestion.FillAnswers(answer);
                    }

                    Console.WriteLine("Enter The Right Answer Id:");
                    int rightAnswerId = int.Parse(Console.ReadLine());

                    if (!mcqQuestion.GetTheRightAnswer(rightAnswerId))
                    {
                        throw new Exception("Invalid Right Answer Id.");
                    }

                    ((PracticalExam)subject.ExamofSubject)
                        .AddPracticalQuestion(mcqQuestion);
                }

                else if (examType == ExamType.Final)
                {
                    Console.WriteLine("Choose Question Type:");
                    Console.WriteLine("1 - MCQ");
                    Console.WriteLine("2 - True / False");

                    int questionType = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Question Header:");
                    string header = Console.ReadLine();

                    Console.WriteLine("Enter Question Body:");
                    string body = Console.ReadLine();

                    Console.WriteLine("Enter Question Mark:");
                    decimal mark = decimal.Parse(Console.ReadLine());

                    if (questionType == 1)
                    {
                        Console.WriteLine("Enter Number Of Choices:");
                        int capacity = int.Parse(Console.ReadLine());

                        Answers tempRightAnswer =
                            new Answers(0, "Temp");

                        MCQQuestion mcqQuestion =
                            new MCQQuestion(
                                header,
                                body,
                                mark,
                                capacity,
                                tempRightAnswer
                            );

                        for (int j = 0; j < capacity; j++)
                        {
                            Console.WriteLine($"Enter Answer {j + 1}:");
                            string answerText = Console.ReadLine();

                            Answers answer =
                                new Answers(j + 1, answerText);

                            mcqQuestion.FillAnswers(answer);
                        }

                        Console.WriteLine("Enter The Right Answer Id:");
                        int rightAnswerId = int.Parse(Console.ReadLine());

                        if (!mcqQuestion.GetTheRightAnswer(rightAnswerId))
                        {
                            throw new Exception("Invalid Right Answer Id.");
                        }

                        subject.ExamofSubject.AddQuestion(mcqQuestion);
                    }

                    else if (questionType == 2)
                    {
                        Answers tempRightAnswer =
                            new Answers(0, "Temp");

                        TrueorFalseQuestion trueFalseQuestion =
                            new TrueorFalseQuestion(
                                header,
                                body,
                                mark,
                                2,
                                tempRightAnswer
                            );

                        Console.WriteLine("Choose The Right Answer:");
                        Console.WriteLine("1 - True");
                        Console.WriteLine("2 - False");

                        int rightAnswerId = int.Parse(Console.ReadLine());

                        if (!trueFalseQuestion.GetTheRightAnswer(rightAnswerId))
                        {
                            throw new Exception("Invalid Right Answer Id.");
                        }

                        subject.ExamofSubject.AddQuestion(trueFalseQuestion);
                    }

                    else
                    {
                        throw new Exception("Invalid Question Type.");
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("================================");
            Console.WriteLine("Exam Is Ready");
            Console.WriteLine("================================");
            Console.WriteLine();

            subject.ExamofSubject.ShowExam();
        }
    }
}