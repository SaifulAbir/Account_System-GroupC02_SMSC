using GroupC02_SMSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupC02_SMSC.Interface
{
    public interface IStudentPaymentList
    {
        IQueryable<AllPaymentsByStudent> ShowAllPayments(string sortColumn, string sortColumnDir, string Search);
        IQueryable<RegistrationViewModel> ShowAllPaymentsByStudent(string sortColumn, string sortColumnDir, string Search);
        IEnumerable<AllPaymentsByStudent> ShowAllPaymentsStudent(int Createdby);
    }
}
