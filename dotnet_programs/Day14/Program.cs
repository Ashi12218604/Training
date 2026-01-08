using System;
using System.IO.Pipelines;
      class User
    {
        public int Id;
        public string Name;
    }
class Programs
{
    static void Main()
    {
        // string path="data.txt";
        // File.WriteAllText(path,"File I/O Example in C#");
        // File.WriteAllText(path,"File I/O Example in C#");

        // Console.WriteLine("Data written to file");
        // string content=File.ReadAllText("data.txt");
        // Console.WriteLine("File Content:");
        // Console.WriteLine(content);



        // using (StreamWriter writer = new StreamWriter("log.txt"))
        // {
        //     writer.WriteLine("Appliation started");
        //     writer.WriteLine("Processing data");

        //     writer.WriteLine("Application ended");

        // }
        // using (StreamReader reader = new StreamReader("log.txt"))
        // {
        //     string line;
        //     while((line=reader.ReadLine())!=null)
        //     {
        //         Console.WriteLine(line);
        //     }
        // }




    //     User user=new User{Id=1, Name="Alice"};
    //     using(StreamWriter writer=new StreamWriter("user.txt"))
    //     {
    //         writer.WriteLine(user.Id);
    //         writer.WriteLine(user.Name);
    //         user.Id=2;
    //         user.Name="Bob";
            
    // writer.WriteLine(user.Id);
    // writer.WriteLine(user.Name);

    //     }
    //     Console.WriteLine("User Data Saved");



    User user=new User();
    using(StreamReader reader=new StreamReader("user.txt"))
    {
    user.Id=int.Parse(reader.ReadLine());
    user.Name=reader.ReadLine();
    }
    Console.WriteLine($"User Loaded:{user.Id},{user.Name}");

  

    }
}