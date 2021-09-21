using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextAdventureGameInputParser;

namespace Tests
{
    [TestClass]
    public class AliasTests
    {
        [TestMethod]
        public void CanResolveAliases()
        {
            var aliases = new AliasList
            {
                {"GO NORTH", "N"},
                {"SHOW INVENTORY", "I", "INV"}
            };

            Assert.AreEqual("OPEN DOOR", aliases.Apply("OPEN DOOR"));
            Assert.AreEqual("GO NORTH", aliases.Apply("N"));
            Assert.AreEqual("GO NORTH", aliases.Apply("GO NORTH"));
            Assert.AreEqual("SHOW INVENTORY", aliases.Apply("I"));
            Assert.AreEqual("SHOW INVENTORY", aliases.Apply("INV"));
            Assert.AreEqual("SHOW INVENTORY", aliases.Apply("SHOW INVENTORY"));
            Assert.AreEqual("CLOSE DOOR", aliases.Apply("CLOSE DOOR"));
        }
    }
}