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


	public static Schedule[] ReadInScheduleFromCSV(string year, ProTeam team)
	{
		string path = "csv_files/schedules/year_" + year + "/" + team.Team.ToLower() + ".csv";
		var reader = new StreamReader(path);
		var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
		var records = csv.GetRecords<Schedule>();

		Schedule[] s = records.ToArray();
		return s;
	}
}
