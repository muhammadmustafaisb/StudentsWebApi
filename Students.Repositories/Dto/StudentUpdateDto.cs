﻿using System.ComponentModel.DataAnnotations;

namespace Students.Repositories.Dto
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
