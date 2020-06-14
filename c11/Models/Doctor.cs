using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace c11.Models{
    public partial class Doctor{
        public int IdDoctor { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
