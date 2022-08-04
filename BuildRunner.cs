using TestApp.Api.AppCenter;
using TestApp.Api.AppCenter.Models;

namespace TestApp;

public class BuildRunner
{
    private IAppCenterClient Client { get; set; }
    private string OwnerName { get; set; }
    private string AppName { get; set; }

    public List<int> StartBuilds()
    {
        var result = new List<int>();
        var branches = Client.Builds.ListBranchesAsync(OwnerName, AppName).GetAwaiter().GetResult();
        foreach (var branch in branches)
        {
            var buildsList = Client.Builds.GetBuildsAsync(branch.Branch.Name, OwnerName, AppName).GetAwaiter().GetResult();
            // skip if build is not setup
            if (buildsList == null || buildsList.Count == 0)
            {
                continue;
            }
            var newBuild = Client.Builds.CreateBuildAsync(branch.Branch.Name, OwnerName, AppName, new BuildRequestParams
            {
                SourceVersion = buildsList[0].SourceVersion,
                Debug = true
            }).Result;

            result.Add(newBuild.Id);
        }

        return result;
    }
    
    public List<Build> WaitBuilds(List<int> buildIds)
    {
        var result = new Build[buildIds.Count];
        while (true)
        {
            var buildsFinished = true;
            for (int i = 0; i < buildIds.Count; i++)
            {
                var build = Client.Builds.GetBuildAsync(OwnerName, AppName, buildIds[i]).GetAwaiter().GetResult();
                buildsFinished = buildsFinished && IsBuildFinished(build);
                result[i] = build;
                if (!IsBuildFinished(build)) Console.WriteLine($"Waiting build for branch {build.SourceBranch} " +
                                                               $"to succeed. Actual status is {build.Status}");
            }

            if (buildsFinished)
            {
                return result.ToList();;
            }
            
            Thread.Sleep(5000);
        }
    }
    
    private bool IsBuildFinished(Build build)
    {
        return String.Equals(build.Status, BuildStatus.Completed.ToString(), StringComparison.OrdinalIgnoreCase) 
               || String.Equals(build.Status, BuildStatus.Failed.ToString(),StringComparison.OrdinalIgnoreCase);
    }

    public BuildRunner(IAppCenterClient client, string ownerName, string appName)
    {
        Client = client;
        OwnerName = ownerName;
        AppName = appName;
    }
}