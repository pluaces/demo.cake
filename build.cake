var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

var solutionDir = Directory("./demo.cake");
var buildDir = Directory($"{solutionDir}/bin") + Directory(configuration);

Task("Clean")
    .Does(() =>
{
    CleanDirectory(buildDir);
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore($"{solutionDir}/demo.cake.sln");
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    if(IsRunningOnWindows())
    {
      MSBuild($"{solutionDir}/demo.cake.sln", settings =>
        settings.SetConfiguration(configuration));
    }
});

Task("Default")
    .IsDependentOn("Build");

RunTarget(target);