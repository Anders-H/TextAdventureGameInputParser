using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextAdventureGameInputParser;

namespace Tests
{
    [TestClass]
    public class ParserTexts
    {
        [TestMethod]
        public void CanCleanInput()
        {
            var sentence = new Parser()
                .Parse("   give the   Horse, to The  HUMAN!!!  ");
            Assert.AreEqual("GIVE THE HORSE TO THE HUMAN", sentence.CleanInput);
        }

        [TestMethod]
        public void MumboJumboGeneratesFailedParse()
        {
            var sentence = new Parser()
                .Parse("sdfsdf");
            Assert.IsFalse(sentence.ParseSuccess);
        }
    }
}