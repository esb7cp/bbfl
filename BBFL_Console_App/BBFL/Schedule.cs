using CsvHelper;
using System.Globalization;
using System.IO;
using System.Linq;

/*
 * This class is the class for schedules.
 * This is where we change the number of games played
 */
public class Schedule
{
	/***********************************************************************************
	*						CONSTRUCTORS											   *
	***********************************************************************************/
	public Schedule()
	{ 
	}
	//Blank constructor

	/***********************************************************************************
	*						VARIABLES												   *
	***********************************************************************************/
	public string Opponent { get; set; }
	//This variable is the name of who is being played.
	//Example: Kansas City
	public int Place { get; set; }
	//This variable lets us know if it is a home game or not for each team.
	//0 is an away game, 1 is a home game

	/***********************************************************************************
	*						FUNCTIONS												   *
	***********************************************************************************/
	public static Schedule[] ReadInScheduleFromCSV(string year, ProTeam team)
	{
		string path = "csv_files/schedules/year_" + year + "/" + team.Team.ToLower() + ".csv";
		var reader = new StreamReader(path);
		var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
		var records = csv.GetRecords<Schedule>();

		Schedule[] s = records.ToArray();
		return s;
	}
	//This function reads in the schedule from a csv file.
	//Inputs: The year that the schedule should be read in, and the team that the schedule is for
	//Outputs: The schedule, in a nice array
}
