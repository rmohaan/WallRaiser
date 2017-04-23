using System;

namespace WallRaiser
{
    public class Wall
    {
        public int Height;

        public bool AttackWall(Wall w, string weapon, int attackStrength)
        {
            var weaponMagitude = 0;
            try
            {
                weaponMagitude = (int) Enum.Parse(typeof(WeaponMagnitude), weapon);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unidentified Weapon, Success rate is not reliable");
            }
               
            var attackPower = weaponMagitude * attackStrength;
            if (w.Height >= attackPower) return false;
            w.Height = attackPower;
            return true;
        }
    }

    public class SouthWall : Wall
    {
        private static volatile SouthWall _instance;
        private static readonly object Lockobj = new object();
        private SouthWall(int defaultWallHeight)
        {
            Height = defaultWallHeight;
        }

        public static SouthWall GetSouthWall(int defaultWallHeight = 0)
        {
            if (_instance == null)
            {
                lock (Lockobj)
                {
                    if (_instance == null)
                    {
                        _instance = new SouthWall(defaultWallHeight);
                    }

                }
            }
            return _instance;
        }
    }

    public class NorthWall : Wall
    {
        private static volatile NorthWall _instance;
        private static readonly object Lockobj = new object();
        private NorthWall(int defaultWallHeight)
        {
            Height = defaultWallHeight;
        }

        public static NorthWall GetNorthWall(int defaultWallHeight = 0)
        {
            if (_instance == null)
            {
                lock (Lockobj)
                {
                    if (_instance == null)
                    {
                        _instance = new NorthWall(defaultWallHeight);
                    }

                }
            }
            return _instance;
        }
    }

    public class WestWall: Wall
    {
        private static volatile WestWall _instance;
        private static readonly object Lockobj = new object();
        private WestWall(int defaultWallHeight)
        {
            Height = defaultWallHeight;
        }

        public static WestWall GetWestWall(int defaultWallHeight = 0)
        {
            if (_instance == null)
            {
                lock (Lockobj)
                {
                    if (_instance == null)
                    {
                        _instance = new WestWall(defaultWallHeight);
                    }
                    
                }
            }
            return _instance;
        }
    }

    public class EastWall : Wall
    {
        private static volatile EastWall _instance;
        private static readonly object Lockobj = new object();
        private EastWall(int defaultWallHeight)
        {
            Height = defaultWallHeight;
        }

        public static EastWall GetEastWall(int defaultWallHeight = 0)
        {
            if (_instance == null)
            {
                lock (Lockobj)
                {
                    if (_instance == null)
                    {
                        _instance = new EastWall(defaultWallHeight);
                    }

                }
            }
            return _instance;
        }
    }

}
