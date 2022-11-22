using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningSchedule
{
	static class TextColors
	{
		public static void WriteTextInGreen(string text)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($"{Environment.NewLine}{text}");
			Console.ForegroundColor = ConsoleColor.White;
		}

		public static void WriteTextInYellow(string text)
		{
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine($"{Environment.NewLine}{text}");
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
