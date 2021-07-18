using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerProblem;
namespace TestProject2
{
    [TestClass]
    public class UnitTest1
    {
       
        [TestMethod]
        public void TestHappyMood()
        {
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am Happy");
            string expected = "happy";
            string actual = moodAnalyser.AnalyseMood();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSadMood()
        {
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am Sad");
            string expected = "sad";
            string actual = moodAnalyser.AnalyseMood();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestNullMood()
        {
            MoodAnalyser moodAnalyser = new MoodAnalyser(null);
            string expected = "happy";
            string actual = moodAnalyser.AnalyseMood();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCustomNullExceptions()
        {
            string expected = "Mood can't be null";
            try
            {
                MoodAnalyser moodAnalyser = new MoodAnalyser(null);
                moodAnalyser.AnalyseMood();
            }
            catch(CustomException ex)
            {
                Assert.AreEqual(expected, ex.Message); 
            }
        }

        [TestMethod]
        public void TestCustomEmptyException()
        {
            string expected = "Message is empty,Enter any message";
            try
            {
                MoodAnalyser moodAnalyser = new MoodAnalyser(string.Empty);
                moodAnalyser.AnalyseMood();
            }
            catch(CustomException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
    }
}
