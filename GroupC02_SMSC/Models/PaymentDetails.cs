using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroupC02_SMSC.Models
{
    public class PaymentDetails
    {
        [Key]
        public int PaymentDetailID { get; set; }
        public string PaymentNo { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? Createdby { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string PaymentApproval { get; set; }
        public DateTime? PaymentApprovalDate { get; set; }
        public string PaymentCompletedFlag { get; set; }
    }
    /*[NotMapped]
    public class BookingDetailTemp
    {
        public int PaymentID { get; set; }
        public string PaymentNo { get; set; }
        public string PaymentDate { get; set; }
        public string Createdby { get; set; }
        
        public string PaymentApproval { get; set; }
        public string PaymentApprovalDate { get; set; }
    }*/
    [NotMapped]
    public class BookingDetailTemp
    {
        public int Username { get; set; }
        
        public string FeeName { get; set; }
        public string Amount { get; set; }
        public string CreatedDate { get; set; }
    }
}

