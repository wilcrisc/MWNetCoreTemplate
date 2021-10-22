using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class AppUser : IdentityUser
    {

        public AppUser()
        {
            DateRegistered = DateTime.Now;
        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        //public string Suffix { get; set; }
        //public string Gender { get; set; }
        //public string Nationality { get; set; }
        //[DataType(DataType.Date)]
        //public DateTime BirthDate { get; set; }

        public string UserType { get; set; }


        [Required]
        public bool IsGranted { get; set; }

        [Required]
        public bool UserStatus { get; set; }

        [Required]
        public DateTime DateRegistered { get; set; }


        public string AppUserName { get { return LastName + ", " + FirstName; } }
  

    }

}
