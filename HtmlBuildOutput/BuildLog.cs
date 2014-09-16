using System;
using System.Collections.Generic;

namespace HtmlBuildOutput
{
	public class BuildLog
	{
		public BuildLog()
		{
			ProjectStartEvents = new List<ProjectStartLog>();
			ProjectFinishEvents = new List<ProjectFinishLog>();
			BuildErrors = new List<BuildError>();
		}
		public BuildStartLog BuildStartTime { get; set; }
		public BuildFinishLog BuildEndTime { get; set; }

		public List<ProjectStartLog> ProjectStartEvents { get; set; }
		public List<ProjectFinishLog> ProjectFinishEvents { get; set; }

		public List<BuildError> BuildErrors { get; set; } 
	}

	public class BuildError
	{
		public DateTime TimeStamp { get; set; }

		public string ErrorCode { get; set; }

		public string FileName { get; set; }

		public int ColumnNumber { get; set; }

		public int LineNumber { get; set; }

		public string ProjectFile { get; set; }

		public string Message { get; set; }

		public string SubCategory { get; set; }
	}

	public class ProjectStartLog : BuildStartLog
	{
		public string ProjectFile { get; set; }
	}


	public class ProjectFinishLog : BuildFinishLog
	{
		public string ProjectFile { get; set; }
	}

	public class BuildFinishLog
	{
		public DateTime FinishTime { get; set; }

		public bool IsBuildSucceeded { get; set; }

		public string Message { get; set; }
	}

	public class BuildStartLog
	{
		public DateTime StartTime { get; set; }

		public string Message { get; set; }
	}
}