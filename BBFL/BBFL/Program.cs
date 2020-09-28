using System;

namespace BBFL
{
    class Program
    {
        static void Main(string[] args)
        {
            var teams = ProTeam.ReadInTeamsFromCSV(UtilityFunctions.pathTo_pro_teams);
            teams[0].Games = Schedule.ReadInScheduleFromCSV("1", teams[0]);
            int counter = 1;
            foreach(var s in teams[0].Games)
            {
                Console.WriteLine("Week: " + counter + " " + s.Opponent + " " + s.Place);
                counter++;
            }

            Console.ReadLine();
        }
    }
}
