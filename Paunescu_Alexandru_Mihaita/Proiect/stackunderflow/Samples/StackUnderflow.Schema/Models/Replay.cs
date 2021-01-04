using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace StackUnderflow.DatabaseModel.Models
{
    [Table("Replay")]
    public partial class Replay
    {
        //    [Key]
   
        public int IdReplay { get; set; }
      
        public int IdQuestion { get; set; }
       
        public string TextReplay { get; set; }
        public Replay(int IdReplay, int IdQuestion, string TextReplay)
        {
            this.IdReplay = IdReplay;
            this.IdQuestion = IdQuestion;
            this.TextReplay = TextReplay;

        }
        public string asd()
        {
            return "[" + IdReplay + "  " + IdQuestion + "   " + TextReplay + "]";
        }
    
    }
}
