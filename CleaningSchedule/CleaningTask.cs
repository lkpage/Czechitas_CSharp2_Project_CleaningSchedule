using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningSchedule
{
	public class CleaningTask
	{
		public string TaskName { get; private set; }

		public CleaningTask(string taskName)
		{
			TaskName = taskName;
		}
	}
}
