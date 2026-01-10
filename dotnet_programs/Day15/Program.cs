using System;
using System.IO;
using System.Text.Json;
using Microsoft.VisualBasic;
using System.Xml.Serialization;
using System.Collections.Generic;


public class User
{
    public int Id{get;set;}
    public string Name{get;set;}
}
class Program
{
            public static bool ScholarshipEligibility(Student std)
        {
           if(std.Marks>80 && std.SportGrade=='A')
                return true;
            return false;
    }
    static void Main()
    {

// FileInfo
        // FileInfo file=new FileInfo("sample.txt");
        // if(!file.Exists)
        // {
        //     using (StreamWriter writer=file.CreateText())
        //     {
        //         writer.WriteLine("Hello File Info class");
        //     }
        // }
        // Console.WriteLine("File.Name: " + file.Name);
        // Console.WriteLine("File.Size: " + file.Length+ " bytes");
        // Console.WriteLine("Create On: " + file.CreationTime);
        

//Directory --> static
        // Directory.CreateDirectory("logs");
        // if(Directory.Exists("logs"))
        // {
        //     Console.WriteLine("Logs directory created successfully.");
        // }


//DirectoryInfo
        // DirectoryInfo dir=new DirectoryInfo("logs");
        // if(!dir.Exists)

        // {
        //     dir.Create();
        // }
        // Console.WriteLine("Directory Name: "+ dir.Name);
        // Console.WriteLine("Created On: "+ dir.CreationTime);
        // Console.WriteLine("Full Path: "+ dir.FullName);


        // User user=new User{Id=1, Name="Alice"};
        // string json=JsonSerializer.Serialize(user);
        // File.WriteAllText("user.json",json);
        // Console.WriteLine("User serialized successfully.");

        // string json=File.ReadAllText("user.json");
        // User user=JsonSerializer.Deserialize<User>(json);
        // Console.WriteLine($"user Loaded: {user.Id},{user.Name}");

        // User user=new User{Id=1, Name="Alice"};
        // XmlSerializer serializer=new XmlSerializer(typeof(User));
        // using (FileStream fs=new FileStream("user.xml",FileMode.Create))
        // {
        //     serializer.Serialize(fs,user);
        // }
        // Console.WriteLine("XML Serialized");
        Console.WriteLine("Enter number of students:");
        int n = Convert.ToInt32(Console.ReadLine());
        List<Student> list = new List<Student>();

        for (int i = 0; i < n; i++)
        {
            Student s = new Student();
            Console.WriteLine("Enter Roll Number of student:");
            s.RollNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name of student:");
            s.Name = Console.ReadLine();
        Console.WriteLine("Enter Marks of student:");
            s.Marks = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Grade of student:");
            s.SportGrade = Console.ReadLine()[0];

            list.Add(s);
        }
        Console.WriteLine("Eligible name of students are:");

        string result=Student.GetEligibleStudents(list,ScholarshipEligibility);
        Console.WriteLine (result);

    }
}