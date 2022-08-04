using TestApp.Api.AppCenter.Models;

namespace TestApp.Api.AppCenter;

public class Builds: IBuilds
{
    private AppCenterClient Client { get; set; }
    public Builds(AppCenterClient client)
    {
        Client = client ?? throw new System.ArgumentNullException("client");
    }

    public async Task<Build> GetBuildAsync(string ownerName, string appName, int buildId)
    {
        var uri = ($"v0.1/apps/{ownerName}/{appName}/builds/{buildId}");
        return await Client.GetJsonAsync<Build>(uri);
    }

    public async Task<List<Build>> GetBuildsAsync(string branch, string ownerName, string appName)
    {
        var uri = ($"v0.1/apps/{ownerName}/{appName}/branches/{branch}/builds");
        return await Client.GetJsonAsync<List<Build>>(uri);
    }

    public async Task<Build> CreateBuildAsync(string branch, string ownerName, string appName, BuildRequestParams buildParams)
    {
        var uri = ($"v0.1/apps/{ownerName}/{appName}/branches/{branch}/builds");
        return await Client.PostJsonAsync<BuildRequestParams, Build>(uri, buildParams);
    }
    
    public async Task<List<Branches>> ListBranchesAsync(string ownerName, string appName)
    {
        var uri = ($"v0.1/apps/{ownerName}/{appName}/branches");
        return await Client.GetJsonAsync<List<Branches>>(uri);
    }
}