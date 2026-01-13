namespace ReflectionDemo
{
    [Audit("Car class audited")]
    public class Car
    {
        [Audit("Car model property")]
        public string Model {get; set;} = string.Empty;

        public int Year {get; set;}
        public bool IsRunning() => true;
    }
}
