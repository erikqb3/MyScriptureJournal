using System.ComponentModel.DataAnnotations;

namespace MyScriptureJournal.Models
{
    public class Canon
    {
        public int CanonID { get; set; }
        public string canonName { get; set; } = string.Empty;

        public int bookCount { get; set; }
    }
}