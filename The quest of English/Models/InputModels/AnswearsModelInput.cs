using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_quest_of_English.Models.InputModels
{
    public class AnswearsModelInput
    {
        [Required]
        [StringLength(200, ErrorMessage = "The answear can contain only 200 signs!")]
        public string FirstAnswear { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "The answear can contain only 200 signs!")]
        public string SecondAnswear { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "The answear can contain only 200 signs!")]
        public string ThirdAnswear { get; set; }
        [StringLength(200, ErrorMessage = "The answear can contain only 200 signs!")]
        public string FourthAnswear { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "The answear can contain only 200 signs!")]
        public string CorrectAnswear { get; set; }
    }
}
