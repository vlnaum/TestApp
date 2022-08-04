// See https://aka.ms/new-console-template for more information

using TestApp;
using TestApp.Api.AppCenter;

Console.Write("Enter owner name: ");
var ownerName = Console.ReadLine();
Console.Write("Enter app name: ");
var appName = Console.ReadLine();
Console.Write("Enter app token: ");
var token = Console.ReadLine();

// token = "137f1a3a06329212f133f3a79caf787d77aae0cd";
// ownerName = "vlnaum";
// appName = "test-app";

using var appCenterClient = new AppCenterClient(token);
var buildRunner = new BuildRunner(appCenterClient, ownerName, appName);

try
{
    var buildIds = buildRunner.StartBuilds();
    var builds = buildRunner.WaitBuilds(buildIds);
    
    builds.ForEach(b => Console.WriteLine($"{b.SourceBranch} build {b.Result} " +
                                          $"in {(b.FinishTime - b.StartTime).Seconds} seconds. " +
                                          $"Link to build logs: https://api.appcenter.ms/v0.1/" +
                                          $"apps/{ownerName}/{appName}/builds/{b.Id}/logs"));
}
catch (Exception e)
{
    Console.WriteLine($"Error: {e.Message}");
}





