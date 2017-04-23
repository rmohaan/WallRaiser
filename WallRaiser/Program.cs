using System;

namespace WallRaiser
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = "Day 1$ T1 - S - X - 4: T1 - N - X - 2: T3 - W - X - 3; Day 2$ T2 - S - X - 5: T2 - N - X - 1: T3 - N - X - 3; Day 3$ T1 - W - X - 2: T1 - W - X - 4: T2 - N - X - 3: T2 - S - X - 4";
            n =
                "Day 1$ T1 - S - X - 4: T1 - N - X - 2: T3 - W - X - 3; Day 2$ T2 - S - X - 5: T2 - N - X - 1: T3 - N - X - 3; Day 3$ T1 - W - X - 2: T1 - W - X - 4: T2 - N - X - 3: T2 - S - X - 4";
            n = "Day 1$ T1 - E - X - 4; Day 2$ T1 - W - X - 3 : T2 - E - X - 3; Day 3$ T3 - N - X - 2: T2 - W - X - 4";
            n = "Day 1$ T1 - N - X - 5 : T2 - N - Y - 1;Day 2$ T1 - S - X - 2";
            var daysOfAttack = n.Split(';');
            var successfulAttacks = 0;
            foreach (var day in daysOfAttack)
            {
                var troops = day.Split('$')[1];
                var attacks = troops.Split(':');
                foreach (var attack in attacks)
                {
                    var hits = attack.Split('-');
                    var attackWall = hits[1].Trim();
                    var weapon = hits[2].Trim();
                    var attackStrength = int.Parse(hits[3]);
                    //Console.WriteLine(hits[1] + " " + hits[3]);
                    switch (attackWall)
                    {
                        case "S":
                            var southWall = SouthWall.GetSouthWall();
                            if (southWall.AttackWall(southWall, weapon, attackStrength))
                            {
                                successfulAttacks++;
                            }
                        break;
                        case "N":
                            var northWall = NorthWall.GetNorthWall();
                            if (northWall.AttackWall(northWall, weapon, attackStrength))
                            {
                                successfulAttacks++;
                            }
                        break;
                        case "W":
                            var westWall = WestWall.GetWestWall();
                            if (westWall.AttackWall(westWall, weapon, attackStrength))
                            {
                                successfulAttacks++;
                            }
                        break;
                        case "E":
                            var eastWall = EastWall.GetEastWall();
                            if (eastWall.AttackWall(eastWall, weapon, attackStrength))
                            {
                                successfulAttacks++;
                            }
                            break;
                    }
                }
            }

           Console.WriteLine("Successful Attacks {0}", successfulAttacks);

            Console.ReadLine();
        }
    }
}
