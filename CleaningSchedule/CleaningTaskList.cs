﻿using Reminiscence.Indexes;
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

		public static int CleaningTasksCount { get; private set; }
		public CleaningTaskList()
		{
			ListOfTasks = new List<CleaningTask>
			{
				new CleaningTask("vytirani podlahy"),
				new CleaningTask("utirani prachu"),
				//new CleaningTask("myti oken"),
				//new CleaningTask("zametani"),
			};
			CleaningTasksCount = ListOfTasks.Count;
		}

		public void WriteListOfTasks()
		{
			
			TextColors.WriteTextInGreen("SEZNAM CINNOSTI:");

			if (CleaningTasksCount == 0)
			{
				Console.WriteLine("Nejsou zadane zadne cinnosti.");
				AddATask();
			}
			else
			{
				foreach (CleaningTask t in ListOfTasks)
				{
					int taskNumber = ListOfTasks.IndexOf(t) + 1;
					Console.WriteLine($" ({taskNumber}) {t.TaskName}");
				}
			}
		}
		public void AddATask()
		{
			Console.WriteLine(" Lze pridat jednu ci vice cinnosti.");
			Console.WriteLine(" Cinnosti potvrzuj klavesou 'Enter'.");
			Console.WriteLine(" Pro ukonceni zadavani stiskni 'k'.");

			bool validInput = true;
			char endKey;
			do
			{
				Console.WriteLine("Zapis novou cinnost:");
				string name = Console.ReadLine();
				CleaningTask newTask = new CleaningTask(name);

				if (newTask == null || Validations.IsNotEmptyString(newTask.TaskName))
				{
					validInput = false;
					TextColors.WriteTextInRed("Neplatny text.");
					break;
				}
				else if (TaskNameExists(newTask.TaskName))
				{
					TextColors.WriteTextInRed("Cinnost uz je v seznamu. Nelze pridat stejnou cinnost.");
					break;
				}
				else
				{
					ListOfTasks.Add(newTask);
					CleaningTasksCount++;
					endKey = Console.ReadKey().KeyChar;
				}
			}
			while (endKey != 'k' || !validInput);

			WriteListOfTasks();
		}

		public void RemoveATask()
		{
			string instruction = "Zadej cislo cinnosti, kterou chces smazat: ";
			Console.Write(instruction);

			int indexOfTaskToRemove = Validations.VerifyNumberWithinRange(1, ListOfTasks.Count, instruction);

			CleaningTask taskToRemove = ListOfTasks.Find(t => (ListOfTasks.IndexOf(t) + 1) == indexOfTaskToRemove);
			ListOfTasks.Remove(taskToRemove);
			CleaningTasksCount--;
			WriteListOfTasks();
		}

		public bool TaskNameExists(string tName)
		{
			CleaningTask taskSearched = ListOfTasks.Find(t => t.TaskName.ToLower() == tName.ToLower());
			return (taskSearched != null);
		}

		//public bool TaskIndexExists(int index)
		//{
		//	int i = index;
		//	return (i > 0 && i <= ListOfTasks.Count);
		//}
	}
}
