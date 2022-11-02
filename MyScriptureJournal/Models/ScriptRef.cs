using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyScriptureJournal.Models
{
    public class ScriptRef
    {
        public int ID { get; set; }
        public string Canon { get; set; } = string.Empty;
        public string Book { get; set; } = string.Empty;
        public string Chapters { get; set; } = string.Empty;
        public string Verses { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;

        [Display(Name = "Create Date")]
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }
    }
}