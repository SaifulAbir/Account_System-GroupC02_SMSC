using GroupC02_SMSC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupC02_SMSC.Concrete
{
   
    
        public class DatabaseContext : DbContext
        {
            public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
            {

            }

            public DbSet<Registration> Registration { get; set; }
            public DbSet<Roles> Roles { get; set; }
            public DbSet<Payment> Payment { get; set; }
            public DbSet<PaymentDetails> PaymentDetails { get; set; }
            public DbSet<AddClass> AddClass { get; set; }
            public DbSet<StudentPayment> StudentPayment { get; set; }
            public DbSet<AllFee> AllFee { get; set; }
            public DbSet<AllPaymentsByStudent> AllPaymentsByStudent { get; set; }
            public DbSet<FeeTime> FeeTime { get; set; }
            public DbSet<Designation> Designation { get; set; }
            public DbSet<CashOut> CashOut { get; set; }



    }
}

