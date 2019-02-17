using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroupC02_SMSC.Models
{
    public class StudentPayment
    {
        [Key]
        public int PayID { get; set; }

        [Required(ErrorMessage = "Select Fee Type")]
        [Display(Description = "Fee Type")]
        public int? FeeID { get; set; }

        [Display(Name = "Credit Card Number")]
        [Required(ErrorMessage = "required")]
        [Range(100000000000, 9999999999999999999, ErrorMessage = "must be between 12 and 19 digits")]
        public string CardNum { get; set; }

        [MinLength(4, ErrorMessage = "Minimum Pin must be 7 in charaters")]
        [Required(ErrorMessage = "required")]
        public string Pin { get; set; }

        [Required(ErrorMessage = "Required Guest Count")]
        [Display(Description = "No .Of Guest")]
        public int Amount { get; set; }

        public int? Createdby { get; set; }

        public DateTime? CreatedDate { get; set; }

        [NotMapped]
        public DateTime? PaymentDate { get; set; }

        public int? PaymentDetailID { get; set; }
    }
}
