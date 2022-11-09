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
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournalContext context)
        {
            _context = context;
        }

        // public IList<CanonSeed> canonSeeds{ get;set; } = default!;

        public IList<ScriptRef> ScriptRef { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string ? SearchString { get; set; }
        public SelectList ? Books { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ? SearchBooks { get; set;}


        // public async Task OnGetAsync()
        // {
        //     if (_context.ScriptRef != null)
        //     {
        //         ScriptRef = await _context.ScriptRef.ToListAsync();
        //     }
        // }

        public async Task OnGetAsync()
        {
            IQueryable<string>bookQuery = from r in _context.ScriptRef
                                            orderby r.Book
                                            select r.Book;

            IQueryable<System.DateTime>dateQuery = from r in _context.ScriptRef
                                            orderby r.CreateDate descending
                                            select r.CreateDate;

            Console.WriteLine(bookQuery);

            var refs = from r in _context.ScriptRef
                        select r;
            if (!string.IsNullOrEmpty(SearchString))
            {
                refs = refs.Where(s => s.Notes.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(SearchBooks))
            {
                refs= refs.Where(s => s.Book == SearchBooks);
            }


            Books = new SelectList(await bookQuery.Distinct().ToListAsync());
            // await dateQuery.Distinct().ToListAsync();

            ScriptRef = await refs.ToListAsync();
        }
    }
}
