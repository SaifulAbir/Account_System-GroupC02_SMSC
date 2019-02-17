using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroupC02_SMSC.Models
{
    public class CashOut
    {
        [Key]
        public int CashOutID { get; set; }

        public int ID { get; set; }

        public int DesignationID { get; set; }

        public int? Salary { get; set; }

        public DateTime? CashOutDate { get; set; }
    }
    [NotMapped]
    public class CashOutVM
    {
        [Key]
        public int CashOutID { get; set; }

        public string Name { get; set; }

        public string DesignationName { get; set; }

        public int? Salary { get; set; }

        public string CashOutDate { get; set; }
    }
}
