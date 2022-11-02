using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages_ScriptCanon
{
    public class DeleteModel : PageModel
    {
        private readonly MyScriptureJournalContext _context;

        public DeleteModel(MyScriptureJournalContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Canon Canon { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Canon == null)
            {
                return NotFound();
            }

            var canon = await _context.Canon.FirstOrDefaultAsync(m => m.CanonID == id);

            if (canon == null)
            {
                return NotFound();
            }
            else 
            {
                Canon = canon;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Canon == null)
            {
                return NotFound();
            }
            var canon = await _context.Canon.FindAsync(id);

            if (canon != null)
            {
                Canon = canon;
                _context.Canon.Remove(Canon);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
