using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupC02_SMSC.Interface;
using GroupC02_SMSC.Models;

namespace GroupC02_SMSC.Concrete
{
    public class RegistrationConcrete : IRegistration
    {
        private DatabaseContext _context;

        public RegistrationConcrete(DatabaseContext context)
        {
            _context = context;
        }

        public void AddAdmin(Registration entity)
        {
            _context.Registration.Add(entity);
            _context.SaveChanges();
        }

        public int AddUser(Registration entity)
        {
            _context.Registration.Add(entity);
            return _context.SaveChanges();
        }

        public bool CheckUserNameExists(string Username)
        {
            var result = (from user in _context.Registration
                          where user.Username == Username
                          select user).Count();

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public RegistrationViewModel Userinformation(int UserID)
        {
            var result = (from user in _context.Registration
                          join clas in _context.AddClass on user.ClassID equals clas.ClassID
                          
                          where user.ID == UserID
                          select new RegistrationViewModel
                          {
                              
                              Name = user.Name,
                              Address = user.Address,
                              EmailID = user.EmailID,
                              Birthdate = user.Birthdate.Value.ToString("dd/MM/yyyy"),
                              Gender = user.Gender == "M" ? "Male" : "Female",
                              Mobileno = user.Mobileno,
                              Username = user.Username,
                              Password = user.Password,
                              ClassName = clas.ClassName,
                              

                          }).SingleOrDefault();
            return result;
        }

        public RegistrationViewModel Teacherinformation(int UserID)
        {
            var result = (from user in _context.Registration
                          
                          join desig in _context.Designation on user.DesignationID equals desig.DesignationID
                          where user.ID == UserID
                          select new RegistrationViewModel
                          {

                              Name = user.Name,
                              Address = user.Address,
                              EmailID = user.EmailID,
                              Birthdate = user.Birthdate.Value.ToString("dd/MM/yyyy"),
                              Gender = user.Gender == "M" ? "Male" : "Female",
                              Mobileno = user.Mobileno,
                              Username = user.Username,
                              Password = user.Password,
                              
                              DesignationName = desig.DesignationName

                          }).SingleOrDefault();
            return result;
        }

        public IQueryable<RegistrationViewModel> UserinformationList(string sortColumn, string sortColumnDir, string Search)
        {
            var IQueryableReg = (from user in _context.Registration
                                 join clas in _context.AddClass on user.ClassID equals clas.ClassID
                                 where user.RoleID == 2
                                 select new RegistrationViewModel
                                 {
                                     ID = user.ID,
                                     Name = user.Name,
                                     Address = user.Address,
                                     EmailID = user.EmailID,
                                     
                                     Birthdate = user.Birthdate.Value.ToString("dd/MM/yyyy"),
                                     Gender = user.Gender == "M" ? "Male" : "Female",
                                     Mobileno = user.Mobileno,
                                     Username = user.Username,
                                     ClassName = clas.ClassName
                                 });
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                //IQueryableReg = IQueryableReg.OrderBy(sortColumn + " " + sortColumnDir);
            }
            if (!string.IsNullOrEmpty(Search))
            {
                IQueryableReg = IQueryableReg.Where(m => m.Username == Search || m.Mobileno == Search || m.EmailID == Search);
            }

            return IQueryableReg;
        }
        public IQueryable<RegistrationViewModel> TeacherinformationList(string sortColumn, string sortColumnDir, string Search)
        {
            var IQueryableReg = (from user in _context.Registration
                                 join des in _context.Designation on user.DesignationID equals des.DesignationID
                                 where user.RoleID == 3
                                 select new RegistrationViewModel
                                 {
                                     ID = user.ID,
                                     Name = user.Name,
                                     Address = user.Address,
                                     EmailID = user.EmailID,

                                     Birthdate = user.Birthdate.Value.ToString("dd/MM/yyyy"),
                                     Gender = user.Gender == "M" ? "Male" : "Female",
                                     Mobileno = user.Mobileno,
                                     Username = user.Username,
                                     DesignationName = des.DesignationName
                                 });
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                //IQueryableReg = IQueryableReg.OrderBy(sortColumn + " " + sortColumnDir);
            }
            if (!string.IsNullOrEmpty(Search))
            {
                IQueryableReg = IQueryableReg.Where(m => m.Username == Search || m.Mobileno == Search || m.EmailID == Search);
            }

            return IQueryableReg;
        }
        public int DeleteStudent(int id)
        {
            try
            {
                Registration registration = _context.Registration.Find(id);
                _context.Registration.Remove(registration);
                return _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Registration GetStudentByID(int id)
        {
            if (id != 0)
            {
                return _context.Registration.Find(id);
            }
            else
            {
                return new Registration();
            }
        }
        public void UpdateStudent(Registration Registration)
        {
            try
            {

                
                _context.Entry(Registration).Property(x => x.Name).IsModified = true;
                    _context.Entry(Registration).Property(x => x.Address).IsModified = true;
                    _context.Entry(Registration).Property(x => x.EmailID).IsModified = true;
                    _context.Entry(Registration).Property(x => x.Birthdate).IsModified = true;
                    _context.Entry(Registration).Property(x => x.Gender).IsModified = true;
                    _context.Entry(Registration).Property(x => x.Mobileno).IsModified = true;
                    _context.Entry(Registration).Property(x => x.Username).IsModified = true;
                    _context.SaveChanges();
                
                
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
