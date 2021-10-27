using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web.PageService;

namespace Web.Pages.TicketApp
{
    public class IndexModel : PageModel
    {
        private readonly Infrastructure.Data.AppDbContext _context;
        private readonly IRazorRenderService _renderService;

        public IndexModel(Infrastructure.Data.AppDbContext context, IRazorRenderService renderService)
        {
            _context = context;
            _renderService = renderService;

        }

        public void OnGet()
        {
        }


        //AJAX GET TABLE DATA
        public PartialViewResult OnGetViewTicketPartial()
        {
            var ticketList = _context.Tickets.AsEnumerable();

            return new PartialViewResult
            {
                ViewName = "_ViewTicket",
                ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IEnumerable<Core.Entities.Ticket>>(ViewData, ticketList)
            };

        }

        //AJAX GET MODAL 
        public async Task<JsonResult> OnGetCreateEdiTicketModal(int id)
        {
            if (id == 0)
            {
                //Create Modal

                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEditTicket", new Core.Entities.Ticket()) });
            }
            else
            {
                //Update Modal
                var thisTicket = _context.Tickets.Find(id);
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEditTicket", thisTicket) });

            }


        }

        public async Task<JsonResult> OnPostCreateEditTicket(int id, Core.Entities.Ticket ticket)
        {
            if (id == 0)
            {
                //Creating Ticket
                _context.Tickets.Add(ticket);
            }
            else
            {
                //Updating Ticket
                var editTicket = _context.Tickets.Find(id);
                editTicket.Title = ticket.Title;
                editTicket.Details = ticket.Details;
                editTicket.CreatedBy = ticket.CreatedBy;
                editTicket.DateCreated = ticket.DateCreated;
            }
            await _context.SaveChangesAsync();
            var ticketList = _context.Tickets.AsEnumerable();
            return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_ViewTicket", ticketList) });

        }


        public async Task<JsonResult> OnPostDeleteAsync(int id)
        {
        
            if(id != 0)
            {
                var ticket =  await _context.Tickets.FindAsync(id);
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }

            var ticketList = _context.Tickets.AsEnumerable();
            return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_ViewTicket", ticketList) });

        }

    }

}
