using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CleaningSchedule
{
	public class FlatmatesList
	{
		public List<Flatmate> ListOfFlatmates { get; private set; }

		public static int FlatmatesCount { get; private set; }
		public FlatmatesList()
		{


			ListOfFlatmates = new List<Flatmate>()
			{
				new Flatmate("Ales", "Novotny"),
				new Flatmate("Bedrich", "Baudis"),
				new Flatmate ("Cyril","Cerny"),
				new Flatmate("Borek", "Modry")
			};

			//ListOfFlatmates = ReadFileWithListOFFlatmates();

			FlatmatesCount = ListOfFlatmates.Count();
		}

		//public List<Flatmate> ReadFileWithListOFFlatmates()
		//{
		//	string flatmatesFile = Path.Combine(
		//		Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
		//		"CleaningScheduleApp",
		//		"FlatmatesList.txt");

		//	if (!Directory.Exists(Path.GetDirectoryName(flatmatesFile)))
		//	{
		//		Directory.CreateDirectory(Path.GetDirectoryName(flatmatesFile));
		//	}

		//	List<string> linesIn = File.ReadAllLines(flatmatesFile).ToList();

		//	List<Flatmate> list = new List<Flatmate>();
		//	foreach (String line in linesIn)
		//	{
		//		string[] items = line.Split(' ');
		//		Flatmate f = new Flatmate(items[0], items[1]);
		//		list.Add(f);
		//		//Console.WriteLine(f.ToString());
		//	}
		//	return list;
		//}


		//public void SaveInFileWithListOFFlatmates(Flatmate fm)
		//{
		//	string flatmatesFile = Path.Combine(
		//		Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
		//		"CleaningScheduleApp",
		//		"FlatmatesList.txt");

		//	if (!Directory.Exists(Path.GetDirectoryName(flatmatesFile)))
		//	{
		//		Directory.CreateDirectory(Path.GetDirectoryName(flatmatesFile));
		//	}

		//	Flatmate f = fm; 
		//	List<string> linesOut = new List<string>();

		//	linesOut.Add(f.ToString());

		//	//foreach (Flatmate f in listOfFlatmates)	//keeping for studying purposes
		//	//{
		//	//	linesOut.Add(f.ToString());
		//	//}

		//	File.AppendAllLines(flatmatesFile, linesOut);
		//}


		public void AddAFlatemate()
		{
			Console.WriteLine(" Lze pridat jednoho ci vice spolubydlicich.");
			Console.WriteLine(" Jmena potvrzuj klavesou 'Enter'.");
			Console.WriteLine(" Pro ukonceni zadavani stiskni 'k'.");

			char endKey;
			do
			{
				Flatmate flToAdd = GetValidNameAndSurname();

				if (FlatmateExists(flToAdd.Name, flToAdd.Surname))
				{
					TextProperties.WriteTextInRed("Jmeno uz je v seznamu. Nelze pridat stejne jmeno.");
					break;
				}
				else
				{
					//SaveInFileWithListOFFlatmates(flToAdd);
					ListOfFlatmates.Add(flToAdd);
					TextProperties.WriteTextInYellow("(Pro pridani dalsi osoby stiskni 'Enter', pro ukonceni 'k'.)");
					FlatmatesCount++;
					endKey = Console.ReadKey().KeyChar;
				}
			}
			while (endKey != 'k');

			ShowListOfFlatmates();
		}

		public void RemoveAFlatemate()
		{
			Flatmate flToRemove = GetValidNameAndSurname();
			Flatmate flatMateToRemove = ListOfFlatmates.Find(f => f.Name.ToLower() == flToRemove.Name.ToLower() && f.Surname.ToLower() == flToRemove.Surname.ToLower());
			if (FlatmateExists(flToRemove.Name, flToRemove.Surname) == false)
			{
				TextProperties.WriteTextInRed("Jmeno neni v seznamu, nelze smazat.");
			}
			else
			{
				ListOfFlatmates.Remove(flatMateToRemove);
				FlatmatesCount--;
			}

			//if (FlatmateExists(name, surname))
			//{
			//	listOfFlatmates.Remove(new Flatmate(name, surname));	//toto nefunguje
			//	FlatmatesCount--;
			//}
			//else
			//{
			//	Console.WriteLine("Jmeno neni v seznamu, nelze smazat.");
			//}
			ShowListOfFlatmates();
		}

		public void ShowListOfFlatmates()
		{
			TextProperties.WriteTextInGreenWithEmptyLineAbove("SEZNAM SPOLUBYDLICICH:");
			if (FlatmatesCount == 0)
			{
				Console.WriteLine("Nejsou zadani zadni spolubydlici.");
				AddAFlatemate();
			}
			else if (FlatmatesCount == 1)
			{
				Console.WriteLine($"V seznamu spolubydlicich je pouze jedna osoba: {ListOfFlatmates[0].Name} {ListOfFlatmates[0].Surname}");
			}
			else
			{
				foreach (Flatmate f in ListOfFlatmates)
				{
					Console.WriteLine($" {f.Name} {f.Surname}");
				}
			}
		}

		public bool FlatmateExists(string flName, string flSurname)
		{
			Flatmate fmSearched = ListOfFlatmates.Find(f => f.Name.ToLower() == flName.ToLower() && f.Surname.ToLower() == flSurname.ToLower());
			//Console.WriteLine(fmSearched != null);
			return (fmSearched != null);
		}

		public Flatmate GetValidNameAndSurname()
		{
			Console.Write("Zadej jmeno: ");
			string name = Console.ReadLine();
			while (!Validations.IsLettersOnly(name))
			{
				Console.Write("Zadej jmeno: ");
				name = Console.ReadLine();
			}

			Console.Write("Zadej prijmeni: ");
			string surname = Console.ReadLine();
			while (!Validations.IsLettersOnly(surname))
			{
				Console.Write("Zadej prijmeni: ");
				surname = Console.ReadLine();
			}

			return new Flatmate(name, surname);
		}
	}
}
