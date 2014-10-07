HtmlBuildOutput
===============
 HtmlBuildOutput is the custom logger for MSBuild tool.
 It generates the HtmlFile which displays Build Errors and Build Warnings.
 
Usage
=====
 MSBuild.exe [path of the solution] /logger:HtmlBuildOutput.dll;[path of the output file]
 e.g. MSBuild.exe C:\Work\HelloWorld\HelloWorld.sln /logger:C:\Work\HtmlBuildOutput.dll;C:\Work\BuildOutput.html
 
 
