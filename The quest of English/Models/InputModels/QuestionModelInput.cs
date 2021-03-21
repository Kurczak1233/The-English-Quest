using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_quest_of_English.Models.InputModels
{
    public class QuestionModelInput
    {
        [Required]
        [StringLength(400, ErrorMessage = "The question can contain only 400 signs!")]
        public string QuestionFirstPart { get; set; }
        [StringLength(100, ErrorMessage = "The decoration part can contain only 100 signs!")]
        public string QuestionDecoratedPart { get; set; }
        [StringLength(400, ErrorMessage = "The question can contain only 400 signs!")]
        public string QuestionSecondPart { get; set; }
    }
}
