using System.Web.Script.Serialization;

namespace HtmlBuildOutput.HtmlReportUtils
{
	public class HtmlBuildReport
	{
		public static string HtmlBuildReportTemplate = @"
			<html>
				<head>
					{0}
					{1}
				</head>
				<body>
					<div ng-app>
						<div ng-controller=""buildResultDisplayController"">
							<div ng-class=""buildResult.BuildFinishLog.IsBuildSucceeded ? 'green' : 'red'"">
								<h3 class=""center"">{{{{buildResult.BuildFinishLog.Message}}}}</h3>
								<div class=""right"">BuildStarted At: {{{{buildResult.BuildStartLog.Time}}}} </div>
								<div class=""right"">BuildCompleted At: {{{{buildResult.BuildFinishLog.Time}}}} </div>
							</div>
							<div>
								<div class=""white"">
									<div ng-repeat=""errorLog in buildResult.BuildErrors"">
										<div class=""red"">
											<div class=""bold"">Error</div>
											<div class=""right"">{{{{errorLog.Time}}}}</div>
											<div class=""bold"">{{{{errorLog.FileName}}}} ({{{{errorLog.LineNumber}}}},{{{{errorLog.ColumnNumber}}}}) ({{{{errorLog.Code}}}}) : {{{{errorLog.Message}}}}</div>
											<div>{{{{errorLog.ProjectFile}}}}</div>
											<div></div>
										</div>
									</div>
								</div>
							</div>
							<div>
								<div class=""white"">
									<div ng-repeat=""warningLog in buildResult.BuildWarnings"">
										<div class=""yellow"">
											<div class=""bold"">Warning</div>
											<div class=""right"">{{{{warningLog.Time}}}}</div>
											<div class=""bold"">{{{{warningLog.FileName}}}} ({{{{warningLog.LineNumber}}}},{{{{warningLog.ColumnNumber}}}}) ({{{{warningLog.Code}}}}) : {{{{warningLog.Message}}}}</div>
											<div>{{{{warningLog.ProjectFile}}}}</div>
											<div></div>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</body>
			</html>
		";

		public static string GenerateHtmlReportFor(BuildLog buildLog)
		{
			var javaScriptSerializer = new JavaScriptSerializer();
			var jsonBuildLog = javaScriptSerializer.Serialize(buildLog);
			var formattedScriptTags = string.Format(ScriptTag.AllScriptTagsTemplate, jsonBuildLog);
			return string.Format(HtmlBuildReportTemplate, formattedScriptTags, StyleTag.AllCssStyles);
		}
	}
}
