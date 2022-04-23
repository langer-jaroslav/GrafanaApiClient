namespace GrafanaApiClient.Models.Api.Folder;

public class FolderCreateRequest
{
    /// <summary>
    /// Optional unique identifier.
    /// </summary>
    public string? Uid { get; set; }

    /// <summary>
    /// The title of the folder.
    /// </summary>
    public string Title { get; set; } = null!;
}
