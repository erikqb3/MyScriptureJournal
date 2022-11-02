using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages_ScriptRefs
{
    public class EditModel : PageModel
    {
        private readonly MyScriptureJournalContext _context;

        public EditModel(MyScriptureJournalContext context)
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

            var scriptref =  await _context.ScriptRef.FirstOrDefaultAsync(m => m.ID == id);
            if (scriptref == null)
            {
                return NotFound();
            }
            ScriptRef = scriptref;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ScriptRef).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScriptRefExists(ScriptRef.ID))
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

        private bool ScriptRefExists(int id)
        {
          return (_context.ScriptRef?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
