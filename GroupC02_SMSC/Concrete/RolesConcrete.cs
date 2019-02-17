using GroupC02_SMSC.Interface;
using GroupC02_SMSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupC02_SMSC.Concrete
{
    
        public class RolesConcrete : IRoles
        {
            private DatabaseContext _context;

            public RolesConcrete(DatabaseContext context)
            {
                _context = context;
            }
        public int getRolesofUserbyRolename(string Rolename)
        {
            var roleID = (from role in _context.Roles
                          where role.Rolename == Rolename
                          select role.RoleID).SingleOrDefault();

            return roleID;
        }
        public IEnumerable<Roles> ShowAllRole()
        {
            return _context.Roles.ToList();
        }
    }
}
