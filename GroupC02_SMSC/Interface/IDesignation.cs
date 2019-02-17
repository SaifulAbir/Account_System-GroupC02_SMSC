using GroupC02_SMSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupC02_SMSC.Interface
{
    public interface IDesignation
    {
        //void SaveClass(AddClass addClass);
        IEnumerable<Designation> ShowAllDesignation();
        //AddClass AddClassByID(int id);
        DesignationVM Salaryinformation(int UserID);
        void AddCashOut(int Createdby);
        IQueryable<CashOutVM> ShowAllCashOutbyTeacher(string sortColumn, string sortColumnDir, string Search, int Createdby);
        IQueryable<CashOutVM> ShowAllCashOut(string sortColumn, string sortColumnDir, string Search);
    }
}
