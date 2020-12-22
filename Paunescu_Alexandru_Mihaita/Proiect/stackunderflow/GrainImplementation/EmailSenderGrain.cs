﻿using GrainInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrainImplementation
{
    public class EmailSenderGrain : Orleans.Grain, IEmailSender
    {
        public Task<string> SendEmailAsync(string message)
        {
            //todo send e-mail
            Console.WriteLine("Am fost apelat");

            return Task.FromResult(message);
        }
    }
}
