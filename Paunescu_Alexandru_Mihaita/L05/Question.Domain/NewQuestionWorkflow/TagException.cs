using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.NewQuestionWorkflow
{
    public class TagException : Exception
    {
        public TagException(List<string> tag) : base($"Tag number is:  \"{tag.Count}\"! Tag number should be between 1,3!")
        {
        }
    }

}
