using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Access.Primitives.IO;
using EarlyPay.Primitives.ValidationAttributes;

namespace StackUnderflow.Domain.Core.Contexts.Question
{
    public struct  CreateQuestionCmd
    {
       [Key]
        public int IdQuestion { get; set; }
        [Required]
        public string TitluQuestion { get; set; }
        [Required]
        public string TextQuestion { get; set; }
        [Required]
        public string TagQuestion { get; set; }
        public CreateQuestionCmd(int g,string a, string b, string c)
        {
            IdQuestion = g;
            TitluQuestion = a;
            TextQuestion = b;
            TagQuestion=c;
        }
    }
}
