using Microsoft.EntityFrameworkCore;
// using MyScriptureJournal.Data;

namespace MyScriptureJournal.Models
{
    public static class CanonSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyScriptureJournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyScriptureJournalContext>>()))
            {
                if (context == null || context.Canon == null)
                {
                    throw new ArgumentNullException("Null MyScriptureJournalContext");
                }

                // Look for any movies.
                if (context.Canon.Any())
                {
                    return;   // DB has been seeded
                }

                context.Canon.AddRange(
                    new Canon
                    {
                        canonName = "Old Testament",
                        bookCount = 41
                    },

                    new Canon
                    {
                        canonName = "New Testament",
                        bookCount = 28
                    },

                    new Canon
                    {
                        canonName = "Book of Mormon",
                        bookCount = 16
                    },

                    new Canon
                    {
                        canonName = "Doctrine and Covenants",
                        bookCount = 1
                    },
                    new Canon
                    {
                        canonName = "Pearl of Great Price",
                        bookCount = 5
                    }
                );
                context.SaveChanges();
            }
        }
    }
}


























// using System.ComponentModel.DataAnnotations;
// using Microsoft.EntityFrameworkCore;


// namespace MyScriptureJournal.Models
// {
//     public static class SeedData
//     {
//         public static void Initialize(IServiceProvider serviceProvider)
//         {
//           using (var context = new MyScriptureJournalContext(
//             serviceProvider.GetRequiredService<
//               DbContextOptions<MyScriptureJournalContext>>()))
//         {
//           if (context == null || context.Canon == null)
//           {
//             throw new ArgumentNullException("Null MyScriptureJournalContext");
//           }
//           if (context.Canon.Any())
//           {
//             return;
//           }

//           context.Canon.AddRange(
//             new Canon
//             {
//               Canon = "Old Testament",
//               Book = "Genesis",
//               Chapters = "1",
//               Verses = "1",
//               CreateDate = DateTime.Now
//             }
//           );
//           context.SaveChanges();

//         }
        
//         }
//     }
// }