using System;
using System.IO;
using System.Web.Script.Serialization;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

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
	    }

	    private void OnErrorRaised(object sender, BuildErrorEventArgs buildErrorEventArgs)
	    {
			buildLog.BuildErrors.Add(new BuildError
				                         {
					                         TimeStamp = buildErrorEventArgs.Timestamp,
											 ErrorCode = buildErrorEventArgs.Code,
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
					                                 FinishTime = projectFinishedEventArgs.Timestamp,
													 IsBuildSucceeded = projectFinishedEventArgs.Succeeded,
													 Message = projectFinishedEventArgs.Message,
													 ProjectFile = projectFinishedEventArgs.ProjectFile
				                                 });
		}

	    private void OnProjectStarted(object sender, ProjectStartedEventArgs projectStartedEventArgs)
	    {
			buildLog.ProjectStartEvents.Add(new ProjectStartLog
				                                {
					                                StartTime = projectStartedEventArgs.Timestamp,
													Message = projectStartedEventArgs.Message,
													ProjectFile = projectStartedEventArgs.ProjectFile
				                                });
		}

	    private void OnBuildFinished(object sender, BuildFinishedEventArgs buildFinishedEventArgs)
	    {
		    buildLog.BuildEndTime = new BuildFinishLog
			                            {
				                            FinishTime = buildFinishedEventArgs.Timestamp,
											IsBuildSucceeded = buildFinishedEventArgs.Succeeded,
											Message = buildFinishedEventArgs.Message
			                            };
		    var javaScriptSerializer = new JavaScriptSerializer();
		    var buildLogString = javaScriptSerializer.Serialize(buildLog);
		    File.WriteAllText(@"c:\Work\log.txt",buildLogString);

	    }

	    private void OnBuildStarted(object sender, BuildStartedEventArgs buildStartedEventArgs)
	    {
		    buildLog.BuildStartTime = new BuildStartLog
			                              {
				                              StartTime = buildStartedEventArgs.Timestamp,
											  Message = buildStartedEventArgs.Message
			                              };
	    }
    }
}
