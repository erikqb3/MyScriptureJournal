using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages_ScriptRefs
{
    public class DeleteModel : PageModel
    {
        private readonly MyScriptureJournalContext _context;

        public DeleteModel(MyScriptureJournalContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ScriptRef ScriptRef { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ScriptRef == null)
            {
                return NotFound();
            }

            var scriptref = await _context.ScriptRef.FirstOrDefaultAsync(m => m.ID == id);

            if (scriptref == null)
            {
                return NotFound();
            }
            else 
            {
                ScriptRef = scriptref;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ScriptRef == null)
            {
                return NotFound();
            }
            var scriptref = await _context.ScriptRef.FindAsync(id);

            if (scriptref != null)
            {
                ScriptRef = scriptref;
                _context.ScriptRef.Remove(ScriptRef);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
