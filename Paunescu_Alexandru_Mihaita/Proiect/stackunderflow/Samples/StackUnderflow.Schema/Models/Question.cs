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
        public int IdUser { get; set; }
        public string TitluQuestion { get; set; }
        public string TextQuestion { get; set; }
        public string TagQuestion { get; set; }
        public Question() { }
        public Question(int g,int d, string a, string b, string c)
        {
            IdQuestion = g;
            IdUser = d;
            TitluQuestion = a;
            TextQuestion = b;
            TagQuestion = c;
        }
    }
}
