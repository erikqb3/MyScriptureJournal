using Microsoft.EntityFrameworkCore;
// using MyScriptureJournal.Data;

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

                // Look for any movies.
                if (context.ScriptRef.Any())
                {
                    return;   // DB has been seeded
                }

                context.ScriptRef.AddRange(
                    new ScriptRef
                    {
                        Book = "1 Nephi",
                        Chapters = "3",
                        Verses = "7",
                        CreateDate = DateTime.Parse("1989-2-12"),
                        Notes = "And it came to pass that I, Nephi, said unto my father: I awill go and do the things which the Lord hath commanded, for I know that the Lord giveth no bcommandments unto the children of men, save he shall cprepare a way for them that they may accomplish the thing which he commandeth them."
                    },

                    new ScriptRef
                    {
                        Book = "Ether",
                        Chapters = "12",
                        Verses = "6",
                        CreateDate = DateTime.Parse("1984-3-13"),
                        Notes = "And now, I, Moroni, would speak somewhat concerning these things; I would show unto the world that afaith is things which are bhoped for and cnot seen; wherefore, dispute not because ye see not, for ye receive no dwitness until after the etrial of your faith."
                    },

                    new ScriptRef
                    {
                        Book = "3 Nephi",
                        Chapters = "27",
                        Verses = "27",
                        CreateDate = DateTime.Parse("1986-2-23"),
                        Notes = "And know ye that aye shall be bjudges of this people, according to the judgment which I shall give unto you, which shall be just. Therefore, what cmanner of men ought ye to be? Verily I say unto you, even das I am."
                    },

                    new ScriptRef
                    {
                        Book = "Moroni",
                        Chapters = "10",
                        Verses = "3-5",
                        CreateDate = DateTime.Parse("1959-4-15"),
                        Notes = "Behold, I would exhort you that when ye shall read these things, if it be wisdom in God that ye should read them, that ye would remember how amerciful the Lord hath been unto the children of men, from the creation of Adam even down until the time that ye shall receive these things, and bponder it in your chearts. And when ye shall receive these things, I would exhort you that ye would aask God, the Eternal Father, in the name of Christ, if these things are not btrue; and if ye shall ask with a csincere heart, with dreal intent, having efaith in Christ, he will fmanifest the gtruth of it unto you, by the power of the Holy Ghost. And by the power of the Holy Ghost ye may aknow the btruth of all things."
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
//           if (context == null || context.ScriptRef == null)
//           {
//             throw new ArgumentNullException("Null MyScriptureJournalContext");
//           }
//           if (context.ScriptRef.Any())
//           {
//             return;
//           }

//           context.ScriptRef.AddRange(
//             new ScriptRef
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