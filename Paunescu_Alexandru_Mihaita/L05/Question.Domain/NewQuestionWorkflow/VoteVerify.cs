using CSharp.Choices;
using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.NewQuestionWorkflow
{
    [AsChoice]
    

    public static partial class VoteVerify
    {
        public interface IVote { }
        public class UnverifiedVotes : IVote
        {
            public int Votes { get; private set; }
            private UnverifiedVotes(int votes)
            {
                Votes = votes;
            }

            public static Result <UnverifiedVotes> Create(int votes)
            {
                if (ValidNumberOfVotes(votes))
                {
                    return new UnverifiedVotes(votes);
                }
                else
                {
                    return new Result<UnverifiedVotes>(new VotesException(votes));
                }
            }
            private static bool ValidNumberOfVotes(int votes)
            {
                if (votes != 0)
                {
                    return true;
                }
                return false;
            }
        }
        public class VerifiedVotes : IVote
        {
            public int Votes { get; private set; }
            internal VerifiedVotes(int voturi)
            {
                Votes = voturi;
            }
        }
    }
}
