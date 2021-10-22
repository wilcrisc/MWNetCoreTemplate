using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Admin.Users
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public class AppUserViewModel
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Gender { get; set; }
            public string PhoneNumber { get; set; }
            public string UserType { get; set; }
        }

        public IList<AppUserViewModel> AppUsers { get; set; }

        public void OnGet()
        {
            AppUsers = _context.AppUsers.Select(x => new AppUserViewModel
            {
                Name = x.FirstName + " " + x.LastName,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
                UserType = x.UserType,
                Id = x.Id

            }).ToList();

        }
    }
}
