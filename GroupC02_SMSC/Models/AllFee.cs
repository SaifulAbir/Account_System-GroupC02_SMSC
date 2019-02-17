using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroupC02_SMSC.Models
{
    public class AllFee
    {
        [Key]
        public int FeeID { get; set; }

        [Required(ErrorMessage = "Fee Name Required")]
        public string FeeName { get; set; }

        [Required(ErrorMessage = "Fee Amount Required")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Enter only numeric number")]
        public int? FeeAmount { get; set; }

        public int? FeeTimeID { get; set; }

        public int? ClassID { get; set; }
    }
    [NotMapped]
    public class AllFeeVM
    {
        public int FeeID { get; set; }

        public string FeeName { get; set; }

        public int? FeeAmount { get; set; }

        public string FeeTimeName { get; set; }

        public string ClassName { get; set; }
    }
}
