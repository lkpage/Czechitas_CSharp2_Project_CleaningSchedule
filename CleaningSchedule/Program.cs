using System;

namespace CleaningSchedule
{
	internal class Program
	{
		public static void Main(string[] args)

		{
			bool runProgram = true;

			FlatmatesList listOfflatmates = new FlatmatesList();
			ShowWelcomeAndCreateOrShowListOfFlatmates(listOfflatmates);

			CleaningSchedule schedule = new CleaningSchedule(GetLengthOfDutyInDays(), listOfflatmates);
			ShowSchedule(schedule);

			CleaningTaskList listOfTasks = new CleaningTaskList();
			ShowListOfTasks(listOfTasks);

			ShowControlMenu();

			do
			{
				char option = Console.ReadKey().KeyChar;
				string showMenu = "Pro zobrazeni klavesoveho menu stiskni 'm'.";
				switch (option)
				{
					case 'p':
						Console.WriteLine();
						TextProperties.WriteTextInYellowWithEmptyLineAbove("PRIDANI NOVYCH SPOLUBYDLICICH...");
						listOfflatmates.AddAFlatemate();
						schedule.ShowLongSchedule();
						TextProperties.WriteTextInGreenWithEmptyLineAbove(showMenu);
						break;
					case 's':
						Console.WriteLine();
						TextProperties.WriteTextInYellowWithEmptyLineAbove("SMAZANI SPOLUBYDLICI/HO...");
						listOfflatmates.RemoveAFlatemate();
						schedule.ShowLongSchedule();
						TextProperties.WriteTextInGreenWithEmptyLineAbove(showMenu);
						break;
					case 'n':
						Console.WriteLine();
						TextProperties.WriteTextInYellowWithEmptyLineAbove("AKTUALNI SEZNAM A PRIDANI NOVE CINNOSTI...");
						listOfTasks.AddATask();
						TextProperties.WriteTextInGreenWithEmptyLineAbove(showMenu);
						break;
					case 'u':
						Console.WriteLine();
						TextProperties.WriteTextInYellowWithEmptyLineAbove("AKTUALNI SEZNAM A SMAZANI CINNOSTI...");
						listOfTasks.RemoveATask();
						TextProperties.WriteTextInGreenWithEmptyLineAbove(showMenu);
						break;
					case 'd':
						Console.WriteLine();
						schedule = new CleaningSchedule(GetLengthOfDutyInDays(), listOfflatmates);
						schedule.ShowLongSchedule();
						TextProperties.WriteTextInGreenWithEmptyLineAbove(showMenu);
						break;
					case 'm':
						Console.WriteLine();
						ShowControlMenu();
						break;
					case 'x':
						runProgram = false;
						break;
					default:
						break;
				}

			} while (runProgram);

			Console.ReadLine();
		}

		private static void ShowWelcomeAndCreateOrShowListOfFlatmates(FlatmatesList listOfflatmates)
		{
			TextProperties.WriteTextInGreenWithEmptyLineAbove("VITEJ V PROGRAMU 'CISTE SPOLUBYDLENI'.");
			Console.WriteLine($"Program umoznuje tvorit a spravovat seznam spolubydlicich a cinnosti{Environment.NewLine}a vypisuje rozpis sluzeb na budouci obdobi.");
			listOfflatmates.ShowListOfFlatmates();
		}

		private static int GetLengthOfDutyInDays()
		{
			TextProperties.WriteTextInGreenWithEmptyLineAbove("DELKA TRVANI SLUZBY:");
			Console.WriteLine(" Jak dlouho ma trvat sluzba jedne osoby?");
			string userInstruction = "Vypis pocet dnu (7 - 14 vcetne) a stiskni 'Enter': ";
			Console.Write(" " + userInstruction);

			int numberOfDays = Validations.VerifyNumberWithinRange(7, 14, userInstruction);

			return numberOfDays;
		}

		private static void ShowSchedule(CleaningSchedule sched)
		{
			sched.ShowDateTodayAndFlatmateResponsibleForCurrentPeriod();
			sched.ShowLongSchedule();
		}

		private static void ShowListOfTasks(CleaningTaskList listOfTasks)
		{
			listOfTasks.WriteListOfTasks();
		}

		private static void ShowControlMenu()
		{
			TextProperties.WriteTextInGreenWithEmptyLineAbove("KLAVESOVE MENU:");
			Console.WriteLine(" Pridani noveho spolubydliciho".PadRight(32) + "'p'");
			Console.WriteLine(" Smazani spolubydliciho".PadRight(32) + "'s'");
			Console.WriteLine(" Pridani nove cinnosti".PadRight(32) + "'n'");
			Console.WriteLine(" Smazani cinnosti".PadRight(32) + "'u'");
			Console.WriteLine(" Zmena delky sluzby".PadRight(32) + "'d'");
			Console.WriteLine(" Zavreni programu".PadRight(32) + "'x'");
			//Console.Clear();
		}
	}
}
