using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using Microsoft.AspNetCore.Mvc;
using StackUnderflow.Domain.Core;
using StackUnderflow.Domain.Core.Contexts;
using StackUnderflow.Domain.Schema.Backoffice.CreateTenantOp;
using StackUnderflow.EF.Models;
using Access.Primitives.EFCore;
using StackUnderflow.Domain.Schema.Backoffice.InviteTenantAdminOp;
using StackUnderflow.Domain.Schema.Backoffice;
using LanguageExt;
using StackUnderflow.EF;
using Microsoft.EntityFrameworkCore;
using Orleans;
using StackUnderflow.DatabaseModel.Models;
using StackUnderflow.Domain.Core.Contexts.Question;
using GrainInterfaces;
using Orleans.Configuration;
using Orleans.Hosting;
//using GrainImplementation.Globals;

namespace StackUnderflow.API.AspNetCore.Controllers
{
    [ApiController]
    [Route("Question")]
    
    public class QController : ControllerBase
    {
        private readonly IInterpreterAsync _interpreter;
        private readonly StackUnderflowContext _dbContext;
        private static IClusterClient _client { get; set; }
     
        public QController(IInterpreterAsync interpreter, StackUnderflowContext dbContext)
        {
            _interpreter = interpreter;
            _dbContext = dbContext;
          
            _client = new ClientBuilder()
                 .UseLocalhostClustering()
                 .Configure<ClusterOptions>(options =>
                 {
                     options.ClusterId = "dev";
                     options.ServiceId = "OrleansBasics";
                 })
                 .AddSimpleMessageStreamProvider("SMSProvider", options => { options.FireAndForgetDelivery = true; })
                 .Build();

        }

        [HttpGet("GetQuestionbyId/{IdQuestion}")]
        public async Task<IEnumerable<Question>>GetQuestion1(int IdQuestion)
        {
           
            var a = _dbContext.Question.Where(c => c.IdQuestion == IdQuestion);
            if (a.Length() == 0)
                return null;
            else
            {
                if (_client.IsInitialized == false)
                    await _client.Connect();
                GrainImplementation.Globals.ID = IdQuestion;
                var friend = _client.GetGrain<IQuestionGrain>(IdQuestion);
                var response = await friend.GetQuestionWithReplays(IdQuestion);
               // await _client.AbortAsync();
                await _client.Close();
                return a;
            }
        }


        [HttpPost("CreateReplay")]
        public async Task<string> CreateReplay([FromBody] Replay e)
        {
            //   Replay e = new Replay(1, 1,"dd");
          
            _dbContext.Replay.Add(e);
            await _dbContext.SaveChangesAsync();
       if(_client.IsInitialized==false )
            await _client.Connect();
            var friend = _client.GetGrain<IQuestionGrain>(e.IdQuestion);
            var guid = Guid.Empty;
            var streamProvider = _client.GetStreamProvider("SMSProvider");
            var stream =  streamProvider.GetStream<string>(ToGuid(e.IdQuestion), "CHAT");
            string mess = e.IdQuestion.ToString();
            await stream.OnNextAsync(mess);
            await _client.Close();
            
            return "Adaugat";
        }



        [HttpPost("CreateQuestion")]
        public async Task<string> CreateQuestion1([FromBody] CreateQuestionCmd question)
        {
           
            QuestionContext ctx = new QuestionContext(
                  new EFList<Question>(_dbContext.Question));
            var dep = new QuestionDepend();
            var exp = from createQuestionResult in QuestionDomain.CreateQuestion(question)
                      select  new { createQuestionResult };


             var r = await _interpreter.Interpret(exp, ctx, dep);
            Console.WriteLine("fddddddddddddd");
           
            _dbContext.SaveChanges();
            if (_client.IsInitialized == false)
                await _client.Connect();
            var friend = _client.GetGrain<IEmailSender>(0);
            var a = _dbContext.Utilizatori.Where(c => c.IdUser == question.IdUser);
                foreach( Utilizatori u in a)
            {
                var response = await friend.SendEmailAsync(u.Email);
            }
           
           
            return "adaugat";
        }



        public static Guid ToGuid(int value)
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            return new Guid(bytes);
        }
     
      

     
     
    
    
}
}