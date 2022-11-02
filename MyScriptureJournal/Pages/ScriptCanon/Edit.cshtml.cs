using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages_ScriptCanon
{
    public class EditModel : PageModel
    {
        private readonly MyScriptureJournalContext _context;

        public EditModel(MyScriptureJournalContext context)
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

            var canon =  await _context.Canon.FirstOrDefaultAsync(m => m.CanonID == id);
            if (canon == null)
            {
                return NotFound();
            }
            Canon = canon;
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

            _context.Attach(Canon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CanonExists(Canon.CanonID))
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

        private bool CanonExists(int id)
        {
          return (_context.Canon?.Any(e => e.CanonID == id)).GetValueOrDefault();
        }
    }
}
