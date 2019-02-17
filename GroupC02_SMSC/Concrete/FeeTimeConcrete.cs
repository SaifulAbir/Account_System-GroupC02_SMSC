using GroupC02_SMSC.Interface;
using GroupC02_SMSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupC02_SMSC.Concrete
{
    public class FeeTimeConcrete : IFeeTime
    {
        private DatabaseContext _context;

        public FeeTimeConcrete(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<FeeTime> ShowAllFeeTime()
        {
            return _context.FeeTime.ToList();
        }
    }
}
