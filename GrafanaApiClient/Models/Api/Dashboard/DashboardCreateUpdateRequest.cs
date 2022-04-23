namespace GrafanaApiClient.Models.Api.Dashboard;

public class DashboardCreateUpdateRequest
{
    /// <summary>
    /// The complete dashboard model, id = null to create a new dashboard.
    /// dashboard.id – id = null to create a new dashboard.
    /// dashboard.uid – Optional unique identifier when creating a dashboard.uid = null will generate a new uid.
    /// </summary>
    public object Dashboard { get; set; } = null!;

    /// <summary>
    /// The id of the folder to save the dashboard in.
    /// </summary>
    public int? FolderId { get; set; }

    /// <summary>
    /// The UID of the folder to save the dashboard in. Overrides the folderId.
    /// </summary>
    public string? FolderUid { get; set; }

    /// <summary>
    /// Set a commit message for the version history.
    /// </summary>
    public string Message { get; set; } = null!;

    /// <summary>
    /// Set to true if you want to overwrite existing dashboard with newer version, same dashboard title in folder or same dashboard uid.
    /// </summary>
    public bool Overwrite { get; set; }
}