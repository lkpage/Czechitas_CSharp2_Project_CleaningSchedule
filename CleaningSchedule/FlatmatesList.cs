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

		public static int NumberOfFlatmates { get; private set; }
		public FlatmatesList()
		{
			listOfFlatmates = new List<Flatmate>()
			{
				new Flatmate("Ales", "Novotny"),
				new Flatmate("Bedrich", "Baudis"),
				new Flatmate ("Cyril","Cerny"),
				//new Flatmate("Borek", "Modry")
			};

			NumberOfFlatmates = listOfFlatmates.Count();
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
				Console.Write("Zadej krestni jmeno: ");
				string name = Console.ReadLine();
				Console.Write("Zadej prijmeni: ");
				string surname = Console.ReadLine();
				if (FlatmateExists(name, surname))
				{
					Console.WriteLine("Jmeno uz je v seznamu. Nelze pridat stejne jmeno.");
					break;
				}
				else
				{
					listOfFlatmates.Add(new Flatmate(name, surname));
					NumberOfFlatmates++;
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
				Console.WriteLine("Jmeno neni v seznamu, nelze smazat.");
			}
			listOfFlatmates.Remove(flatMateToRemove);

			//if (FlatmateExists(name, surname))
			//{
			//	listOfFlatmates.Remove(new Flatmate(name, surname));	//toto nefunguje
			//	NumberOfFlatmates--;
			//}
			//else
			//{
			//	Console.WriteLine("Jmeno neni v seznamu, nelze smazat.");
			//}
			ShowListOfNames();
		}

		public void ShowListOfNames()
		{
			Console.WriteLine("\nSEZNAM SPOLUBYDLICICH:");
			foreach (Flatmate f in listOfFlatmates)
			{
				Console.WriteLine($" {f.Name} {f.Surname}");
			}
		}

		//public void VerifyInputsForNameAndSurname(string flName, string flSurname)
		//{	string name = flName;
		//	string surname = flSurname;

		//}

		public bool FlatmateExists(string flName, string flSurname)
		{
			Flatmate fmSearched = listOfFlatmates.Find(f => f.Name.ToLower() == flName.ToLower() && f.Surname.ToLower() == flSurname.ToLower());
			//Console.WriteLine(fmSearched != null);
			return (fmSearched != null);
		}
	}
}
