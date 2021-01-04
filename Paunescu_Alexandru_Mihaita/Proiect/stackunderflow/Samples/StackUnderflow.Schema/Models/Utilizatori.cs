using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StackUnderflow.DatabaseModel.Models
{
    [Table("Utilizatori")]
    public partial class Utilizatori
    {
        public int IdUser { get; set; }
        public string Email { get; set; }
    }
}
