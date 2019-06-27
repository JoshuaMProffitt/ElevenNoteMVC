using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElevenNote.Models
{
    public class NoteListItem
    {
        public int NoteID { get; set; }
        [Display(Name = "Created")]
        public string Title { get; set; }
        [UIHint("Starred")]
        [Display(Name = "Important")]
        public bool IsStarred { get; set; }
        public DateTimeOffset CreateUtc { get; set; }
    }
}