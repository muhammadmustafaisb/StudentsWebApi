using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Repositories.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StdId { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        public string FatherName { get; set; }
        [Required]
        public string Number { get; set; }
    }
}
