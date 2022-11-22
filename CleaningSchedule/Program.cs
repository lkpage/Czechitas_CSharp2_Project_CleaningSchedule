using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CleaningSchedule
{
	internal class Program
	{
		public static void Main(string[] args)

		{
			bool runProgram = true;

			FlatmatesList listOfflatmates = new FlatmatesList();


			//listOfflatmates.CallFileWithListOFFlatmates();

			ShowWelcomeAndCreateOrShowListOfFlatmates(listOfflatmates);

			CleaningSchedule schedule = new CleaningSchedule(GetLengthOfDutyInDays(), listOfflatmates);
			ShowSchedule(schedule);
			
			CleaningTaskList listOfTasks = new CleaningTaskList();


			ShowListOfTasks(listOfTasks);
			
			ShowControlMenu();

			do
			{
				char option = Console.ReadKey().KeyChar;
				switch (option)
				{
					case 'v':
						Console.WriteLine();
						listOfflatmates.ShowListOfNames();
						break;
					case 's':
						Console.WriteLine();
						TextColors.WriteTextInYellow("SMAZANI SPOLUBYDLICI/HO:");
						listOfflatmates.RemoveAFlatemate();
						schedule.ShowLongSchedule();
						break;
					case 'p':
						Console.WriteLine();
						TextColors.WriteTextInYellow("PRIDANI NOVYCH SPOLUBYDLICICH:");
						listOfflatmates.AddAFlatemate();
						schedule.ShowLongSchedule();
						break;
					case 'n':
						Console.WriteLine();
						TextColors.WriteTextInYellow("PRIDANI CINNOSTI:");
						listOfTasks.AddATask();
						break;
					case 'u':
						Console.WriteLine();
						TextColors.WriteTextInYellow("SMAZANI CINNOSTI:");
						listOfTasks.RemoveATask();
						break;
					case 'd':
						Console.WriteLine();
						TextColors.WriteTextInYellow("ZMENA DELKY SLUZBY:");
						schedule = new CleaningSchedule(GetLengthOfDutyInDays(), listOfflatmates);
						schedule.ShowLongSchedule();
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
			TextColors.WriteTextInGreen("VITEJ V PROGRAMU 'CISTE SPOLUBYDLENI'.");
			Console.WriteLine($"Program umoznuje tvorit a spravovat seznam spolubydlicich a cinnosti{Environment.NewLine}a vypisuje rozpis sluzeb na budouci obdobi.");
			listOfflatmates.ShowListOfNames();
		}

		private static int GetLengthOfDutyInDays()
		{
			TextColors.WriteTextInGreen("DELKA TRVANI SLUZBY:");
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
			TextColors.WriteTextInGreen("KLAVESOVE MENU:");
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
