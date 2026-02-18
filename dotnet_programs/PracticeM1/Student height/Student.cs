public class Student
{
    public int Id{get;set;}
    public string Name{get;set;}
    public float? Height{get;set;}
    public float AttendancePercentage{get;set;}

    public Student(int id,string name, float? h,float att)
{
    Id=id;
    Name=name;
    Height=h;
    AttendancePercentage=att;
}
}
