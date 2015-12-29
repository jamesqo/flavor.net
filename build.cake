var target = Argument("target", "Default");
var config = Argument("configuration", "Release");

Task("Default")
    .Does(() =>
{
    DNURestore();
    MSBuild("flavor.net.sln", new MSBuildSettings()
        .SetConfiguration(config));
});

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