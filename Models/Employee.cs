using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11)]
        [Display(Name = "Id number")]
        public string PersonId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [EmailAddress]
        [StringLength(50, MinimumLength = 5)]
        [Display(Name = "Email")]
        public string EmployeeEmail { get; set; }

        [Range(555, 100000)]
        public int Salary { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

    }
}
