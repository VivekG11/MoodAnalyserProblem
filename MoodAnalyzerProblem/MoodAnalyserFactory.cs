using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Text;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyserFactory
    {
        public object CreateMoodAnalyser(string ClassName, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(ClassName, pattern);

            if(result.Success)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type classType = assembly.GetType(ClassName);
                    return Activator.CreateInstance(classType);
                }
                catch(Exception ex)
                {
                    throw new CustomException(CustomException.ExceptionType.CLASS_NOT_FOUND, "Class Not Found");
                }
            }
            else
            {
                throw new CustomException(CustomException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "Constructor Not Found");
            }
        }
        
    }
}
