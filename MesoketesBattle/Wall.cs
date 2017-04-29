using MesoketesBattle.DataStructures;

namespace MesoketesBattle
{
    public class Wall
    {
        public Wall(WallDirection wall, int height = 0)
        {
            WallDirection = wall;
            Height = height;
        }

        public WallDirection WallDirection { get; private set; }
        public int Height { get; private set; }

        public bool AttackWall(Attack attack)
        {
            var weaponMagitude = attack.Weapon;
            var attackPower = (int)weaponMagitude * attack.Magnitude;
            if (Height >= attackPower) return false;
            Height = attackPower;
            return true;
        }
    }
}
