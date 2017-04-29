using MesoketesBattle;
using MesoketesBattle.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MesoketesTests
{
    [TestClass]
    public class WallTests
    {
        [TestMethod]
        public void GetWallTest()
        {
            var dir = WallDirection.S;
            var wall = WallFactory.GetWall(dir, 0);
            Assert.AreEqual(wall.WallDirection, WallDirection.S);
        }

        [TestMethod]
        public void AttackWallFailedTest()
        {
            var dir = WallDirection.S;
            var wall = WallFactory.GetWall(dir, 0);
            var attack = new Attack
            {
                Direction = wall.WallDirection,
                Weapon = Weapon.X,
                Magnitude = 0
            };
            var result = wall.AttackWall(attack);
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void AttackWallSuccessTest()
        {
            var dir = WallDirection.E;
            var wall = WallFactory.GetWall(dir, 0);
            var attack = new Attack
            {
                Direction = wall.WallDirection,
                Weapon = Weapon.X,
                Magnitude = 1
            };
            var result = wall.AttackWall(attack);
            Assert.AreEqual(result, true);
        }
    }
}
