namespace TestApp.Api.AppCenter;

public interface IAppCenterClient
{
    IBuilds Builds { get; set; }
}