using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagement.Models
{
  public  class Employee
    {
        public int EmployeeId { get; set; }


        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime DateOfBrith { get; set; }
        
        [Required]
        public Gender Gender { get; set; }
        
        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public string PhotoPath { get; set; }
    }
}
