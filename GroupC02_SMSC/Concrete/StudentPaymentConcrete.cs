using GroupC02_SMSC.Interface;
using GroupC02_SMSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupC02_SMSC.Concrete
{
    public class StudentPaymentConcrete : IStudentPayment
    {
        private DatabaseContext _context;
        public StudentPaymentConcrete(DatabaseContext context)
        {
            _context = context;
        }

        public int BookEvent(PaymentDetails PaymentDetail)
        {
            try
            {
                if (PaymentDetail != null)
                {
                    _context.PaymentDetails.Add(PaymentDetail);
                    _context.SaveChanges();

                    var currentBookingID = _context.PaymentDetails.OrderByDescending(u => u.PaymentDetailID).FirstOrDefault();

                    var no = currentBookingID.PaymentDetailID.ToString() == "0" ? "1" : currentBookingID.PaymentDetailID.ToString();

                    var seq = "BK" + "-" + DateTime.Now.Year + "-" + no;

                    PaymentDetail.PaymentNo = seq;
                    _context.PaymentDetails.Attach(PaymentDetail);
                    _context.Entry(PaymentDetail).Property(x => x.PaymentNo).IsModified = true;
                    _context.SaveChanges();

                    return PaymentDetail.PaymentDetailID;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int? FeePayment(StudentPayment objBV)
        {
            try
            {
                _context.StudentPayment.Add(objBV);
                _context.SaveChanges();
                return objBV.PayID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IQueryable<AllPaymentsByStudent> ShowTotalPay(string sortColumn, string sortColumnDir, string Search, int Createdby)
        {
            var IQueryableTotalPay = (from tempbooking in _context.StudentPayment
                                     join p in _context.Registration on tempbooking.Createdby equals p.ID
                                     join f in _context.AllFee on tempbooking.FeeID equals f.FeeID
                                     join clas in _context.AddClass on f.ClassID equals clas.ClassID
                                     where tempbooking.Createdby == Createdby
                                     select new AllPaymentsByStudent
                                     {
                                         PayID = tempbooking.PayID,
                                         FeeID = tempbooking.FeeID,
                                         CardNum = tempbooking.CardNum,
                                         Name = p.Name,
                                         ClassName = clas.ClassName,
                                         FeeName = f.FeeName,
                                         Createdby = tempbooking.Createdby,
                                         CreatedDate = tempbooking.CreatedDate.Value.ToString("dd/MM/yyyy"),
                                         Amount = tempbooking.Amount,
                                         PaymentDetailID = tempbooking.PaymentDetailID
                                     });
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                //IQueryableReg = IQueryableReg.OrderBy(sortColumn + " " + sortColumnDir);
            }
            if (!string.IsNullOrEmpty(Search))
            {
                IQueryableTotalPay = IQueryableTotalPay.Where(m => m.CardNum == Search);
            }

            return IQueryableTotalPay;
        }
        public AllPaymentsByStudent GetTotalPayment(int Createdby)
        {
            //string Message;
            int? Current_year = DateTime.Now.Year;
            int? Current_mounth = DateTime.Now.Month;
            DateTime startDate = new DateTime(DateTime.Now.Year, 1, 1);
            
            int? TotalAmount = (from BD in _context.StudentPayment
                                   where BD.Createdby == Createdby && BD.CreatedDate.Value.Year == Current_year
                                   select BD.Amount).Sum();
            var Name = (from user in _context.Registration
                        where user.ID == Createdby
                        select new { user.Name, user.Username}).SingleOrDefault();

            int? PayableFeeYearly = (from pfee in _context.AllFee
                                  join user in _context.Registration on pfee.ClassID equals user.ClassID
                                  where pfee.FeeTimeID == 1 && user.ID == Createdby
                                  select pfee.FeeAmount).Sum();

            int? PayableTuitionFee = (from pfee in _context.AllFee
                                      join user in _context.Registration on pfee.ClassID equals user.ClassID
                                      where pfee.FeeTimeID == 2 && user.ID == Createdby
                                      select pfee.FeeAmount).Sum();
            int? TotalPayableAmount = PayableFeeYearly + (PayableTuitionFee * Current_mounth);
            int? TotalDueAmount = TotalPayableAmount - TotalAmount;

            AllPaymentsByStudent allpaymentsbystudent = new AllPaymentsByStudent()
            {

                TotalAmount = TotalAmount,
                TotalPayableAmount = TotalPayableAmount,
                Current_year = Current_year,
                First_date = startDate.ToString("dd MMMM yyyy"),
                TotalDueAmount = TotalDueAmount,
                Name = Name.Name,
                Username = Name.Username

            };
            
                return allpaymentsbystudent;
            
            
        }

        
    }
}
