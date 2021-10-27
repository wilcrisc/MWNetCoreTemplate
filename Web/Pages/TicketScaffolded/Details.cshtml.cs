using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infrastructure.Data;

namespace Web.Pages.TicketScaffolded
{
    public class DetailsModel : PageModel
    {
        private readonly Infrastructure.Data.AppDbContext _context;

        public DetailsModel(Infrastructure.Data.AppDbContext context)
        {
            _context = context;
        }

        public Ticket Ticket { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ticket = await _context.Tickets.FirstOrDefaultAsync(m => m.TicketID == id);

            if (Ticket == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
