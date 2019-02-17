using GroupC02_SMSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupC02_SMSC.Interface
{
    public interface IRegistration
    {
        int AddUser(Registration entity);
        void AddAdmin(Registration entity);
        bool CheckUserNameExists(string Username);
        RegistrationViewModel Userinformation(int UserID);
        RegistrationViewModel Teacherinformation(int UserID);
        IQueryable<RegistrationViewModel> UserinformationList(string sortColumn, string sortColumnDir, string Search);
        IQueryable<RegistrationViewModel> TeacherinformationList(string sortColumn, string sortColumnDir, string Search);
        int DeleteStudent(int id);
        Registration GetStudentByID(int id);
        void UpdateStudent(Registration Registration);
    }
}
