using GroupC02_SMSC.Interface;
using GroupC02_SMSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupC02_SMSC.Concrete
{
    public class StudentPaymentListConcrete : IStudentPaymentList
    {
        private DatabaseContext _context;
        public StudentPaymentListConcrete(DatabaseContext context)
        {
            _context = context;
        }

        public IQueryable<AllPaymentsByStudent> ShowAllPayments(string sortColumn, string sortColumnDir, string Search)
        {
            var IQueryableAllPayments = (from allPayments in _context.StudentPayment
                                         join user in _context.Registration on allPayments.Createdby equals user.ID
                                         join fee in _context.AllFee on allPayments.FeeID equals fee.FeeID
                                         join clas in _context.AddClass on fee.ClassID equals clas.ClassID
                                         select new AllPaymentsByStudent
                                         {
                                             Name = user.Name,
                                             Username = user.Username,
                                             ClassName = clas.ClassName,
                                             FeeName = fee.FeeName,
                                             Amount = allPayments.Amount,
                                             CreatedDate = allPayments.CreatedDate.Value.ToString("dd/MM/yyyy")
                                         });
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                //IQueryableReg = IQueryableReg.OrderBy(sortColumn + " " + sortColumnDir);
            }
            if (!string.IsNullOrEmpty(Search))
            {
                IQueryableAllPayments = IQueryableAllPayments.Where(m => m.Username == Search || m.Name == Search || m.ClassName == Search || m.FeeName == Search);
            }

            return IQueryableAllPayments;
        }

        public IQueryable<RegistrationViewModel> ShowAllPaymentsByStudent(string sortColumn, string sortColumnDir, string Search)
        {
            
            var IQueryablePaymentsByStudent = (from user in _context.Registration
                                     join clas in _context.AddClass on user.ClassID equals clas.ClassID
                                     where user.RoleID == 2
                                     select new RegistrationViewModel
                                     
                                     {
                                         ID = user.ID,
                                         Name = user.Name,
                                         Username = user.Username,
                                         ClassName = clas.ClassName

                                     });
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                //IQueryableReg = IQueryableReg.OrderBy(sortColumn + " " + sortColumnDir);
            }
            if (!string.IsNullOrEmpty(Search))
            {
                IQueryablePaymentsByStudent = IQueryablePaymentsByStudent.Where(m => m.Name == Search);
            }

            return IQueryablePaymentsByStudent;
        }

        public IEnumerable<AllPaymentsByStudent> ShowAllPaymentsStudent(int Createdby)
        {
            var IQueryableBooking = (from tempbooking in _context.StudentPayment
                                     join p in _context.Registration on tempbooking.Createdby equals p.ID
                                     join f in _context.AllFee on tempbooking.FeeID equals f.FeeID
                                     join cls in _context.AddClass on f.ClassID equals cls.ClassID
                                     where tempbooking.Createdby == Createdby
                                     select new AllPaymentsByStudent
                                     {
                                         
                                         Name = p.Name,
                                         FeeName = f.FeeName,
                                         ClassName = cls.ClassName,
                                         CardNum = tempbooking.CardNum,
                                         Amount = tempbooking.Amount,
                                         CreatedDate = tempbooking.CreatedDate.Value.ToString("dd/MM/yyyy"),
                                         PaymentDetailID = tempbooking.PaymentDetailID
                                     });
           

            return IQueryableBooking;
        }
    }
}
