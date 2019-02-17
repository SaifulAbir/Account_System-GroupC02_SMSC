using GroupC02_SMSC.Interface;
using GroupC02_SMSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupC02_SMSC.Concrete
{
    public class LoginConcrete :ILogin
    {
        private DatabaseContext _context;

        public LoginConcrete(DatabaseContext context)
        {
            _context = context;
        }

        public Registration ValidateUser(string userName, string passWord)
        {
            try
            {
                var validate = (from user in _context.Registration
                                where user.Username == userName && user.Password == passWord
                                select user).SingleOrDefault();

                return validate;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
