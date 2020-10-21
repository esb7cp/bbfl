using System;

namespace BBFL
{
    class Program
    {
        static void Main(string[] args)
        {
            //Gets teams loaded into memory
            var teams = ProTeam.ReadInTeamsFromCSV(UtilityFunctions.pathTo_pro_teams);

            //Right now, the rest of this application gets one schedule for one team and prints it out, for testing purposes.
            teams[0].Stats = Statistics.ReadStatsFromCSV("1", teams[0]);
            {
                Console.WriteLine("Overall: " + teams[0].Stats.Overall);

            }

            Console.ReadLine();
        }
    }
}
