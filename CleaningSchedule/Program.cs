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
						Console.WriteLine("SMAZANI SPOLUBYDLICI/HO:");
						listOfflatmates.RemoveAFlatemate();
						schedule.ShowLongSchedule();
						break;
					case 'p':
						Console.WriteLine();
						Console.WriteLine("PRIDANI NOVYCH SPOLUBYDLICICH:");
						listOfflatmates.AddAFlatemate();
						schedule.ShowLongSchedule();
						break;
					case 'n':
						Console.WriteLine();
						Console.WriteLine("PRIDANI CINNOSTI:");
						listOfTasks.AddATask();
						break;
					case 'u':
						Console.WriteLine();
						Console.WriteLine("SMAZANI CINNOSTI:");
						listOfTasks.RemoveATask();
						break;
					case 'd':
						Console.WriteLine();
						schedule = new CleaningSchedule(GetLengthOfDutyInDays(), listOfflatmates);
						ShowSchedule(schedule);
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
			Console.WriteLine("VITEJ V PROGRAMU 'CISTE SPOLUBYDLENI'.");
			Console.WriteLine("Program umoznuje tvorit a spravovat seznam spolubydlicich a cinnosti \na vypisuje rozpis sluzeb na budouci obdobi.");
			listOfflatmates.ShowListOfNames();
		}

		private static int GetLengthOfDutyInDays()
		{
			Console.WriteLine("\nZVOL DELKU TRVANI SLUZBY:");
			Console.WriteLine(" Jak dlouho ma trvat sluzba jedne osoby?");
			string userInstruction = "Vypis pocet dnu (7 - 14 vcetne) a stiskni 'Enter': ";
			Console.Write(" " + userInstruction);

			int numberOfDays = Validations.VerifyNumberWithinRange(7, 14, userInstruction);

			return numberOfDays;
		}

		private static void ShowSchedule(CleaningSchedule sched)
		{
			sched.ShowDateTodayAndFlatmateResponsibleForCurrentPeriod();
			Console.WriteLine("\nAKTUALNI ROZPIS:");
			sched.ShowLongSchedule();
		}

		private static void ShowListOfTasks(CleaningTaskList listOfTasks)
		{
			listOfTasks.WriteListOfTasks();
		}

		private static void ShowControlMenu()
		{
			Console.WriteLine("\nKLAVESOVE MENU:");
			Console.WriteLine(" Pridani noveho spolubydliciho - 'p'");
			Console.WriteLine(" Smazani spolubydliciho - 's'");
			Console.WriteLine(" Pridani nove cinnosti - 'n'");
			Console.WriteLine(" Smazani cinnosti - 'u'");
			Console.WriteLine(" Zmena delky sluzby - 'd'");
			Console.WriteLine(" Zavreni programu - 'x'");
			//Console.Clear();

		}
	}
}
