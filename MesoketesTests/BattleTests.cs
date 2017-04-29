using System.IO;
using MesoketesBattle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MesoketesTests
{
    [TestClass]
    public class BattleTests
    {
        [TestMethod]
        public void StartBattleTest()
        {
            var input = "Day 1$ T1 - N - X - 15 : T2 - W - X - 13;Day 2$ T1 - S - X - 12".RemoveWhiteSpaces();
            var battle = new Battle();
            battle.Initialize(input);
            var result = battle.ProcessBattle(0);
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void StartBattleWithIntialHeightAs5Test()
        {
            var input = "Day 1$ T1 - N - X - 5 : T2 - W - X - 3;Day 2$ T1 - S - X - 2".RemoveWhiteSpaces();
            var battle = new Battle();
            battle.Initialize(input);
            var result = battle.ProcessBattle(5);
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void BattleInitializeDaysTest()
        {
            var input = "Day 1$ T1 - N - X - 5 : T2 - W - X - 3;Day 2$ T1 - S - X - 2".RemoveWhiteSpaces();
            var battle = new Battle();
            battle.Initialize(input);
            var result = battle.Days;
            Assert.AreEqual(result.Count, 2);
        }

        [TestMethod]
        public void BattleInitializeTroopsTest()
        {
            var input = "Day 1$ T1 - N - X - 5 : T2 - W - X - 3;Day 2$ T1 - S - X - 2".RemoveWhiteSpaces();
            var battle = new Battle();
            battle.Initialize(input);
            var result = battle.Days;
            Assert.AreEqual(result[0].Attacks.Count, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException), "Invalid Day in the Input")]
        public void InitializeBattleDaysExceptionTest()
        {
            var input = "Day 1:$ T1 - N - X - 5".RemoveWhiteSpaces();
            var battle = new Battle();
            battle.Initialize(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException), "Invalid Troop in the Input")]
        public void InitializeBattleTroopsExceptionTest()
        {
            var input = "Day 1$ T:1 - N - X - 5".RemoveWhiteSpaces();
            var battle = new Battle();
            battle.Initialize(input);
        }
    }
}
