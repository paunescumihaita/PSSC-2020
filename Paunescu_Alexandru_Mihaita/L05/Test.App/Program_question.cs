using System;
using System.Collections.Generic;
using System.Text;
using Question.Domain.NewQuestionWorkflow;
using System.Net;
using static Question.Domain.NewQuestionWorkflow.NewQuestionResult;
using static Question.Domain.NewQuestionWorkflow.QuestionVerify;
using LanguageExt;

namespace Test.App
{
    class Program_question
    {
        static void Main(string[] args)
        {
             var result = UnverifiedQuestion.Create("How to load local geojson file and display it on leaflet map in asp.net mvc?", new List<string>() { "javascript", "arrays" });
            

            result.Match(
                  Succ: question =>
                  {
                     
                      Console.WriteLine("Question posted, you can vote!");
                      VoteQ(question);
                      return Unit.Default;
                  },
                    Fail: ex =>
                    {
                        Console.WriteLine($"Sorry, the question couldn't be posted, see why: ");
                        Console.WriteLine($"    -Reason: {ex.Message}");
                        return Unit.Default;
                    }

           
                );

            Console.ReadLine();
        }

        private static void VoteQ(UnverifiedQuestion question)
        {
            var verifRes = new PublishedQuestionSRV().PostQuestion(question);
            verifRes.Match(
                    VoteQ =>
                    {
                       new Votes().Vote(VoteQ);
                      

                        return Unit.Default;
                    },
                    ex =>
                    {
                        Console.WriteLine("You can't vote this question!");
                        return Unit.Default;
                    }
                );

        }

    }
}
