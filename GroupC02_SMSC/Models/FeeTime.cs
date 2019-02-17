using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupC02_SMSC.Models
{
    public class FeeTime
    {
        [Key]
        public int FeeTimeID { get; set; }

        [Required(ErrorMessage = "FeeTime Required")]
        public string FeeTimeName { get; set; }


    }
}
