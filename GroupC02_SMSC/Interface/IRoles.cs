using GroupC02_SMSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupC02_SMSC.Interface
{
    public interface IRoles
    {
        //int getRolesofUserbyRolename(string Rolename);
        IEnumerable<Roles> ShowAllRole();
    }
}
