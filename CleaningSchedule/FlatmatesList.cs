using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CleaningSchedule
{
	public class FlatmatesList
	{
		public List<Flatmate> listOfFlatmates { get; private set; } //proc nelze velke pismeno?

		public static int FlatmatesCount { get; private set; }
		public FlatmatesList()
		{
			listOfFlatmates = new List<Flatmate>()
			{
				new Flatmate("Ales", "Novotny"),
				new Flatmate("Bedrich", "Baudis"),
				//new Flatmate ("Cyril","Cerny"),
				//new Flatmate("Borek", "Modry")
			};

			FlatmatesCount = listOfFlatmates.Count();
		}

		public void CallFileWithListOFFlatmates()
		{
			string flatmatesFile = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				"CleaningScheduleApp",
				"FlatmatesList.txt");

			if (!Directory.Exists(Path.GetDirectoryName(flatmatesFile)))
			{
				Directory.CreateDirectory(Path.GetDirectoryName(flatmatesFile));
			}

			List<string> lines = new List<string>();
			List<Flatmate> newList = new List<Flatmate>();

			//newList = File.ReadAllLines(flatmatesFile).ToList(List<Flatmate>);

			lines = File.ReadAllLines(flatmatesFile).ToList();
			foreach (String line in lines)
			{
				string[] items = line.Split(' ');
				Flatmate f = new Flatmate(items[0], items[1]);
				newList.Add(f);
				//Console.WriteLine(line);
			}

			lines.Add("Neco dalsiho");
			File.AppendAllLines(flatmatesFile, lines);
		}


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
					TextColors.WriteTextInRed("Jmeno uz je v seznamu. Nelze pridat stejne jmeno.");
					break;
				}
				else
				{
					listOfFlatmates.Add(flToAdd);
					Console.WriteLine(" (Pro pridani dalsi osoby stiskni 'Enter', pro ukonceni 'k'.)");
					FlatmatesCount++;
					endKey = Console.ReadKey().KeyChar;
				}
			}
			while (endKey != 'k');

			ShowListOfNames();
		}

		public void RemoveAFlatemate()
		{
			Flatmate flToRemove = GetValidNameAndSurname();
			Flatmate flatMateToRemove = listOfFlatmates.Find(f => f.Name.ToLower() == flToRemove.Name.ToLower() && f.Surname.ToLower() == flToRemove.Surname.ToLower());
			if (FlatmateExists(flToRemove.Name, flToRemove.Surname) == false)
			{
				TextColors.WriteTextInRed("Jmeno neni v seznamu, nelze smazat.");
			}
			else
			{
				listOfFlatmates.Remove(flatMateToRemove);
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
			ShowListOfNames();
		}

		public void ShowListOfNames()
		{
			TextColors.WriteTextInGreen("SEZNAM SPOLUBYDLICICH:");
			if (FlatmatesCount == 0)
			{
				Console.WriteLine("Nejsou zadani zadni spolubydlici.");
				AddAFlatemate();
			}
			else if (FlatmatesCount == 1)
			{
				Console.WriteLine($"V seznamu spolubydlicich je pouze jedna osoba: {listOfFlatmates[0].Name} {listOfFlatmates[0].Surname}");
			}
			else
			{
				foreach (Flatmate f in listOfFlatmates)
				{
					Console.WriteLine($" {f.Name} {f.Surname}");
				}
			}
		}

		public bool FlatmateExists(string flName, string flSurname)
		{
			Flatmate fmSearched = listOfFlatmates.Find(f => f.Name.ToLower() == flName.ToLower() && f.Surname.ToLower() == flSurname.ToLower());
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
