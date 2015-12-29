var target = Argument("target", "Default");
var config = Argument("configuration", "Release");

Task("Build")
    .Does(() =>
{
    DNURestore();
    MSBuild("flavor.net.sln", new MSBuildSettings()
        .SetConfiguration(config));
});

Task("Test")
    .Does(() =>
{
    var pattern = string.Format("artifacts/bin/flavor.net.tests/{0}/**/flavor.net.tests.dll", config);
    XUnit2(GetFiles(pattern));
});

Task("Default")
    .IsDependentOn("Build")
    .IsDependentOn("Test");

Task("Publish")
    .IsDependentOn("Default")
    .Does(() =>
{
    var pattern = string.Format("artifacts/bin/flavor.net/{0}/flavor.net.*.nupkg", config);
    var package = GetFiles(pattern)
        .Select(f => f.FullPath)
        .Single(p => !p.EndsWith("symbols.nupkg"));
    NuGetPush(package, new NuGetPushSettings());
});

RunTarget(target);