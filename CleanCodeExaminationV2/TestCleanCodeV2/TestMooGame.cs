using CleanCodeExaminationV1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCleanCodeExaminationV1
{
    [TestClass]
    public class TestMooGame
    {
        IGame Game;

        [TestInitialize]
        public void Init()
        {
            Game = new MooGame("1234");
        }
        [TestMethod]
        public void TestGetAnswer()
        {
            string code = Game.GetAnswer();
            Assert.AreEqual(code, "1234");
        }
        [TestMethod]
        public void TestCode()
        {
            Game.SetUp();
            string code = Game.GetAnswer();
            Assert.AreEqual(code.Length, 4);
        }

        [TestMethod]
        public void TestCode2()
        {
            Game.SetUp();
            string code = Game.GetAnswer();
            Assert.IsTrue(int.TryParse(code, out int result));
        }

        [TestMethod]
        public void TestCode3()
        {
            Assert.IsTrue(CompareDigits(Game.GetAnswer()));
        }

        public bool CompareDigits(string digits)
        {
            char[] chars = digits.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                for (int j = 0; j < chars.Length; j++)
                {
                    if(i != j && chars[i] == chars[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        [TestMethod]
        public void TestValidate()
        {
            Assert.IsTrue(Game.Validate("1234"));
        }
        [TestMethod]
        public void TestValidate2()
        {
            Assert.IsTrue(!Game.Validate("4321"));
        }

        [TestMethod]
        public void TestFeedback()
        {
            Assert.AreEqual(Game.Feedback("1211"), "BB,CC");
        }
        [TestMethod]
        public void TestFeedback2()
        {
            Assert.AreEqual(Game.Feedback("1672"), "B,C");
        }
        [TestMethod]
        public void TestFeedback3()
        {
            Assert.AreEqual(Game.Feedback("5678"), "");
        }
        [TestMethod]
        public void TestFeedback4()
        {
            Assert.AreEqual(Game.Feedback("1234"), "BBBB");
        }


    }
}
