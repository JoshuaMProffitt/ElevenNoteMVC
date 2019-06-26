using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Data
{
    public class Note
    {
        [Key]
        public int NoteID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        //[Range(1, 5, ErrorMessage = "please choose a number between 1 and 5")]
        //[MaxLength(100, ErrorMessage = "There are too many characters in this field.")]

        public string Title { get; set; }
        [Required]
        [Display(Name = "Your Note")]
        public string Content { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
