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
        public string Title { get; set; }
        [Display(Name="Created")]
        [UIHint("Starred")]
        public bool IsStarred { get; set; }
        public DateTimeOffset CreateUtc { get; set; }
    }
}