var target = Argument("target", "Default");
var config = Argument("configuration", "Release");

// TODO: Task("Upgrade").Does(() => DNVMUpgrade()) when support for dnvm is added.

Task("Restore")
    .Does(() =>
{
    var files = GetFiles("**/project.json");
    foreach (var file in files)
        DNURestore(file);
});

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
{
    MSBuild("flavor.net.sln", new MSBuildSettings()
        .SetConfiguration(config));
});

Task("Test")
    .Does(() =>
{
    // TODO: Replace with DNX("test") once support for dnx is added.
    var format = "artifacts/bin/flavor.net.tests/{0}/**/flavor.net.tests.dll";
    var pattern = string.Format(format, config);
    XUnit2(GetFiles(pattern));
});

Task("Default")
    .IsDependentOn("Build")
    .IsDependentOn("Test");

Task("Publish")
    .IsDependentOn("Default")
    .Does(() =>
{
    var format = "artifacts/bin/flavor.net/{0}/flavor.net.*.nupkg";
    var pattern = string.Format(format, config);
    var package = GetFiles(pattern)
        .Select(f => f.FullPath)
        .Single(p => !p.EndsWith("symbols.nupkg"));
    NuGetPush(package, new NuGetPushSettings());
});

RunTarget(target);
