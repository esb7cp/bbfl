using System;

namespace BBFL
{
    class Program
    {
        static void Main(string[] args)
        {
            //Gets teams loaded into memory
            var teams = ProTeam.ReadInTeamsFromCSV(UtilityFunctions.pathTo_pro_teams, "1");

            //Gets teams stats and load that into memory
            for (int i = 0; i < teams.Length; i++)
            {
                teams[i].Stats = Statistics.ReadStatsFromCSV("1", teams[i]);
            }
            

            float temp = Simulator.DoSimulation(teams[0], teams[1]);
            Console.WriteLine(teams[0].Team + " has a " + temp + "% chance to beat " + teams[1].Team);
            if (Simulator.HomeTeamWin(temp) == true) Console.WriteLine(teams[0].Team + " wins.");
            else Console.WriteLine(teams[1].Team + " wins.");
            
            Console.ReadLine();
        }
    }
}
