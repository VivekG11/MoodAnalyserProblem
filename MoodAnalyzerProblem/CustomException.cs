using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzerProblem
{
    public class CustomException : Exception
    {
        ExceptionType type;
        public enum ExceptionType
        {
            NULL_EXCEPTION,EMPTY_EXCEPTION,CLASS_NOT_FOUND,CONSTRUCTOR_NOT_FOUND
        }
        public CustomException(ExceptionType type, String message):base(message)
        {
            this.type = type;
        }
    }
}
