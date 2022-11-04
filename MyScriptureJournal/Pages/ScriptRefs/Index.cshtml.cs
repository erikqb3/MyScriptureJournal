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

        public IList<ScriptRef> ScriptRef { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string ? SearchString { get; set; }
        public SelectList ? Canon { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ? StandardWorks { get; set;}


        // public async Task OnGetAsync()
        // {
        //     if (_context.ScriptRef != null)
        //     {
        //         ScriptRef = await _context.ScriptRef.ToListAsync();
        //     }
        // }

        public async Task OnGetAsync()
        {
            IQueryable<string>canonQuery = from r in _context.ScriptRef
                                            orderby r.Canon
                                            select r.Canon;


            var refs = from r in _context.ScriptRef
                        select r;
            if (!string.IsNullOrEmpty(SearchString))
            {
                refs = refs.Where(s => s.Canon.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(StandardWorks))
            {
                refs= refs.Where(s => s.Canon == StandardWorks);
            }

            Canon = new SelectList(await canonQuery.Distinct().ToListAsync());
            ScriptRef = await refs.ToListAsync();
        }
    }
}
