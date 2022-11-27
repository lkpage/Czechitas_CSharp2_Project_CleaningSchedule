using System;
using System.Collections.Generic;
using System.Globalization;

namespace CleaningSchedule
{
	public class CleaningSchedule
	{
		public DateTime DateToday { get; private set; }
		public DateTime ThisDutyStart { get; private set; }
		public int DutyLengthInDays { get; private set; }
		public int NumberOfDutyPeriodsShown { get; private set; }
		public FlatmatesList FmList { get; private set; }

		public CleaningSchedule(int dutyLengthInDays, FlatmatesList fmList)
		{
			DateToday = DateTime.Now;
			ThisDutyStart = GetDateOfThisWeekStart();
			DutyLengthInDays = dutyLengthInDays;
			NumberOfDutyPeriodsShown = 8;
			FmList = fmList;
		}

		public void ShowDateTodayAndFlatmateResponsibleForCurrentPeriod()
		{
			TextProperties.WriteTextInGreenWithEmptyLineAbove("AKTUALNI OBDOBI:");
			DateTime thisDutyEndDate = ThisDutyStart.AddDays(DutyLengthInDays - 1);
			string dayOfWeekToday = DateToday.ToString("dddd", new CultureInfo("cs-CZ"));
			Console.WriteLine($" Dnes je {dayOfWeekToday}, {DateToday.ToLongDateString()}.");
			//Console.WriteLine($" V dobe od {ThisDutyStart: dd. MM.} - {thisDutyEndDate: dd. MM.} ma sluzbu: {listOfFlatmates[0].Name} {listOfFlatmates[0].Surname}");
		}

		public void ShowLongSchedule()
		{
			TextProperties.WriteTextInGreenWithEmptyLineAbove("ROZPIS SLUZEB:");
			if (FmList.ListOfFlatmates.Count == 0)
			{
				Console.WriteLine("Rozpis nelze zobrazit, seznam spolubydlicich je prazdny.");
			}
			else if (FmList.ListOfFlatmates.Count == 1)
			{
				Console.WriteLine($"V seznamu spolubydlicich je pouze 1 osoba: {FmList.ListOfFlatmates[0].Name} {FmList.ListOfFlatmates[0].Surname}");
			}
			else
			{
				Console.WriteLine($"Delka sluzby ve dnech: {DutyLengthInDays}");
				Console.WriteLine("Prvni sluzba zacina nejblizsi pondeli.");
				DateTime startDate = ThisDutyStart;
				DateTime endDate;
				int daysAdded = DutyLengthInDays - 1;
				List<Flatmate> adjustedList = AdjustListOfFlatmates(NumberOfDutyPeriodsShown);
				for (int i = 0; i < NumberOfDutyPeriodsShown; i++)
				{
					endDate = startDate.AddDays(daysAdded);
					Console.WriteLine($"{startDate: dd. MM.} - {endDate: dd. MM.} - {adjustedList[i].Name} {adjustedList[i].Surname}");
					startDate = endDate.AddDays(1);
				}
			}
		}

		public List<Flatmate> AdjustListOfFlatmates(int NumberOfDutyPeriodsShown)
		{
			int adjustedListCount = NumberOfDutyPeriodsShown - FmList.ListOfFlatmates.Count;
			List<Flatmate> adjustedList = new List<Flatmate>(FmList.ListOfFlatmates);
			for (int i = 0; i < adjustedListCount; i++)
			{
				adjustedList.Add(adjustedList[i]);
			}
			return adjustedList;
		}

		public DateTime GetDateOfThisWeekStart()
		{
			int IndexOfWeekdayToday = (int)DateTime.Now.DayOfWeek;
			switch (IndexOfWeekdayToday)
			{
				case 1:
					ThisDutyStart = DateToday;
					break;
				case 2:
					ThisDutyStart = DateToday.AddDays(+6);
					break;
				case 3:
					ThisDutyStart = DateToday.AddDays(+5);
					break;
				case 4:
					ThisDutyStart = DateToday.AddDays(+4);
					break;
				case 5:
					ThisDutyStart = DateToday.AddDays(+3);
					break;
				case 6:
					ThisDutyStart = DateToday.AddDays(+2);
					break;
				case 0:
					ThisDutyStart = DateToday.AddDays(+1);
					break;
				default:
					break;
			}
			return ThisDutyStart;
		}
	}
}
