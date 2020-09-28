using System;

namespace BBFL
{
    class Program
    {
        static void Main(string[] args)
        {
            var teams = ProTeam.ReadInTeamsFromCSV(UtilityFunctions.pathTo_pro_teams);
            try
            {
                for (int j = 0; j < teams.Length; j++)
                {
                    Console.WriteLine(teams[j].Team+ " " + teams[j].Mascot);
                }
            }
            catch(Exception ex)
            {
                UtilityFunctions.Error(ex.Message, "Main", ex);
            }

            Console.ReadLine();
        }
    }
}
