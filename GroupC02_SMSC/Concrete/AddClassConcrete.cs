using GroupC02_SMSC.Interface;
using GroupC02_SMSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupC02_SMSC.Concrete
{
    public class AddClassConcrete : IAddClass
    {
        private DatabaseContext _context;

        public AddClassConcrete(DatabaseContext context)
        {
            _context = context;
        }

        public void SaveClass(AddClass addClass)
        {
            try
            {
                _context.AddClass.Add(addClass);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<AddClass> ShowAllClass()
        {
            return _context.AddClass.ToList();
        }
        public AddClass AddClassByID(int id)
        {
            try
            {
                AddClass addClass = _context.AddClass.Find(id);
                return addClass;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<AddClassVM> ClassList(string sortColumn, string sortColumnDir, string Search)
        {
            var IQueryableClass = (from classlist in _context.AddClass
                                 
                                 select new AddClassVM
                                 {
                                     ClassID = classlist.ClassID,
                                     ClassName = classlist.ClassName
                                     
                                 });
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                //IQueryableReg = IQueryableReg.OrderBy(sortColumn + " " + sortColumnDir);
            }
            if (!string.IsNullOrEmpty(Search))
            {
                IQueryableClass = IQueryableClass.Where(m => m.ClassName == Search);
            }

            return IQueryableClass;
        }
    }
}
