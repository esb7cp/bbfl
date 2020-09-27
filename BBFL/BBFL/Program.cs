using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Microsoft.VisualBasic;
using System.Linq;

namespace BBFL
{
    class Program
    {
        static string path = "csv_files/pro_teams.csv";
        static void Main(string[] args)
        {
            var reader = new StreamReader(path);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<ProTeam>();
            records = records.ToArray();
            ProTeam[] teams = new ProTeam[records.Count<ProTeam>()];
            int i = 0;
            foreach(var x in records)
            {
                ProTeam y = new ProTeam()
                {
                    Team = x.Team,
                    Mascot = x.Mascot,
                    Id = x.Id,
                    Abbreviation = x.Abbreviation
                };
                teams[i] = y;
                i++;
            }
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
