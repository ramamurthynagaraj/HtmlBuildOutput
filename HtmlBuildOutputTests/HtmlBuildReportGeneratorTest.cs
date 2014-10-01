using System.Collections.Concurrent;

using HtmlBuildOutput;
using HtmlBuildOutput.HtmlReportUtils;

using NUnit.Framework;

namespace HtmlBuildOutputTests
{
    public class HtmlBuildReportGeneratorTest
    {
		[Test]
		public void ShouldGenerateHtmlReportForTheGivenBuildLog()
		{
			var buildLog = GetSampleBuildLog();
			var generatedHtmlReport = HtmlBuildReport.GenerateHtmlReportFor(buildLog);
			Assert.That(generatedHtmlReport, Is.Not.Null);
			Assert.That(generatedHtmlReport.Length, Is.GreaterThan(0));
		}

	    private static BuildLog GetSampleBuildLog()
	    {
		    return new BuildLog
			           {
				           BuildStartLog = new BuildStartLog
					                           {
						                           Time = "19/07/2012",
												   Message = "Build started"
					                           },
							BuildFinishLog = new BuildFinishLog
								                 {
									                 Time = "21/07/2012",
													 Message = "Build Finished",
													 IsBuildSucceeded = false
								                 },
							BuildErrors = new ConcurrentBag<CodeIssue>
								              {
									              new CodeIssue
										              {
											              Code = "error code",
														  ColumnNumber = 10,
														  LineNumber = 20,
														  FileName = "csharp class file",
														  ProjectFile = "csharp VS project",
														  Message = "error message from MSBuild",
														  Time = "20/07/2012"
										              }
								              }

			           };
	    }
    }
}
