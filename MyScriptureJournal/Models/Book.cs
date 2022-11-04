using System.ComponentModel.DataAnnotations;

namespace MyScriptureJournal.Models
{
    public class Book
    {
        public int bookID { get; set; }
        public string bookName { get; set; } = string.Empty;

        public int verseCount { get; set; }

    }
}