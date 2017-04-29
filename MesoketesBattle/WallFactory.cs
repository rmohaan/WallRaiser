using System;
using System.Collections.Generic;
using MesoketesBattle.DataStructures;

namespace MesoketesBattle
{
    public static class WallFactory
    {
        private static readonly Dictionary<WallDirection, Wall> Walls = new Dictionary<WallDirection, Wall>();
        public static Wall GetWall(WallDirection direction, int initialHeight)
        {
            if (!Walls.ContainsKey(direction))
            {
                Walls.Add(direction, new Wall(direction, initialHeight));
            }
            return Walls[direction];
        }
    }
}
