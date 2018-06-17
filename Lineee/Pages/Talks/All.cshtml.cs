using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lineee.Models;

namespace Lineee.Pages.Talks
{
    public class AllModel : PageModel
    {
        private readonly AccountContext _accContext;

        public IList<Account> AccountList { get; set; }
        public string MyName { get; set; }

        public AllModel(AccountContext accountContext)
        {
            _accContext = accountContext;
        }
        
        [HttpGet("{id}")]
        public async Task OnGetAsync(int id)
        {
            MyName = (await _accContext.Account.FindAsync(id)).Name;
            AccountList = await _accContext.Account.ToListAsync();
        }
    }
}