using GroupC02_SMSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupC02_SMSC.Interface
{
    public interface ILogin
    {
        Registration ValidateUser(string userName, string passWord);
        //bool UpdatePassword(Registration Registration);
    }
}
