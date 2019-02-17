using GroupC02_SMSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupC02_SMSC.Interface
{
    public interface IStudentPayment
    {
        int? FeePayment(StudentPayment objBV);
        int BookEvent(PaymentDetails PaymentDetail);
        IQueryable<AllPaymentsByStudent> ShowTotalPay(string sortColumn, string sortColumnDir, string Search, int Createdby);
        AllPaymentsByStudent GetTotalPayment(int Createdby);

        
    }
}
