namespace GrafanaApiClient.Models.Api.Dashboard;

public class DashboardResponse
{
    public int Id { get; set; }
    public string Uid { get; set; } = null!;
    public string Url { get; set; } = null!;
    public string Status { get; set; } = null!;
    public int Version { get; set; }
}