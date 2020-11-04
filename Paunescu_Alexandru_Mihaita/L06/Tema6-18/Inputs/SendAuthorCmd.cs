﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Tema6_18.Inputs
{
    public class SendAuthorCmd
    {
        [Required]
        public int RId { get; }
        [Required]
        public int QId { get; }
        [Required]
        public string ans { get; }
        public SendAuthorCmd(int RId, int QId, string ans)
        {
            this.RId = RId;
            this.QId = QId;
            this.ans = ans;

        }

    }
}
