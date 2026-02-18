using System;
using System.Collections;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        List<Student> st=new List<Student>
        {
            new Student(1,"Ashi",151.2f,96.0f),
            new Student(2,"Sanjana",155.2f,98.5f),
            new Student(1,"Mari",null,30.5f),
            new Student(1,"Aryan",160.2f,75.0f),
            new Student(1,"Ayush",170.2f,80.5f)
        };
    
        ArrayList arr=new ArrayList(st);
        int attc=0;
        foreach(Student s in arr)
        {
            // Console.WriteLine($"Student Id: {s.Id}");
            string newname="";
            for(int i=0;i<s.Name.Length;i+=2)
            {
                newname+=s.Name[i];
            }
            // Console.WriteLine("Name:"+newname);
            string h;
        if(s.Height==null)
        {
            h="Height Not Available";
        }
        else
            {
                h=Math.Round(s.Height.Value,1).ToString();
            }
        if(s.AttendancePercentage>75.5f)
            {
                // Console.WriteLine("Attendance:"+s.AttendancePercentage);
                attc++;
            }
             Console.WriteLine($"Id: {s.Id} | Name: {newname} | Height: {h} | Attendance: {s.AttendancePercentage}");
        }
        Console.WriteLine("Students in attendace count above 75.5 is:"+attc);
    }
}