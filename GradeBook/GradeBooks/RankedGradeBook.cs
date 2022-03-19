using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook :BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException();
            int studentsPerTwentyPercent = (int)(Students.Count * 0.2);
            int rank = 1;
            foreach (var student in Students)
            {
                double studentAverage = student.Grades.Sum() / student.Grades.Count;
                if (studentAverage > averageGrade)
                {
                    rank++;
                }
            }
            int ranking = (int)Math.Ceiling((double)(rank / studentsPerTwentyPercent));
            switch (ranking)
            {
                case 1:
                    return 'A';
                case 2:
                    return 'B';
                case 3:
                    return 'C';
                case 4:
                    return 'D';
                default:
                    return 'F';
            }
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students.");
            else
                base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students.");
            else
                base.CalculateStudentStatistics(name);
        }
    }
}
