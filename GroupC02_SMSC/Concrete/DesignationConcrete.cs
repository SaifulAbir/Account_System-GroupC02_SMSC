using GroupC02_SMSC.Interface;
using GroupC02_SMSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupC02_SMSC.Concrete
{
    public class DesignationConcrete : IDesignation
    {
        private DatabaseContext _context;

        public DesignationConcrete(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Designation> ShowAllDesignation()
        {
            return _context.Designation.ToList();
        }

        public DesignationVM Salaryinformation(int UserID)
        {
            var result = (from user in _context.Registration
                          join desig in _context.Designation on user.DesignationID equals desig.DesignationID
                          where user.ID == UserID
                          select new DesignationVM
                          {

                              Name = user.Name,
                              DesignationName = desig.DesignationName,
                              Salary = desig.Salary,
                              
                          }).SingleOrDefault();
            return result;
        }

        public void AddCashOut(int Createdby)
        {
            try
            {
                var sal = (from user in _context.Registration
                            join desig in _context.Designation on user.DesignationID equals desig.DesignationID
                            where user.ID == Createdby
                            select new { user.ID, desig.DesignationID, desig.Salary }).SingleOrDefault();
                CashOut co = new CashOut
                {
                    ID = sal.ID,
                    DesignationID = sal.DesignationID,
                    Salary = sal.Salary,
                    CashOutDate = DateTime.Now
                };
                _context.CashOut.Add(co);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IQueryable<CashOutVM> ShowAllCashOutbyTeacher(string sortColumn, string sortColumnDir, string Search, int Createdby)
        {
            var IQueryableCashOut = (from cout in _context.CashOut
                                     join p in _context.Registration on cout.ID equals p.ID
                                     join f in _context.Designation on cout.DesignationID equals f.DesignationID
                                     
                                     where p.ID == Createdby
                                     select new CashOutVM
                                     {
                                         CashOutID = cout.CashOutID,
                                         Name = p.Name,
                                         DesignationName = f.DesignationName,
                                         Salary = cout.Salary,
                                         CashOutDate = cout.CashOutDate.Value.ToString("dd/MM/yyyy"),
                                         
                                     });
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                //IQueryableReg = IQueryableReg.OrderBy(sortColumn + " " + sortColumnDir);
            }
            if (!string.IsNullOrEmpty(Search))
            {
                IQueryableCashOut = IQueryableCashOut.Where(m => m.Name == Search);
            }

            return IQueryableCashOut;
        }

        public IQueryable<CashOutVM> ShowAllCashOut(string sortColumn, string sortColumnDir, string Search)
        {
            var IQueryableAllCashOut= (from cout in _context.CashOut
                                       join p in _context.Registration on cout.ID equals p.ID
                                       join f in _context.Designation on cout.DesignationID equals f.DesignationID
                                       select new CashOutVM
                                         {
                                           CashOutID = cout.CashOutID,
                                           Name = p.Name,
                                           DesignationName = f.DesignationName,
                                           Salary = cout.Salary,
                                           CashOutDate = cout.CashOutDate.Value.ToString("dd/MM/yyyy"),
                                       });
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                //IQueryableReg = IQueryableReg.OrderBy(sortColumn + " " + sortColumnDir);
            }
            if (!string.IsNullOrEmpty(Search))
            {
                IQueryableAllCashOut = IQueryableAllCashOut.Where(m => m.Name == Search || m.Name == Search || m.DesignationName == Search);
            }

            return IQueryableAllCashOut;
        }
    }
}
