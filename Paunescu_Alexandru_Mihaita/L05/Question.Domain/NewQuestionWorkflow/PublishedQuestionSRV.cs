using System;
using System.Collections.Generic;
using System.Text;
using static Question.Domain.NewQuestionWorkflow.QuestionVerify;
using LanguageExt.Common;
using static Question.Domain.NewQuestionWorkflow.QuestionVerify.UnverifiedQuestion;

namespace Question.Domain.NewQuestionWorkflow
{
    public class PublishedQuestionSRV
    {
        public Result<VerifiedQuestion> PostQuestion(UnverifiedQuestion question)
        {
            //conditile min 1 max 3 taguri, body length <=1000caractere
            return new VerifiedQuestion(question.Question, question.Tags);
        }

            }
}
