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
        public int IdUser { get; set; }
        [Required]
        public string TitluQuestion { get; set; }
        [Required]
        public string TextQuestion { get; set; }
        [Required]
        public string TagQuestion { get; set; }
        public CreateQuestionCmd(int g,int d,string a, string b, string c)
        {
            IdQuestion = g;
            IdUser = d;
            TitluQuestion = a;
            TextQuestion = b;
            TagQuestion=c;
        }
    }
}
