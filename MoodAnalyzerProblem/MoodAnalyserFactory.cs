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

        public string ParameterizedMoodAnalyser(string className, string constructorName, string message)
        {
            try
            {
                Type type = typeof(MoodAnalyser);
                if (type.Name.Equals(constructorName) || type.FullName.Equals(className))
                {
                    if (type.Name.Equals(constructorName))
                    {
                        ConstructorInfo info = type.GetConstructor(new[] { typeof(string) });
                        var obj = info.Invoke(new object[] { message });
                        return Convert.ToString(obj);
                    }

                    else
                    {
                        throw new CustomException(CustomException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "Constructor Not Found");

                    }
                }
            }
            catch(Exception)
            {
                throw new CustomException(CustomException.ExceptionType.CLASS_NOT_FOUND, "Class Not Found");
            }
            return default;
        }
    }
}
