namespace HtmlBuildOutput.HtmlReportUtils
{
	public class ScriptTag
	{
		public static string AllScriptTagsTemplate = @"
			<script src=""http://ajax.googleapis.com/ajax/libs/angularjs/1.2.25/angular.min.js""></script>
			<script type=""text/javascript"">
				var buildResult = {0};
			</script>
			<script type=""text/javascript"">
				function buildResultDisplayController ($scope) {{
					$scope.buildResult = buildResult;
				}}
			</script>
		";
	}
}
