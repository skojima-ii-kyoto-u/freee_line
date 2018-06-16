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
    public class DetailsModel : PageModel
    {
        private readonly Lineee.Models.TalkContext _context;

        public DetailsModel(Lineee.Models.TalkContext context)
        {
            _context = context;
        }

        public Talk Talk { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Talk = await _context.Talk.SingleOrDefaultAsync(m => m.ID == id);

            if (Talk == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
