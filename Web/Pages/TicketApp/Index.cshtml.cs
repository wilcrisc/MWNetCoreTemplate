using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.TicketApp
{
    public class IndexModel : PageModel
    {
        private readonly Infrastructure.Data.AppDbContext _context;

        public IndexModel(Infrastructure.Data.AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public PartialViewResult OnGetViewTicketPartial()
        {
            var ticketList = _context.Tickets.AsEnumerable();

            return new PartialViewResult
            {
                ViewName = "_ViewTicket",
                ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IEnumerable<Core.Entities.Ticket>>(ViewData, ticketList)
            };

        }

    }
}
