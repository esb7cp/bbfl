using System;

//This class simulates games between two teams
public class Simulator
{
	/***********************************************************************************
	*							CONSTRUCTORS										   *
	************************************************************************************/
	public Simulator()
	{
	}
	//Blank constructor because fuck you 

	/***********************************************************************************
	*							FUNCTIONS											   *
	************************************************************************************/
	public void DoSimulation(ProTeam homeTeam, ProTeam awayTeam)
    {
		float offAdvHomeTeam = OffensiveAdvantage(homeTeam, awayTeam);
		float offAdvAwayTeam = OffensiveAdvantage(awayTeam, homeTeam);
    }

	private float OffensiveAdvantage(ProTeam team1, ProTeam team2)
    {
		float offDef = team1.Stats.Offense - team2.Stats.Defense;
		float pass = team1.Stats.Pass - team2.Stats.Coverage;
		float run = team1.Stats.Run - team2.Stats.Rush;
		float strength = team1.Stats.OffenseStrength - team2.Stats.DefenseStrength;
		float speed = team1.Stats.OffenseSpeed - team2.Stats.DefenseSpeed;
		if (pass < 0) pass = 0;
		if (run < 0) run = 0;
		return offDef + pass + run + strength + speed;
    }
	/* This function gets us the offensive advantage. 
	 *		This number is the offensive stats of one team minus the defensive stats of the other team.
	 *		Respective defensive values are subtracted from the offensive ones.
	 *		If pass or run are less than 0, we don't want that. So to throw them out we make them 0.
	 *	Inputs:
	 *		team1 - the offensive team
	 *		team2 - the team that team1 is playing
	 *	Outputs:
	 *		Returns the offensive advantage for team1
	 *		Outputs nothing to the console
	 */
}
