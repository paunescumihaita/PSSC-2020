using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.NewQuestionWorkflow
{
   public  class BodyException: Exception
    {

        public BodyException(string question) : base($"Question \"{ question}\" length is maximum 1000 characters.")
        { 
        
        }

    }
}
