using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Question.Domain.NewQuestionWorkflow.NewQuestionResult;

namespace Question.Domain.NewQuestionWorkflow
{
    public class TotalVotes
    {

        public QuestionPosted TotVot(QuestionPosted question, VotesCondition vote)
        { 
        var tot = question.Votes;
        tot.Append(vote);
        return new QuestionPosted(question.Id, question.Title, question.Body, question.Tags, tot.Sum(v => Convert.ToInt32(v)), tot);
        }
}
}
