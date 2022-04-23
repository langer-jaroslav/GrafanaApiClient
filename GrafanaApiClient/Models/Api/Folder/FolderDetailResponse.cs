using System;

namespace GrafanaApiClient.Models.Api.Folder;

public class FolderDetailResponse : FolderResponse
{
    public string Url { get; set; } = null!;
    public bool HasAcl { get; set; }
    public bool CanSave { get; set; }
    public bool CanEdit { get; set; }
    public bool CanAdmin { get; set; }
    public string CreatedBy { get; set; } = null!;
    public DateTime Created { get; set; }
    public string UpdatedBy { get; set; } = null!;
    public DateTime Updated { get; set; }
    public int Version { get; set; }
}