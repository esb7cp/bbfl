using CsvHelper;
using System.Globalization;
using System.IO;
using System.Linq;

/*
 * This class is the object for the team's overall statistics
 * This is what is used in the simulator
 */
public class Statistics
{
	/***********************************************************************************
	*						CONSTRUCTORS											   *
	***********************************************************************************/	
	public Statistics()
	{
	}
	//Blank constructor

	/***********************************************************************************
	*						VARIABLES												   *
	***********************************************************************************/
	public float Overall { get; set; }
	//The overall score of the team
	//How is it used:
	public float Offense { get; set; }
	//How good the team's offense is
	//How it is used: 
	public float Defense { get; set; }
	//How good the team's defense is
	//How it is used: 
	public float Pass { get; set; }
	//How well the team passes the ball
	//How it is used: 
	public float Run { get; set; }
	//How well the team runs the ball
	//How it is used: 
	public float OffenseStrength { get; set; }
	//How strong they are on offense
	//How it is used: 
	public float OffenseSpeed { get; set; }
	//How fast they are on offense
	//How it is used: 
	public float Coverage { get; set; }
	//How well they defend against the pass
	//How it is used: 
	public float Rush { get; set; }
	//How well they defend against the run
	//How it is used: 
	public float DefenseStrength { get; set; }
	//How strong they are on defense
	//How it is used: 
	public float DefenseSpeed { get; set; }
	//How fast they are on defense
	//How it is used: 
	public float Total { get; set; }
	//The sum of the previous variables
	//How it is used: 
	public string Weather { get; set; }
	//The weather of the team's home. It can be Freezing, Cold, Cool, 
	//Moderate, Warm, Hot, Scorching, or Dome. 
	//How it is used: 
	public float Home { get; set; }
	//The home field advantage of the team
	//How it is used: 

	/***********************************************************************************
	*						FUNCTIONS												   *
	***********************************************************************************/
	public static Statistics ReadStatsFromCSV(string year, ProTeam team)
    {
		string path = "csv_files/stats/year_" + year + "/" + team.Team.ToLower() + ".csv";
		var reader = new StreamReader(path);
		var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
		var records = csv.GetRecords<Statistics>();
        Statistics s = records.ToArray()[0];
        return s;
	}
	//This function reads in the stats from a CSV file specific to a team
	//Inputs: the year the stats need to be read in from, the team the stats need to be read in from
	//Outputs: The statistics object in a nice format
}
