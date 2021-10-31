using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
                ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IEnumerable<Ticket>>(ViewData, ticketList)
            };

        }

        public async Task<JsonResult> OnGetViewTicketJSONPartial()
        {
            var ticketList = _context.Tickets.AsEnumerable();
            return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_ViewTicket", ticketList) });

        }
        public async Task<JsonResult> OnGetViewTicketJSONPartialDelayed()
        {
            //Fake Delay
            await Task.Delay(5000);
            var ticketList = _context.Tickets.AsEnumerable();
            return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_ViewTicket", ticketList) });
        }

        //AJAX GET MODAL 
        public async Task<JsonResult> OnGetCreateEdiTicketModal(int id)
        {


            if (id == 0)
            {
                //Create Modal
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEditTicket", new Ticket()) });
            }
            else
            {
                //Update Modal
                var thisTicket = _context.Tickets.Find(id);
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEditTicket", thisTicket) });

            }


        }

        public async Task<JsonResult> OnPostCreateEditTicket(int id, Ticket ticket)
        {
            await Task.Delay(2000);

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

            return new JsonResult(new { action = id, html = await _renderService.ToStringAsync("_ViewTicket", ticketList) });
        }

        public async Task<JsonResult> OnPostDeleteAsync(int id)
        {

            if (id != 0)
            {
                var ticket = await _context.Tickets.FindAsync(id);
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }

            var ticketList = _context.Tickets.AsEnumerable();
            return new JsonResult(new { html = await _renderService.ToStringAsync("_ViewTicket", ticketList) });

        }

    }

}
