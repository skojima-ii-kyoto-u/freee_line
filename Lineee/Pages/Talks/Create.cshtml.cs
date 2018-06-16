using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lineee.Models;

namespace Lineee.Pages.Talks
{
    public class CreateModel : PageModel
    {
        private readonly Lineee.Models.TalkContext _context;

        public CreateModel(Lineee.Models.TalkContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Talk Talk { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Talk.Add(Talk);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}