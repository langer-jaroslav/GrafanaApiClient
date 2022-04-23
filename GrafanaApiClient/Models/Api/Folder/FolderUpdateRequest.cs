namespace GrafanaApiClient.Models.Api.Folder;

public class FolderUpdateRequest
{
    /// <summary>
    /// Provide another unique identifier than stored to change the unique identifier.
    /// </summary>
    public string Uid { get; set; } = null!;

    /// <summary>
    /// The title of the folder
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// Provide the current version to be able to update the folder. Not needed if overwrite=true.
    /// </summary>
    public int? Version { get; set; }

    /// <summary>
    /// Set to true if you want to overwrite existing folder with newer version
    /// </summary>
    public bool Overwrite { get; set; } = true;
}