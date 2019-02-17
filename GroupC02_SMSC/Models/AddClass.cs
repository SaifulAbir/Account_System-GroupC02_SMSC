using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroupC02_SMSC.Models
{
    public class AddClass
    {
        [Key]
        public int ClassID { get; set; }

        [Required(ErrorMessage = "Class Name Required")]
        public string ClassName { get; set; }

        //[Required(ErrorMessage = "VenueCost Required")]
        //[RegularExpression("([1-9][0-9]*)", ErrorMessage = "Enter only numeric number")]
        //public int? ClassFee { get; set; }
    }

    [NotMapped]
    public class AddClassVM
    {
        public int ClassID { get; set; }
        
        public string ClassName { get; set; }
    }
}
