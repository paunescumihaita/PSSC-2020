using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using LanguageExt;

using static Question.Domain.NewQuestionWorkflow.QuestionVerify.UnverifiedQuestion;

namespace Question.Domain.NewQuestionWorkflow
{
    public class Votes
    {
        
        public Task Vote(VerifiedQuestion question)
        {
            return Task.CompletedTask;
        }
    }
}
