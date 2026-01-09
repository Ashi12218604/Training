using System;
using System.Collections.Generic;
public delegate bool IsEligibleforScholarship(Student std);
    public class Student
    {
        public int RollNo{get;set;}
        public string Name{get;set;}
        public int Marks{get;set;}
        public char SportGrade{get;set;}
        public static string GetEligibleStudents(List<Student> studentlist,IsEligibleforScholarship isEligible)
{
        string output = "";

        foreach (Student s in studentlist)
        {
            if (isEligible(s))
            {
                if (output == "")
                    output = s.Name;
                else
                    output = output + "," + s.Name;
            }
        }

        return output;
    }
    }
