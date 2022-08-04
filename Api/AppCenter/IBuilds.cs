using TestApp.Api.AppCenter.Models;

namespace TestApp.Api.AppCenter;

public interface IBuilds
{
    public Task<Build> GetBuildAsync(string ownerName, string appName, int buildId);
    
    public Task<List<Build>> GetBuildsAsync(string branch, string ownerName, string appName);

    public Task<Build> CreateBuildAsync(string branch, string ownerName, string appName,
        BuildRequestParams buildParams);

    public Task<List<Branches>> ListBranchesAsync(string ownerName, string appName);
}

