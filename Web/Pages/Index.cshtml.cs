using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Pages
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public IndexModel(ILogger<IndexModel> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var isInRole = await _userManager.GetRolesAsync(user);

                if (isInRole.Count >= 1)
                {
                    if (isInRole.First().StartsWith("Admin"))
                    {
                        return RedirectToPage("/Admin/Index");
                    }
                    else if (isInRole.First().StartsWith("User"))
                    {
                        return RedirectToPage("/EndUser/Index");
                    }
                    //else if (isInRole.First().StartsWith("Tutor"))
                    //{
                    //    return RedirectToPage("/Tutor/Index");
                    //}
                    else
                    {
                        //Users with multiple roles i.e. Admin and Employees should redirect to the Admin Page.
                        return RedirectToPage("/Index");
                    }

                }
                else
                {
                    return RedirectToPage("/Index");

                    //Users with multiple roles i.e. Admin and Employees should redirect to the Admin Page.
                }
            }
            else
            {
                return Page();

            }
        }
    }
}
