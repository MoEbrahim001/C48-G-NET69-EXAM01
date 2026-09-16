using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C48_G_NET69_EXAM01
{
    internal class Subject
    {
        public Subject(int sublectId, string subjectName)
        {
            SublectId = sublectId;
            SubjectName = subjectName;
        }

        public int SublectId { get; set; }
        public string SubjectName { get; set; }
        public Exam ExamofSubject { get; set; }
        public void CreateExam(ExamType examType)
        {
            Console.WriteLine("Enter The Time of Exam From 30 To 180 Minutes:");

            if (!int.TryParse(Console.ReadLine(), out int timeOfExam) ||
                timeOfExam < 30 ||
                timeOfExam > 180)
            {
                throw new Exception("Time of Exam must be between 30 and 180 minutes.");
            }

            Console.WriteLine("Enter The Number of Questions:");

            if (!int.TryParse(Console.ReadLine(), out int numberOfQuestions) ||
                numberOfQuestions <= 0)
            {
                throw new Exception("Number of Questions must be greater than 0.");
            }

            if (examType == ExamType.Practical)
            {
                ExamofSubject = new PracticalExam(timeOfExam, numberOfQuestions);
            }
            else if (examType == ExamType.Final)
            {
                ExamofSubject = new FinalExam(timeOfExam, numberOfQuestions);
            }
            else
            {
                throw new Exception("Invalid Exam Type.");
            }
        }
        public override string ToString()
        {
            return $"The Subject Id : {SublectId} , The SubjectName :{SubjectName} of Exam :{ExamofSubject}";
        }
    }
}
