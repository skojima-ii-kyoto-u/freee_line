using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lineee.Models;

namespace Lineee.Pages.Accounts
{
    public class DetailsModel : PageModel
    {
        private readonly Lineee.Models.AccountContext _context;

        public DetailsModel(Lineee.Models.AccountContext context)
        {
            _context = context;
        }

        public Account Account { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Account = await _context.Account.SingleOrDefaultAsync(m => m.ID == id);

            if (Account == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
