namespace BlazorPocket.Client.Configurations;

public class AppSettings
{
    public const string KEY = nameof(AppSettings);
    public string AppName { get; set; } = "BlazorPocketApp";
    public string PocketbaseUrl { get; set; } = "http://127.0.0.1:8090";
    public string Version { get; set; } = "";
}

