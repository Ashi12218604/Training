using System.Collections.Generic;

namespace OnetoMany.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public List<Student> Students { get; set; }
    }
}