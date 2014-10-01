using System.IO;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using HtmlBuildOutput.HtmlReportUtils;

namespace HtmlBuildOutput
{
    public class LogGenerator : Logger
    {
	    private static BuildLog buildLog;

	    public LogGenerator()
	    {
		    buildLog = new BuildLog();
	    }

	    public override void Initialize(IEventSource eventSource)
	    {
		    eventSource.BuildStarted += OnBuildStarted; 
			eventSource.BuildFinished += OnBuildFinished;
			eventSource.ProjectStarted += OnProjectStarted;
			eventSource.ProjectFinished += OnProjectFinished;
			eventSource.ErrorRaised += OnErrorRaised;
			eventSource.WarningRaised += OnWarningRaised;
	    }

	    private void OnWarningRaised(object sender, BuildWarningEventArgs buildWarningEventArgs)
	    {		    
			buildLog.BuildWarnings.Add(new CodeIssue
				                           {
					                           Time = buildWarningEventArgs.Timestamp.ToString(),
											   Code = buildWarningEventArgs.Code,
											   FileName = buildWarningEventArgs.File,
											   ProjectFile = buildWarningEventArgs.ProjectFile,
											   Message = buildWarningEventArgs.Message,
											   SubCategory = buildWarningEventArgs.Subcategory,
											   LineNumber = buildWarningEventArgs.LineNumber,
											   ColumnNumber = buildWarningEventArgs.ColumnNumber
				                           });
		}

	    private void OnErrorRaised(object sender, BuildErrorEventArgs buildErrorEventArgs)
	    {
			buildLog.BuildErrors.Add(new CodeIssue
				                         {
					                         Time = buildErrorEventArgs.Timestamp.ToString(),
											 Code = buildErrorEventArgs.Code,
											 FileName = buildErrorEventArgs.File,
											 ProjectFile = buildErrorEventArgs.ProjectFile,
											 Message = buildErrorEventArgs.Message,
											 SubCategory = buildErrorEventArgs.Subcategory,
											 LineNumber = buildErrorEventArgs.LineNumber,
											 ColumnNumber = buildErrorEventArgs.ColumnNumber
				                         });
	    }

	    private void OnProjectFinished(object sender, ProjectFinishedEventArgs projectFinishedEventArgs)
	    {
			buildLog.ProjectFinishEvents.Add(new ProjectFinishLog
				                                 {
					                                 Time = projectFinishedEventArgs.Timestamp.ToString(),
													 IsBuildSucceeded = projectFinishedEventArgs.Succeeded,
													 Message = projectFinishedEventArgs.Message,
													 ProjectFile = projectFinishedEventArgs.ProjectFile
				                                 });
		}

	    private void OnProjectStarted(object sender, ProjectStartedEventArgs projectStartedEventArgs)
	    {
			buildLog.ProjectStartEvents.Add(new ProjectStartLog
				                                {
					                                Time = projectStartedEventArgs.Timestamp.ToString(),
													Message = projectStartedEventArgs.Message,
													ProjectFile = projectStartedEventArgs.ProjectFile
				                                });
		}

	    private void OnBuildFinished(object sender, BuildFinishedEventArgs buildFinishedEventArgs)
	    {
		    buildLog.BuildFinishLog = new BuildFinishLog
			                            {
				                            Time = buildFinishedEventArgs.Timestamp.ToString(),
											IsBuildSucceeded = buildFinishedEventArgs.Succeeded,
											Message = buildFinishedEventArgs.Message
			                            };
		    
		    File.WriteAllText(@"c:\Work\log.html",HtmlBuildReport.GenerateHtmlReportFor(buildLog));

	    }

	    private void OnBuildStarted(object sender, BuildStartedEventArgs buildStartedEventArgs)
	    {
		    buildLog.BuildStartLog = new BuildStartLog
			                              {
				                              Time = buildStartedEventArgs.Timestamp.ToString(),
											  Message = buildStartedEventArgs.Message
			                              };
	    }
    }
}
