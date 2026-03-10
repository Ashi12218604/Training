using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Models
{
    public class Marks
    {
        [Key]
        public int MarksId { get; set; }

        public string Subject { get; set; }

        public int MarksObtained { get; set; }

        public int Semester { get; set; }

        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}
