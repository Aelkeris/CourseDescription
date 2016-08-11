using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OpisKolegija2.Models
{
    public partial class Assistents
    {
        [Key]
        public int AssistentId { get; set; }
        public string Assistent { get; set; }
    }
}
