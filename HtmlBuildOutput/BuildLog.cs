using System.Collections.Concurrent;

namespace HtmlBuildOutput
{
	public class BuildLog
	{
		public BuildLog()
		{
			ProjectStartEvents = new ConcurrentBag<ProjectStartLog>();
			ProjectFinishEvents = new ConcurrentBag<ProjectFinishLog>();
			BuildErrors = new ConcurrentBag<CodeIssue>();
			BuildWarnings = new ConcurrentBag<CodeIssue>();
		}
		public BuildStartLog BuildStartLog { get; set; }
		public BuildFinishLog BuildFinishLog { get; set; }
		public ConcurrentBag<ProjectStartLog> ProjectStartEvents { get; set; }
		public ConcurrentBag<ProjectFinishLog> ProjectFinishEvents { get; set; }
		public ConcurrentBag<CodeIssue> BuildErrors { get; set; }
		public ConcurrentBag<CodeIssue> BuildWarnings { get; set; }
	}

	public class CodeIssue
	{
		public string Time { get; set; }

		public string Code { get; set; }

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
		public string Time { get; set; }

		public bool IsBuildSucceeded { get; set; }

		public string Message { get; set; }
	}

	public class BuildStartLog
	{
		public string Time { get; set; }

		public string Message { get; set; }
	}
}