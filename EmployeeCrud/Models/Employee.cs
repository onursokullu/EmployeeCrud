﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeCrud.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}