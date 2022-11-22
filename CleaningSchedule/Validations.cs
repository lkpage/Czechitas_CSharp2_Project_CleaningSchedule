using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CleaningSchedule
{
	static class Validations
	{
		public static int VerifyNumberWithinRange(int minimum, int maximum, string instruction)
		{
			int min = minimum;
			int max = maximum;
			string input = Console.ReadLine();
			int number;
			bool inputIsNumber = int.TryParse(input, out number);
			bool numberInRange = inputIsNumber && number >= min && number <= max;
			while (!numberInRange)
			{
				Console.WriteLine("Neplatne zadani.");
				Console.Write(instruction);
				input = Console.ReadLine();
				inputIsNumber = int.TryParse(input, out number);
				numberInRange = inputIsNumber && number >= min && number <= max;
			}
			return number;
		}

		public static bool IsLettersOnly(string stringInput)
		{
			string input = stringInput;
			bool stringIsOk = true;

			if (string.IsNullOrEmpty(input))
			{
				Console.WriteLine("Nazadal jsi zadny vstup.");
				stringIsOk = false;
			}
			else
			{
				for (int i = 0; i < input.Length; i++)
				{
					if (!Char.IsLetter(input[i]))
					{
						Console.WriteLine("Neplatne znaky, zadavej pouze pismena.");
						stringIsOk = false;
						break;
					}
				}
			}
			return stringIsOk;
		}

		public static bool IsNotEmptyString(string stringInput)
		{
			string input = stringInput;
			return string.IsNullOrEmpty(input);
		}
		public static int VerifyNumber()
		{
			string input = Console.ReadLine();
			int number;
			while (!int.TryParse(input, out number))
			{
				Console.WriteLine("Nezadal jsi cislo, zkus to znovu: ");
				input = Console.ReadLine();
			}
			return number;
		}

		public static bool IsNumber(int userInput)
		{
			string input = Console.ReadLine();
			int number;
			while (!int.TryParse(input, out number))
			{
				Console.WriteLine("Nezadal jsi cislo, zkus to znovu: ");
				input = Console.ReadLine();
			}
			return true;
		}
	}
}
