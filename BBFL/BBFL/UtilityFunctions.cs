using System;
using System.IO;

/// <summary>
/// Summary description for Class1
/// </summary>
public class UtilityFunctions
{
	public static string filePathError = "../../../ExceptionLogs/ExceptionLog_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";

	public static void Log(string logMessage, string logType, string function, TextWriter w)
	{

		w.Write("\r\nLog Entry : ");
		w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
		w.WriteLine(logType + " in " + function);
		w.WriteLine($"  Message:{logMessage}");
		w.WriteLine("-------------------------------");

	}

	public static void Error(string error, string function, Exception ex)
	{
		using (StreamWriter w = File.AppendText(filePathError))
		{
			Log(ex.ToString(), "Exception in " + error, function, w);
		}
		Console.WriteLine(ex.ToString());
	}

	public UtilityFunctions()
	{
		//
		// TODO: Add constructor logic here
		//
	}


}
