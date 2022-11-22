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

		//public void CallFileWithListOFFlatmates()
		//{
		//	string flatmatesFile = Path.Combine(
		//		Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
		//		"CleaningScheduleApp",
		//		"FlatmatesList.xml");

		//	if (!Directory.Exists(Path.GetDirectoryName(flatmatesFile)))
		//	{
		//		Directory.CreateDirectory(Path.GetDirectoryName(flatmatesFile));
		//	}

		//	if (listOfFlatmates.Count == 0)
		//	{
		//		AddAFlatemate();
		//	}

		//	XmlSerializer serializerFlatmates = new XmlSerializer(typeof(List<Flatmate>));

		//	using (StreamWriter writer = new StreamWriter(flatmatesFile))
		//	{
		//		serializerFlatmates.Serialize(writer, listOfFlatmates);
		//	}

		//	using (StreamReader reader = new StreamReader(flatmatesFile))
		//	{
		//		Flatmate fl = serializerFlatmates.Deserialize(reader) as Flatmate;
		//	}
		//}


		public void AddAFlatemate()
		{
			Console.WriteLine(" Lze pridat jednoho ci vice spolubydlicich.");
			Console.WriteLine(" Jmena potvrzuj klavesou 'Enter'.");
			Console.WriteLine(" Pro ukonceni zadavani stiskni 'k'.");

			char endKey;
			do
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

				if (FlatmateExists(name, surname))
				{
					TextColors.WriteTextInRed("Jmeno uz je v seznamu. Nelze pridat stejne jmeno.");
					break;
				}
				else
				{
					listOfFlatmates.Add(new Flatmate(name, surname));
					Console.WriteLine(" (Pro pridani dalsi osoby stiskni 'Enter'.)");
					FlatmatesCount++;
					endKey = Console.ReadKey().KeyChar;
				}
			}
			while (endKey != 'k');

			ShowListOfNames();
		}

		public void RemoveAFlatemate()
		{
			Console.Write("Zadej krestni jmeno: ");
			string name = Console.ReadLine();
			Console.Write("Zadej prijmeni: ");
			string surname = Console.ReadLine();
			Flatmate flToRemove = new Flatmate(name, surname);
			Flatmate flatMateToRemove = listOfFlatmates.Find(f => f.Name.ToLower() == name.ToLower() && f.Surname.ToLower() == surname.ToLower());
			if (FlatmateExists(name, surname) == false)
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
	}
}
