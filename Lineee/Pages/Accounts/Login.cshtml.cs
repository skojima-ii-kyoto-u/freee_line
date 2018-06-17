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
    public class LoginModel : PageModel
    {
        private readonly AccountContext _context;

        public LoginModel(AccountContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var target = await _context.Account.SingleOrDefaultAsync(m => m.Name == Account.Name);

            if (target != null)
            {
                return RedirectToPage("../Talks/All", new { id = target.ID });
            }
            else
            {
                _context.Account.Add(Account);
                await _context.SaveChangesAsync();

                target = await _context.Account.SingleOrDefaultAsync(m => m.Name == Account.Name);
                return RedirectToPage("../Talks/All", new { id = target.ID });
            }
        }
    }
}