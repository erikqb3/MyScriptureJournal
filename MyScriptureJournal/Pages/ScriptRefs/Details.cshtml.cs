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
    public class DetailsModel : PageModel
    {
        private readonly MyScriptureJournalContext _context;

        public DetailsModel(MyScriptureJournalContext context)
        {
            _context = context;
        }

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
    }
}
