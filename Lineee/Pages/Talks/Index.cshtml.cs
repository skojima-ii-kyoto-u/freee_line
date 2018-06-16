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
    public class IndexModel : PageModel
    {
        private readonly Lineee.Models.TalkContext _context;

        public IndexModel(Lineee.Models.TalkContext context)
        {
            _context = context;
        }

        public IList<Talk> Talk { get;set; }

        public async Task OnGetAsync()
        {
            Talk = await _context.Talk.ToListAsync();
        }
    }
}
