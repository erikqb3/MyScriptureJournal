using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace MyScriptureJournal.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
          using (var context = new MyScriptureJournalContext(
            serviceProvider.GetRequiredService<
              DbContextOptions<MyScriptureJournalContext>>()))
        {
          if (context == null || context.ScriptRef == null)
          {
            throw new ArgumentNullException("Null MyScriptureJournalContext");
          }
          if (context.ScriptRef.Any())
          {
            return;
          }

          context.ScriptRef.AddRange(
            new ScriptRef
            {
              Canon = "Old Testament",
              Book = "Genesis",
              Chapters = "1",
              Verses = "1",
              CreateDate = DateTime.Now
            }
          );
          context.SaveChanges();

        }
        
        }
    }
}