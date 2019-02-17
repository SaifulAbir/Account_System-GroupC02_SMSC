using GroupC02_SMSC.Interface;
using GroupC02_SMSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupC02_SMSC.Concrete
{
    public class AllFeeConcrete : IAllFee
    {
        private DatabaseContext _context;

        public AllFeeConcrete(DatabaseContext context)
        {
            _context = context;
        }

        public void SaveFee(AllFee allFee)
        {
            try
            {
                _context.AllFee.Add(allFee);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<AllFee> ShowAllFee()
        {
            return _context.AllFee.ToList();
        }
        public AllFee AddFeeByID(int id)
        {
            try
            {
                AllFee allFee = _context.AllFee.Find(id);
                return allFee;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<AllFeeVM> FeeList(string sortColumn, string sortColumnDir, string Search)
        {
            var IQueryableFee = (from feelist in _context.AllFee
                                   join clas in _context.AddClass on feelist.ClassID equals clas.ClassID
                                   join feet in _context.FeeTime on feelist.FeeTimeID equals feet.FeeTimeID
                                   select new AllFeeVM
                                   {
                                       FeeID = feelist.FeeID,
                                       ClassName = clas.ClassName,
                                       FeeName = feelist.FeeName,
                                       FeeAmount = feelist.FeeAmount,
                                       FeeTimeName = feet.FeeTimeName
                                       

                                   });
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                //IQueryableReg = IQueryableReg.OrderBy(sortColumn + " " + sortColumnDir);
            }
            if (!string.IsNullOrEmpty(Search))
            {
                IQueryableFee = IQueryableFee.Where(m => m.ClassName == Search || m.FeeName == Search);
            }

            return IQueryableFee;
        }
    }
}
