using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroupC02_SMSC.Models
{
    [NotMapped]
    public class RegistrationViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Mobileno { get; set; }

        public string EmailID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Gender { get; set; }

        public string Birthdate { get; set; }

        public string ClassName { get; set; }

        public int? RoleID { get; set; }

        public int? ClassID { get; set; }

        public string DesignationName { get; set; }


    }
}
