using System;

namespace BBFL
{
    class Program
    {
        static void Main(string[] args)
        {
            //Gets teams loaded into memory
            var teams = ProTeam.ReadInTeamsFromCSV(UtilityFunctions.pathTo_pro_teams);

            //Gets two teams stats and load that into memory
            teams[0].Stats = Statistics.ReadStatsFromCSV("1", teams[0]);
            teams[1].Stats = Statistics.ReadStatsFromCSV("1", teams[1]);

            float temp = Simulator.DoSimulation(teams[0], teams[1]);
            Console.WriteLine(teams[0].Team + " has a " + temp + "% chance to beat " + teams[1].Team);

            Console.ReadLine();
        }
    }
}
