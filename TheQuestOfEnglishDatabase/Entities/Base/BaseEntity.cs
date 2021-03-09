using System.ComponentModel.DataAnnotations;

namespace TheQuestOfEnglishDatabase
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
