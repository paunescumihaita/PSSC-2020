using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.NewQuestionWorkflow
{
    [Serializable]
    public class VotesException : Exception
    {
        public VotesException(int votes) : base($"Votes\"{votes}\"  is inccorect")
        { }

    }
}
