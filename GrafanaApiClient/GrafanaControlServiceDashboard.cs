using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GrafanaApiClient.Models.Api.Dashboard;
using GrafanaApiClient.Models.Exceptions;
using Newtonsoft.Json;

namespace GrafanaApiClient;

public partial interface IGrafanaControlService
{
    /// <summary>
    /// Will return the dashboard given the dashboard unique identifier (uid).
    /// Information about the unique identifier of a folder containing the requested dashboard might be found in the metadata.
    /// </summary>
    /// <param name="uid"></param>
    /// <returns></returns>
    Task<DashboardDetailResponse> DashboardGetItemAsync(string uid);

    /// <summary>
    /// Creates a new dashboard or updates an existing dashboard. When updating existing dashboards,
    /// if you do not define the folderId or the folderUid property, then the dashboard(s) are moved to the General folder.
    /// (You need to define only one property, not both).
    /// </summary>
    /// <param name="requestData"></param>
    /// <returns></returns>
    Task<DashboardResponse> DashboardCreateUpdateAsync(DashboardCreateUpdateRequest requestData);

    /// <summary>
    /// Will delete the dashboard given the specified unique identifier (uid).
    /// </summary>
    /// <exception cref="GrafanaRequestException"></exception>
    Task DashboardDeleteAsync(string uid);
}
public partial class GrafanaControlService
{
    public async Task<DashboardDetailResponse> DashboardGetItemAsync(string uid)
    {
        var url = _serviceUrl + $"/api/dashboards/uid/{uid}";

        var request = new HttpRequestMessage(HttpMethod.Get, url);

        var client = GetHttpClient();

        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode)
            throw new GrafanaRequestException(response);

        var json = await response.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<DashboardDetailResponse>(json);
        return data!;
    }

    public async Task<DashboardResponse> DashboardCreateUpdateAsync(DashboardCreateUpdateRequest requestData)
    {
        var url = _serviceUrl + "/api/dashboards/db";

        var request = new HttpRequestMessage(HttpMethod.Post, url);

        var dataJson = JsonConvert.SerializeObject(requestData);
        request.Content = new StringContent(dataJson, Encoding.UTF8, MediaTypeJson);
        var client = GetHttpClient();

        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode)
            throw new GrafanaRequestException(response);

        var json = await response.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<DashboardResponse>(json);
        return data!;
    }

    public async Task DashboardDeleteAsync(string uid)
    {
        var url = _serviceUrl + $"/api/dashboards/uid/{uid}";

        var request = new HttpRequestMessage(HttpMethod.Delete, url);

        var client = GetHttpClient();

        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode)
            throw new GrafanaRequestException(response);
    }
}