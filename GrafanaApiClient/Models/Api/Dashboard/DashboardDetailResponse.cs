namespace GrafanaApiClient.Models.Api.Dashboard;

public class DashboardDetailResponse
{
    public object Dashboard { get; set; } = null!;

   public General Meta { get; set; } = null!;

    public class General
    {
        public bool IsStarred { get; set; }
        public string Url { get; set; } = null!;
        public int FolderId { get; set; }
        public string FolderUid { get; set; } = null!;
    }
}