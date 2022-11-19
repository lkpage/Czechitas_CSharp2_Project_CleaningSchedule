using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningSchedule
{
	public class CleaningTaskList
	{
		public List<CleaningTask> ListOfTasks { get; private set; }

		public CleaningTaskList()
		{
			ListOfTasks = new List<CleaningTask>
			{
				new CleaningTask("vytirani podlahy"),
				new CleaningTask("utirani prachu"),
				new CleaningTask("myti oken"),
			};
		}

		public void WriteListOfTasks()
		{
			foreach (CleaningTask t in ListOfTasks)
			{
				int taskNumber = ListOfTasks.IndexOf(t) + 1;
				Console.WriteLine($" {taskNumber}. {t.TaskName}");
			}
		}
		public void AddATask()
		{
			Console.Write("Zapis novou cinnost: ");
			string name = Console.ReadLine();
			//Console.Write("Zvol cetnost: ");
			//string frequecy = Console.ReadLine();
			CleaningTask newTask = new CleaningTask(name);
			ListOfTasks.Add(newTask);
			Console.WriteLine("\nAktualizovany seznam cinnosti:");
			WriteListOfTasks();
		}

		public void RemoveATask()
		{
			Console.Write("Zadej cislo cinnosti, kterou chces smazat: ");
			int indexOfTaskToRemove = int.Parse(Console.ReadLine());
			CleaningTask taskToRemove = ListOfTasks.Find(t => (ListOfTasks.IndexOf(t) + 1) == indexOfTaskToRemove);
			ListOfTasks.Remove(taskToRemove);
			Console.WriteLine("\nAktualizovany seznam cinnosti:");
			WriteListOfTasks();
		}
	}
}
