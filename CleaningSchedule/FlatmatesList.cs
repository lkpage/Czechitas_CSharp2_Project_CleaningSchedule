using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CleaningSchedule
{
	public class FlatmatesList
	{
		public List<Flatmate> listOfFlatmates { get; private set; } //proc nelze velke pismeno?
		public FlatmatesList()
		{
			listOfFlatmates = new List<Flatmate>()
			{
			//new Flatmate("Ales", "Novotny"),
			//new Flatmate("Bedrich", "Baudis"),
			//new Flatmate ("Cyril","Cerny"),
			//new Flatmate("Borek", "Modry")
			};

			//CallFileWithListOFFlatmates();
		}

		public void CallFileWithListOFFlatmates()
		{
			string flatmatesFile = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				"CleaningScheduleApp",
				"FlatmatesList.xml");

			if (!Directory.Exists(Path.GetDirectoryName(flatmatesFile)))
			{
				Directory.CreateDirectory(Path.GetDirectoryName(flatmatesFile));
			}

			if(listOfFlatmates.Count == 0)
			{
				Console.WriteLine("Nejsou zapsani zadni spolubydlici. Nize zadej jmena a stiskni 'Enter'.");
				AddAFlatemate();
			}

			XmlSerializer serializerFlatmates = new XmlSerializer(typeof(List<Flatmate>));

			using (StreamWriter writer = new StreamWriter(flatmatesFile))
			{
				serializerFlatmates.Serialize(writer, listOfFlatmates);
			}
			
			using (StreamReader reader = new StreamReader(flatmatesFile))
			{
				Flatmate fl = serializerFlatmates.Deserialize(reader) as Flatmate;
			}

		}

		public void WriteListOfNames()
		{
			foreach (Flatmate f in listOfFlatmates)
			{
				Console.WriteLine($" {f.Name} {f.Surname}");
			}
		}

		public void AddAFlatemate()
		{
			Console.Write("Zadej krestni jmeno: ");
			string jmeno = Console.ReadLine();
			Console.Write("Zadej prijmeni: ");
			string prijmeni = Console.ReadLine();
			listOfFlatmates.Add(new Flatmate(jmeno, prijmeni));
			Console.WriteLine("\nAktualizovany seznam spolubydlicich:");
			WriteListOfNames();
		}
		public void RemoveAFlatemate()
		{
			Console.Write("Zadej krestni jmeno: ");
			string nameToRemove = Console.ReadLine();
			Console.Write("Zadej prijmeni: ");
			string surnameToRemove = Console.ReadLine();//pridate case sensitivity & toLower
			Flatmate flatMateToRemove = listOfFlatmates.Find(f => f.Name == nameToRemove && f.Surname == surnameToRemove);
			listOfFlatmates.Remove(flatMateToRemove);
			Console.WriteLine("\nAktualizovany seznam spolubydlicich:");
			WriteListOfNames();
		}
	}
}
