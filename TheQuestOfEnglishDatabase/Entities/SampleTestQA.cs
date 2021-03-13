using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheEnglishQuestDatabase.Entities
{
    public class SampleTestQA
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Question { get; set; }
        public string Question2 { get; set; }
        public string QuestionDecorationPart { get; set; }
        [Required]
        public string FirstQuestionRadioName { get; set; }
        [Required]
        public string FirstQuestionId { get; set; }
        [Required]
        public string FirstQuestionAnswear { get; set; }
        [Required]
        public string SecondQuestionRadioName { get; set; }
        [Required]
        public string SecondQuestionId { get; set; }
        [Required]
        public string SecondQuestionAnswear { get; set; }
        [Required]
        public string ThirdQuestionRadioName { get; set; }
        [Required]
        public string ThirdQuestionId { get; set; }
        [Required]
        public string ThirdQuestionAnswear { get; set; }
        [Required]
        public string Answear { get; set; }
    }
}
