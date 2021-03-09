using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheEnglishQuestDatabase.Entities
{
    public class EncouragementPosition
    { 
        [Required]
        public string Content { get; set; }
        [Required]
        public string ReferenceToCollapse  { get; set; }
        [Required]
        public string HtmlIdName { get; set; }
    }
}
