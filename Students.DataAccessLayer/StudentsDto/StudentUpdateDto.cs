using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.DataAccessLayer.StudentsDto
{
    public class StudentUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        public string FatherName { get; set; }
        [Required]
        public string Number { get; set; }
    }
}
