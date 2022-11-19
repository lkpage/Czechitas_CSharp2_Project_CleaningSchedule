using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningSchedule
{
	internal class Program
	{
		public static void Main(string[] args)

		{		
			FlatmatesList listOfflatmates = new FlatmatesList();

			if (listOfflatmates.listOfFlatmates.Count == 0)
			{
				Console.WriteLine("VITEJ V PROGRAMU 'CISTE SPOLUBYDLENI'.");
				listOfflatmates.WriteFirstFlatmates();
			}
			else
			{
				listOfflatmates.CallFileWithListOFFlatmates();
				ShowWelcomeAndListOfFlatmates(listOfflatmates);
			}

			CleaningTaskList listOfTasks = new CleaningTaskList();

			bool runProgram = true;

			CleaningSchedule schedule = new CleaningSchedule(GetLengthOfDutyInDays());

			ShowSchedule(schedule);
			ShowListOfTasks(listOfTasks);
			ShowControlMenu();

			do
			{
				char option = Console.ReadKey().KeyChar;
				switch (option)
				{
					case 'v':
						Console.WriteLine();
						listOfflatmates.WriteListOfNames();
						break;
					case 's':
						Console.WriteLine();
						listOfflatmates.RemoveAFlatemate();
						//schedule.ShowLongSchedule();
						break;
					case 'p':
						Console.WriteLine();
						listOfflatmates.AddAFlatemate();
						//schedule.ShowLongSchedule();
						break;
					case 'n':
						Console.WriteLine();
						listOfTasks.AddATask();
						break;
					case 'u':
						Console.WriteLine();
						listOfTasks.RemoveATask();
						break;
					case 'd':
						Console.WriteLine();
						schedule = new CleaningSchedule(GetLengthOfDutyInDays());
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

		private static void ShowWelcomeAndListOfFlatmates(FlatmatesList listOfflatmates)
		{
			Console.WriteLine("VITEJ V PROGRAMU 'CISTE SPOLUBYDLENI'.");
			Console.WriteLine("\nSOUCASNI SPOLUBYDLICI:");
			listOfflatmates.WriteListOfNames();
		}

		private static int GetLengthOfDutyInDays()
		{
			Console.WriteLine("\nZVOL DELKU TRVANI SLUZBY:");
			Console.WriteLine(" Jak dlouho ma trvat sluzba jedne osoby?");
			Console.WriteLine(" Vypis pocet dnu (7, 10 nebo 14) a stiskni 'enter'.");


			int numberOfDays = int.Parse(Console.ReadLine());
			return numberOfDays;
		}

		private static void ShowSchedule(CleaningSchedule sched)
		{
			sched.ShowDateTodayAndFlatmateResponsibleForCurrentPeriod();
			sched.ShowLongSchedule();
		}

		private static void ShowListOfTasks(CleaningTaskList listOfTasks)
		{
			Console.WriteLine("\nSEZNAM CINNOSTI:");
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
