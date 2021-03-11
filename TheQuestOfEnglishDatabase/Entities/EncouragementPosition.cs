using System.ComponentModel.DataAnnotations;
using TheQuestOfEnglishDatabase;

namespace TheEnglishQuestDatabase.Entities
{
    public class EncouragementPosition
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ReferenceToCollapse  { get; set; }
        [Required]
        public string HtmlIdName { get; set; }
    }
}
