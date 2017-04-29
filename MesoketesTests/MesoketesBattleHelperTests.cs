using System.IO;
using MesoketesBattle;
using MesoketesBattle.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MesoketesTests
{
    [TestClass]
    public class MesoketesBattleHelperTests
    {
        [TestMethod]
        public void RemoveWhiteSpacesTest()
        {
            var n = "Day 1$ T1 - N - X - 5 : T2 - W - X - 3;Day 2$ T1 - S - X - 2";
            Assert.AreEqual(n.RemoveWhiteSpaces(), "Day1$T1-N-X-5:T2-W-X-3;Day2$T1-S-X-2");
        }
        
        [TestMethod]
        public void ValidateDayInputTest()
        {
            var n = "Day 1$ T1 - N - X - 5 : T2 - W - X - 3;Day 2$ T1 - S - X - 2";
            Assert.AreEqual(n.RemoveWhiteSpaces().ValidateDayInput(), 2);
        }

        [TestMethod]
        public void ValidateTroopInputTest()
        {
            var n = "Day 1$ T1 - N - X - 5 : T2 - W - X - 3;Day 2$ T1 - S - X - 2";
            Assert.AreEqual(n.RemoveWhiteSpaces().ValidateTroopInput(), 3);
        }

        [TestMethod]
        public void ToEnumSuccessTest()
        {
            var weapon = "X";
            var weaponMagitude = weapon.ToEnum<Weapon>();
            Assert.AreEqual(weaponMagitude, Weapon.X);

            weapon = "x";
            weaponMagitude = weapon.ToEnum<Weapon>();
            Assert.AreEqual(weaponMagitude, Weapon.X);

            var wall = "S";
            var wallDirection = wall.ToEnum<WallDirection>();
            Assert.AreEqual(wallDirection, WallDirection.S);
        }

        [TestMethod]
        public void ToEnumCaseInsensitiveTest()
        {
            var weapon = "x";
            var weaponMagitude = weapon.ToEnum<Weapon>();
            Assert.AreEqual(weaponMagitude, Weapon.X);

            var wall = "s";
            var wallDirection = wall.ToEnum<WallDirection>();
            Assert.AreEqual(wallDirection, WallDirection.S);
        }

        [TestMethod]
        public void ToEnumFailureTest()
        {
            var weapon = "P";
            var weaponMagitude = weapon.ToEnum<Weapon>();
            Assert.AreEqual(weaponMagitude, Weapon.Unknown);

            var wall = "C";
            var wallDirection = wall.ToEnum<WallDirection>();
            Assert.AreEqual(wallDirection, WallDirection.Unknown);
        }
    }
}
