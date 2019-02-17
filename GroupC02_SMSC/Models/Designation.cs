using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroupC02_SMSC.Models
{
    public class Designation
    {
        [Key]
        public int DesignationID { get; set; }

        [Required(ErrorMessage = "Designation Name Required")]
        public string DesignationName { get; set; }

        [Required(ErrorMessage = "Salary Amount Required")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Enter only numeric number")]
        public int? Salary { get; set; }
    }
    [NotMapped]
    public class DesignationVM
    {
        public int DesignationID { get; set; }

        public string Name { get; set; }

        public string DesignationName { get; set; }

        public int? Salary { get; set; }




    }
}
