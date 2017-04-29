using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MesoketesBattle.DataStructures;

namespace MesoketesBattle
{
    public class Battle
    {
        public List<Day> Days;

        public void Initialize(string input)
        {
            Days = GetBattleDays(input);
        } 

        private static List<Day> GetBattleDays(string n)
        {
            var allDays = n.Split(';').ToList();
            var m = n.ValidateDayInput();
            List<Day> days;
            if (m == allDays.Count)
            {
                days = allDays.Select(day => new Day()
                {
                    Name = day.Split('$')[0],
                    Attacks = GetAttacks(day.Split('$')[1])
                }).ToList();
            }
            else
            {
                throw new InvalidDataException("Day Input is NOT valid");
            }
            return days;
        }

        private static List<Attack> GetAttacks(string dayofAttack)
        {
            var allAttacks = dayofAttack.Split(':');
            var m = dayofAttack.ValidateTroopInput();
            List<Attack> attacks;
            if (m == allAttacks.Length)
            {
                attacks = allAttacks.Select(attack => attack.Split('-')).Select(hits => new Attack()
                {
                    Direction = hits[1].ToEnum<WallDirection>(),
                    Magnitude = int.Parse(hits[3]),
                    Weapon = hits[2].ToEnum<Weapon>()
                }).ToList();
            }
            else
            {
                throw new InvalidDataException("Troop input is NOT valid");
            }
            return attacks;
        }

        public int ProcessBattle(int initialHeight)
        {
            var successfulAttacks = 0;
            if (Days != null)
            {
                foreach (var day in Days)
                {
                    var todaySuccessfulAttacks = 0;
                    if (day.Attacks != null)
                    {
                        foreach (var attack in day.Attacks)
                        {
                            if (attack != null)
                            {
                                var wall = WallFactory.GetWall(attack.Direction, initialHeight);
                                var result = wall.AttackWall(attack);
                                if (result)
                                {
                                    todaySuccessfulAttacks++;
                                }
                            }
                        }
                        successfulAttacks += todaySuccessfulAttacks;
                        Console.WriteLine("Battle on - {0} : Successful Attacks - {1}", day.Name, todaySuccessfulAttacks);
                    }
                }
            }
            return successfulAttacks;
        }
    }
}
