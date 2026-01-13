namespace ReflectionDemo
{
    public class Employee
    {
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;

        public void Work() {}
        public int Add(int x, int y) => x + y;
        public Employee(){}
        public Employee(int id){Id=id;}
    }
}
