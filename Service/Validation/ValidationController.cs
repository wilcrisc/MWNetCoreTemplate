using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Service.Validation
{
    public class ValidationController : Controller
    {
        private readonly AppDbContext _context;

        public ValidationController(AppDbContext context)
        {
            _context = context;
        }
   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult CheckEmail(string Email)
        {
            bool code = true;
            var EmailCheck = _context.AppUsers.AsNoTracking().Where(d => d.Email.Equals(Email)).ToList();
            if (EmailCheck.Count != 0)
            {
                code = false;
            }
            return new JsonResult(code);
        }

    }
}