using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lineee.Models;

namespace Lineee.Pages.Talks
{
    public class EditModel : PageModel
    {
        private readonly Lineee.Models.TalkContext _context;

        public EditModel(Lineee.Models.TalkContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Talk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TalkExists(Talk.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TalkExists(int id)
        {
            return _context.Talk.Any(e => e.ID == id);
        }
    }
}
