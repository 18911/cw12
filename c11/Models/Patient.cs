﻿using System;
using System.Collections.Generic;

namespace c11.Models
{
    public partial class Patient
    {
        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
