using GroupC02_SMSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupC02_SMSC.Interface
{
    public interface IAllFee
    {
        void SaveFee(AllFee allFee);
        IEnumerable<AllFee> ShowAllFee();
        AllFee AddFeeByID(int id);
        IQueryable<AllFeeVM> FeeList(string sortColumn, string sortColumnDir, string Search);
    }
}
