using System;

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
}
