using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException();

            int nStudentsToDropGrade = Students.Count / 5;
            Students.Sort((s1, s2) => s2.AverageGrade.CompareTo(s1.AverageGrade));

            int studentIndex = Students.Count;
            for (int i = 0; i < Students.Count; i++)
            {
                if (averageGrade >= Students[i].AverageGrade)
                {
                    studentIndex = i;
                    break;
                }
            }

            List<char> grades = new List<char> { 'A', 'B', 'C', 'D', 'F' };
            int gradeIndex = studentIndex / nStudentsToDropGrade;

            return grades[gradeIndex];
        }

    }
}