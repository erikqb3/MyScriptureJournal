using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyScriptureJournal.Models
{
    public class ScriptRef
    {
        public int ID { get; set; }

        // [Required]
        // public string Canon { get; set; } = string.Empty;

        [Required]
        public string Book { get; set; } = string.Empty;

        [StringLength(10, MinimumLength = 1)]
        [Required]
        public string Chapters { get; set; } = string.Empty;

        [StringLength(10, MinimumLength = 1)]
        [Required]
        public string Verses { get; set; } = string.Empty;

        [StringLength(1000, MinimumLength = 1)]
        public string Notes { get; set; } = string.Empty;

        [StringLength(255, MinimumLength = 1)]
        [Display(Name = "Small Notes")]
        public string lessNotes { get; set; } = string.Empty;


        [Display(Name = "Last Edited")]
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}