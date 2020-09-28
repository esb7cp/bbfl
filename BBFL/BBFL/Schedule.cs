using CsvHelper;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Schedule
{
	public const int NumOfGames = 14; 
	public Schedule()
	{ 
	}

	public string Opponent { get; set; }
	public int Place { get; set; }
	//This variable lets us know if it is a home game or not for each team.
	//0 is an away game, 1 is a home game


	/*public static Schedule[] ReadInScheduleFromCSV(string path, ProTeam[] teams)
	{
		var reader = new StreamReader(path);
		var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
		csv.Read();
		foreach (var x in teams)
        {
			Schedule[] schedule = new Schedule[NumOfGames];
			for (int i = 0; i < NumOfGames; i++)
            {
				schedule[i].Place = csv.GetField<int>(1);
				schedule[i].Opponent = csv.GetField<string>(3);

			}

		}

		
	}*/
	/*
	 * Idea on how to read in schedule data: 
	 * every home/away be in their own csv file,
	 * every opponent be in their own csv file,
	 * make both of those csv files have the id of the team
	 */
}
