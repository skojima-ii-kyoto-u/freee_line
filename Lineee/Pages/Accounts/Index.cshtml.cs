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
    public class IndexModel : PageModel
    {
        private readonly Lineee.Models.AccountContext _context;

        public IndexModel(Lineee.Models.AccountContext context)
        {
            _context = context;
        }

        public IList<Account> Account { get;set; }

        public async Task OnGetAsync()
        {
            Account = await _context.Account.ToListAsync();
        }
    }
}
