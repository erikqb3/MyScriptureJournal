using System.ComponentModel.DataAnnotations;

namespace MyScriptureJournal.Models
{
    public class Canon
    {
        public int CanonID { get; set; }
        public string CanonName { get; set; } = string.Empty;
    }
}