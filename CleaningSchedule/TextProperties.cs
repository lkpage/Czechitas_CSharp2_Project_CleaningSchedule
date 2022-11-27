using System;

namespace CleaningSchedule
{
	static class TextProperties
	{
		public static void WriteTextInGreenWithEmptyLineAbove(string text)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($"{Environment.NewLine}{text}");
			Console.ForegroundColor = ConsoleColor.White;
		}

		public static void WriteTextInYellowWithEmptyLineAbove(string text)
		{
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine($"{Environment.NewLine}{text}");
			Console.ForegroundColor = ConsoleColor.White;
		}
		 
		public static void WriteTextInYellow(string text)
		{
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine($"{text}");
			Console.ForegroundColor = ConsoleColor.White;
		}

		public static void WriteTextInRed(string text)
		{
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine($"{text}");
			Console.ForegroundColor = ConsoleColor.White;
		}
	}
}
