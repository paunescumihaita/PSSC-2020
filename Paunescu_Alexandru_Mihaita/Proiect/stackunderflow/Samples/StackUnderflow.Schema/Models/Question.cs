using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StackUnderflow.DatabaseModel.Models
{
    [Table("Question")]
    public partial class Question
    {
    //    [Key]
        public int IdQuestion { get; set; }
        public string TitluQuestion { get; set; }
        public string TextQuestion { get; set; }
        public string TagQuestion { get; set; }
        public Question() { }
        public Question(int g, string a, string b, string c)
        {
            IdQuestion = g;
            TitluQuestion = a;
            TextQuestion = b;
            TagQuestion = c;
        }
    }
}
