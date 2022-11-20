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
			bool runProgram = true;

			FlatmatesList listOfflatmates = new FlatmatesList();
			ShowWelcomeAndCreateOrShowListOfFlatmates(listOfflatmates);

			CleaningTaskList listOfTasks = new CleaningTaskList();
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
						listOfflatmates.ShowListOfNames();
						break;
					case 's':
						Console.WriteLine();
						listOfflatmates.RemoveAFlatemate();
						//schedule.ShowLongSchedule();
						break;
					case 'p':
						Console.WriteLine();
						Console.WriteLine("PRIDANI NOVYCH SPOLUBYDLICICH:");
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

		private static void ShowWelcomeAndCreateOrShowListOfFlatmates(FlatmatesList listOfflatmates)
		{
			Console.WriteLine("VITEJ V PROGRAMU 'CISTE SPOLUBYDLENI'.");

			if (listOfflatmates.listOfFlatmates.Count == 0)
			{
				Console.WriteLine("\nNejsou zadani zadni spolubydlici.");
				listOfflatmates.AddAFlatemate();
			}
			else
			{
				Console.WriteLine("\nSOUCASNI SPOLUBYDLICI:");
				listOfflatmates.CallFileWithListOFFlatmates();
				listOfflatmates.ShowListOfNames();
			}
		}

		private static int GetLengthOfDutyInDays()
		{
			Console.WriteLine("\nZVOL DELKU TRVANI SLUZBY:");
			Console.WriteLine(" Jak dlouho ma trvat sluzba jedne osoby?");
			Console.WriteLine(" Vypis pocet dnu (7, 10 nebo 14) a stiskni 'Enter'.");

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
