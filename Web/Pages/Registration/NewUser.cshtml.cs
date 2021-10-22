using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace Web.Pages.Registration
{
    [AllowAnonymous]
    public class NewUserModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<NewUserModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly AppDbContext _context;


        public NewUserModel(
           UserManager<AppUser> userManager,
           SignInManager<AppUser> signInManager,
           ILogger<NewUserModel> logger,
           IEmailSender emailSender,
           AppDbContext context

            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;

        }

        public class InputModel
        {
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Display(Name = "Middle Name")]
            public string MiddleName { get; set; }

            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Display(Name = "Suffix")]
            public string Suffix { get; set; }

            [Display(Name = "Gender")]
            public string Gender { get; set; }

            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Nationality")]
            public string Nationality { get; set; }

            [Display(Name = "Date Of Birth")]
            [DataType(DataType.Date)]
            public DateTime BirthDate { get; set; }

            public string School { get; set; }

            [Display(Name = "Level of Education")]
            public string LevelEducation { get; set; }


            [EmailAddress]
            [Display(Name = "Email Address")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }
        public string ReturnUrl { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        [BindProperty]
        [Remote("CheckEmail", "validation", ErrorMessage = "Email Address already exists.", AdditionalFields = "__RequestVerificationToken", HttpMethod = "post")]
        [Required]
        public string Email { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = Email,
                    Email = Email,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    MiddleName = Input.MiddleName,
                    PhoneNumber = Input.PhoneNumber,
                    UserStatus = true,
                    IsGranted = true,
                    UserType = "User"

                };

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {

                    await _userManager.AddToRoleAsync(user, "User");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        //await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToPage("./Completed", new { name = Input.FirstName });
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
