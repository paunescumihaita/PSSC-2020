using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GrainInterfaces;
using Orleans;
using Orleans.Streams;
using StackUnderflow.DatabaseModel.Models;
using StackUnderflow.EF.Models;

namespace GrainImplementation
{
    public static class Globals
    {
        public static int ID;
    }
    public class QuestionGrain: Grain, IQuestionGrain, IAsyncObserver<string>
    {
        private StackUnderflowContext _dbContext;
        private int id;
        private IEnumerable<Replay> replays;
        private Question question;

        public QuestionGrain(StackUnderflowContext dbContext)
        {
            _dbContext = dbContext;
       
        }
        
        public Task<string> GetQuestionWithReplays(int IdQuestion)
        {
          
            IEnumerable<Question> a;
            a = _dbContext.Question.Where(c => c.IdQuestion == IdQuestion);
            foreach (Question q in a)
            {
                question = q;
            }

            replays = _dbContext.Replay.Where(c => c.IdQuestion == IdQuestion);

            id = IdQuestion;

            Console.WriteLine("Mihaita este aici");
            return Task.FromResult("ff");
        }
        public override async Task OnActivateAsync()
        {
          
              //Get one of the providers which we defined in config
              var streamProvider = GetStreamProvider("SMSProvider");
            //Get the reference to a stream
            var stream = streamProvider.GetStream<string>(ToGuid(  Globals.ID), "CHAT");
            //Set our OnNext method to the lambda which simply prints the data, this doesn't make new subscriptions because we are using implicit subscriptions via [ImplicitStreamSubscription].
            await stream.SubscribeAsync(this);

            await base.OnActivateAsync();
        }
        
        // public override async Task on
       
        public Task OnCompletedAsync()
        {
            throw new NotImplementedException();
        }

        public Task OnErrorAsync(Exception ex)
        {
            throw new NotImplementedException();
        }

        public   Task OnNextAsync(string item, StreamSequenceToken token = null)
        {
            int id = Int32.Parse(item);

            replays = _dbContext.Replay.Where(e => e.IdQuestion == id); ;
            
            

            Console.WriteLine("Question:" + question.IdQuestion+" "+question.TextQuestion);
            foreach(Replay a in replays)
            {
                Console.WriteLine("replay:" + " "+a.IdReplay+" "+a.IdQuestion+" "+a.TextReplay);
            }
    
            return Task.CompletedTask;
        }
        public static Guid ToGuid(int value)
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            return new Guid(bytes);
        }
    }
  
}
