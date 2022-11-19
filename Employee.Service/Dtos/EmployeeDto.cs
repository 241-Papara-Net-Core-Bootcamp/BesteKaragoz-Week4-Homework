using Microsoft.EntityFrameworkCore.Metadata.Internal;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Employee.Service.Dtos
{
    public class EmployeeDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email must be required")]

        public string Email { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Salary { get; set; }

    }
}
