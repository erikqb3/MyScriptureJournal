using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages_ScriptRefs
{
    public class CreateModel : PageModel
    {
        private readonly MyScriptureJournalContext _context;

        public CreateModel(MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ScriptRef ScriptRef { get; set; } = default!;
        
        
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var newLength = 255;
            if (ScriptRef.Notes.Length < newLength) {
                newLength = ScriptRef.Notes.Length;
            }
            ScriptRef.lessNotes = ScriptRef.Notes.Substring(0,newLength);
            ScriptRef.CreateDate = DateTime.Now;
            Console.WriteLine(ScriptRef.CreateDate);
            Console.WriteLine(ScriptRef.lessNotes);

          if (!ModelState.IsValid)
            {
                // Console.WriteLine(ModelState);
               var modalErrors = string.Join(" + ", ModelState.Values.Where(E => E.Errors.Count > 0).SelectMany(E => E.Errors).Select(E => E.ErrorMessage).ToArray());
               Console.WriteLine(modalErrors);
                return Page();
            }

            _context.ScriptRef.Add(ScriptRef);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        
    }
}
