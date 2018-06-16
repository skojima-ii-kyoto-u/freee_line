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
    public class DeleteModel : PageModel
    {
        private readonly Lineee.Models.TalkContext _context;

        public DeleteModel(Lineee.Models.TalkContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Talk = await _context.Talk.FindAsync(id);

            if (Talk != null)
            {
                _context.Talk.Remove(Talk);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
