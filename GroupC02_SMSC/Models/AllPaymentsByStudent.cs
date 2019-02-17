using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroupC02_SMSC.Models
{
    [NotMapped]
    public class AllPaymentsByStudent
    {
        [Key]
        public int PayID { get; set; }

        public int? FeeID { get; set; }

        public string CardNum { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string ClassName { get; set; }

        public string FeeName { get; set; }

        public int? Pin { get; set; }

        public int? Amount { get; set; }

        public int? Createdby { get; set; }

        public string CreatedDate { get; set; }

        public int? PaymentDetailID { get; set; }

        public int? TotalAmount { get; set; }

        public int? TotalPayableAmount { get; set; }

        public int? TotalDueAmount { get; set; }

        public int? Current_year { get; set; }

        public string First_date { get; set; }


    }
}
