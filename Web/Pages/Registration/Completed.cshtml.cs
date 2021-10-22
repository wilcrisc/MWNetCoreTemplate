using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Registration
{
    public class CompletedModel : PageModel
    {
        public string Name { get; set; }
        public void OnGet(string name)
        {
            Name = name;
        }
    }
}
