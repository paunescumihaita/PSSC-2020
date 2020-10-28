using CSharp.Choices;
using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question.Domain.NewQuestionWorkflow
{
    [AsChoice]
    public static partial class QuestionVerify
    {
        public interface IQuestionVerify { }
        public class UnverifiedQuestion : IQuestionVerify
        {
            public string Question { get; private set; }
            public List<string> Tags { get; private set; }
            private UnverifiedQuestion(string question, List<string> tags)
            {
                Question = question;
                Tags = tags;
            }
            public static Result<UnverifiedQuestion> Create(string question, List<string> tags)
            {
                if(ValidQuestion(question))
                {
                    if(ValidTags(tags))
                    {
                        return new UnverifiedQuestion(question, tags);
                    }
                    else
                    {
                        return new Result<UnverifiedQuestion>(new TagException(tags));
                    }
                }
                else
                    return new Result<UnverifiedQuestion>(new BodyException(question));

            }
            private static bool ValidQuestion(string q)
            {
                if (q.Length > 1000)
                    return false;
                else return true;
            }
            private static bool ValidTags(List <string> t)
            {
                if (t.Count>=1 && t.Count<=3)
                    return true;
                else return false;
            }

            public class VerifiedQuestion: IQuestionVerify
            {
                public string Question { get; private set; }
                public List<string> Tags { get; private set; }
                internal VerifiedQuestion(string question, List<string> tags)
                {
                    Question = question;
                    Tags = tags;
                }
            }
        }
                


    }
}
