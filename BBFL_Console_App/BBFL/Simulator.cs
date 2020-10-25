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
	public static float DoSimulation(ProTeam homeTeam, ProTeam awayTeam)
    {
		float offAdvHomeTeam = OffensiveAdvantage(homeTeam, awayTeam);
		float offAdvAwayTeam = OffensiveAdvantage(awayTeam, homeTeam);
		float overallAdvHomeTeam = OverallAdvantage(homeTeam, awayTeam);
		float overallAdvAwayTeam = OverallAdvantage(awayTeam, homeTeam);
		float totalAdvHomeTeam = TotalAdvantage(offAdvHomeTeam, overallAdvHomeTeam, 0, homeTeam.Stats.Home, 0);
		float totalAdvAwayTeam = TotalAdvantage(offAdvAwayTeam, overallAdvAwayTeam, 0, 0, 0);

		float ta2H = GetT2Value(totalAdvHomeTeam, totalAdvAwayTeam);
		float ta2A = GetT2Value(totalAdvAwayTeam, totalAdvHomeTeam);
		float pH = GetPValue(ta2H, overallAdvHomeTeam);
		float pA = GetPValue(ta2A, overallAdvAwayTeam);
		float vH = GetVValue(pH, ta2H);
		float vA = GetVValue(pA, ta2A);

		float percentHomeTeam = -100;

		if(totalAdvHomeTeam > 0 && totalAdvAwayTeam > 0)
        {
			float temp = totalAdvHomeTeam + overallAdvHomeTeam;
			percentHomeTeam = (temp / (temp + totalAdvAwayTeam - overallAdvAwayTeam)) * 100;
        }
		else if (totalAdvHomeTeam < 0 && totalAdvAwayTeam < 0)
        {
			if (pH > pA)
            {
				percentHomeTeam = (pH / (pH + vA)) * 100;
			}
			else if (pH < pA)
            {
				percentHomeTeam = (vH / (vH + pA)) * 100;
			}
        }
		else if (pH > 0 && pA < 0)
        {
			percentHomeTeam = (pH / (pH + vA)) * 100;
		}
		else if (pA > 0 && pH < 0)
        {
			percentHomeTeam = (vH / (vH + pA)) * 100;
		}
		return percentHomeTeam;
	}

	

	private static float OffensiveAdvantage(ProTeam team1, ProTeam team2)
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

	private static float OverallAdvantage(ProTeam team1, ProTeam team2)
    {
		float advantage = team1.Stats.Overall - team2.Stats.Overall;
		return (advantage / 2);
    }
	/* This function gets us what Zach calls the overall advantage.
	 *		This value is team1's overall minus team2's overall, divided by 2.
	 * Inputs:
	 *		team1 - one team
	 *		team2 - the other team
	 * Outputs:
	 *		Returns the overall advantage for team1.
	 *		Outputs nothing to the console.
	 */

	private static float TotalAdvantage(float offAdv, float overallAdv, float weather, float home, float bonus)
    {
		return (offAdv + overallAdv + weather + home + bonus);
    }
	/* This fucntion gives us the total advantage.
	 *		Total advantage is the sum of offensive advantage, overall advantage, 
	 *		the weather factor, the home factor, and the bonus (the ranking bonus. idk ask zach).
	 * Inputs:
	 *		offAdv - offensive advantage, computed in the function of same name.
	 *		overallAdv - overall advantage, computed in the function of same name.
	 *		weather - the weather factor. Currently just 0 bc I don't know how to do it.
	 *		home - pretty sure add this only to the home team, if the home team is at home
	 *		bonus - ranking bonus. idk ask zach
	 * Outputs:
	 *		returns the Total Advantage
	 *		Outputs nothing to the console
	 */

	private static float GetT2Value(float totalAdv1, float totalAdv2)
    {
		return (totalAdv1 - totalAdv2);
    }
	/* This function gets us the total adv 2 value, which is used to get the p and v values below.
	 *		t adv 2 is the total advantage value of you subtracted by the t adv of your opponent
	 * Inputs:
	 *		totalAdv1 - your total advantage value
	 *		totalAdv2 - your opponent's total advantage value
	 * Outputs:
	 *		Returns out t adv 2 value
	 *		Outputs nothing to the console
	 */

	private static float GetPValue(float t2, float overallAdv)
    {
		return t2 + overallAdv;
    }
	/* This function gets us the p value, which is used to get the magic number.
	 *		It is your total advantage 2 added to your overall advantage.
	 * Inputs:
	 *		t2 - Total Advantage 2 value for you, gotten from the last step.
	 *		overallAdv - your overall advantage value
	 * Outputs:
	 *		Returns your P value
	 *		Outputs nothing to the console
	 */

	private static float GetVValue(float p, float t2)
    {
		return ((p - t2) * -1);
    }
	/* This function gets us your v value, which is used to get the magic number.
	 *		It is calculated by subtracting your p value with your total advantage 2 value, and multiplying that by -1.
	 * Inputs:
	 *		p - your p value
	 *		t2 - your total advantage 2 value
	 * Outputs:
	 *		Returns your v value
	 *		Outputs nothing to the console
	 */
}
