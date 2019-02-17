using GroupC02_SMSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupC02_SMSC.Interface
{
    public interface IAddClass
    {
        void SaveClass(AddClass addClass);
        IEnumerable<AddClass> ShowAllClass();
        AddClass AddClassByID(int id);
        IQueryable<AddClassVM> ClassList(string sortColumn, string sortColumnDir, string Search);
    }
}
