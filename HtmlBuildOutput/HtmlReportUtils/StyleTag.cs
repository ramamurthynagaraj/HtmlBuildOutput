namespace HtmlBuildOutput.HtmlReportUtils
{
	public class StyleTag
	{
		public static string AllCssStyles = @"
			<style>
				*{
					color: white;
					padding: 5px;
				}
				body{
					background:darkcyan;
					margin: 20px;
				}
				.center{
					text-align: center;
				}
				.right{
					text-align: right;
				}
				.green{
					background : forestgreen;
				}
				.red{
					background : brown;
				}
				.yellow{
					background: darkgoldenrod;
				}
				.white{
					background : white;
				}
				.bold{
					font-weight: bold;
				}
			</style>
		";
	}
}
