using System;
using System.IO;

/*
 * This class is purely utility functions and other utility stuff.
 */

public class UtilityFunctions
{
	/***********************************************************************************
	 *						VARIABLES												   *
	***********************************************************************************/
	public static string filePathError = "../../../ExceptionLogs/ExceptionLog_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
	//This global variable is the file path to write error messages to

	/***********************************************************************************
	*						FUNCTIONS												   *
	***********************************************************************************/

	public static void Log(string logMessage, string logType, string function, TextWriter w)
	{

		w.Write("\r\nLog Entry : ");
		w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
		w.WriteLine(logType + " in " + function);
		w.WriteLine($"  Message:{logMessage}");
		w.WriteLine("-------------------------------");

	}
	//This function logs anything that we want
	//Inputs: the messaged that needs to be logged, the type of log that we have, the function that the log happened,
	//and the text writer that does the behind the scenes
	//Outputs: void, but the function writes (and possibly creates) the log file

	public static void Error(string error, string function, Exception ex)
	{
		using (StreamWriter w = File.AppendText(filePathError))
		{
			Log(ex.ToString(), "Exception in " + error, function, w);
		}
		Console.WriteLine(ex.ToString());
	}
	//This function logs error messages to the file
	//Inputs: the string format of the error, the function in which the error occured, and the exception that occured
	//Outputs: None
	//---------------------------------------------------------------------------------------------------------------------------
	/***********************************************************************************
	 *						CONSTRUCTORS											   *
	 ***********************************************************************************/
	public UtilityFunctions()
	{
	}
	//No constructor for this class, it is entirely different functions that have utility purpose

}
