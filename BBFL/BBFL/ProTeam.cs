using CsvHelper;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

//This class is for professional teams
public class ProTeam
{
	/***********************************************************************************
	*						CONSTRUCTORS											   *
	***********************************************************************************/
	public ProTeam()
	{
	}
	//The constructor is blank, because that is just how I roll

	/***********************************************************************************
	 *						VARIABLES												   *
	***********************************************************************************/
	public string Team { get; set; }
	//The name of the team (ie, geographical name.).
	//Example: St. Louis
	public string Mascot { get; set; }
	//The mascot of the team.
	//Example: Cardinals
	public int Id { get; set; }
	//The id of the team. Unknown if we will need this as the teams are currently stored in an array.
	//The ID should just be the index of the team in the array, but I'll keep it here for possible future uses.
	public string Abbreviation { get; set; }
	//The abbreviation of the team. 
	//Example: STL
	public string Region { get; set; }
	//The region that the team places in
	//Example: Midwest
	public Schedule[] Schedule { get; set; }
	//This is the current schedule of the team
	

	/***********************************************************************************
	 *						FUNCTIONS												   *
	***********************************************************************************/
	public static ProTeam[] ReadInTeamsFromCSV(string path)
    {
		var reader = new StreamReader(path);
		var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
		var records = csv.GetRecords<ProTeam>();
		records = records.ToArray();
		ProTeam[] teams = new ProTeam[records.Count<ProTeam>()];
		int i = 0;
		foreach (var x in records)
		{
			teams[i] = x;
			i++;
		}
		return teams;
	}
	//This function reads in the list of teams from the CSV file that contains them.
	//Inputs: The path to the CSV file
	//Outputs: The array with all the teams in it
}
