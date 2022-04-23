using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GrafanaApiClient.Models.Api.Folder;
using GrafanaApiClient.Models.Exceptions;
using Newtonsoft.Json;

namespace GrafanaApiClient;

public partial interface IGrafanaControlService
{
    /// <summary>
    /// Returns all folders that the authenticated user has permission to view.
    /// You can control the maximum number of folders returned through the limit query parameter, the default is 1000.
    /// </summary>
    /// <exception cref="GrafanaRequestException"></exception>
    Task<IList<FolderResponse>> FolderGetListAsync(int? limit);

    /// <summary>
    /// Will return the folder given the folder uid.
    /// </summary>
    /// <exception cref="GrafanaRequestException"></exception>
    Task<FolderDetailResponse> FolderGetItemAsync(string uid);

    /// <summary>
    /// Creates a new folder.
    /// </summary>
    /// <exception cref="GrafanaRequestException"></exception>
    Task<FolderResponse> FolderCreateAsync(FolderCreateRequest requestData);

    /// <summary>
    /// Updates an existing folder identified by uid.
    /// </summary>
    /// <exception cref="GrafanaRequestException"></exception>
    Task<FolderDetailResponse> FolderUpdateAsync(FolderUpdateRequest requestData);

    /// <summary>
    /// Deletes an existing folder identified by UID along with all dashboards (and their alerts) stored in the folder.
    /// This operation cannot be reverted.
    /// </summary>
    /// <exception cref="GrafanaRequestException"></exception>
    Task FolderDeleteAsync(string uid);
}
public partial class GrafanaControlService
{
    public async Task<IList<FolderResponse>> FolderGetListAsync(int? limit)
    {
        var url = _serviceUrl + $"/api/folders";
        if (limit != null)
            url += $"?limit={limit}";


        var request = new HttpRequestMessage(HttpMethod.Get, url);

        var client = GetHttpClient();

        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode)
            throw new GrafanaRequestException(response);

        var json = await response.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<IList<FolderResponse>>(json);
        return data!;
    }
   
    public async Task<FolderDetailResponse> FolderGetItemAsync(string uid)
    {
        var url = _serviceUrl + $"/api/folders/{uid}";

        var request = new HttpRequestMessage(HttpMethod.Get, url);

        var client = GetHttpClient();

        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode)
            throw new GrafanaRequestException(response);

        var json = await response.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<FolderDetailResponse>(json);
        return data!;
    }

    public async Task<FolderResponse> FolderCreateAsync(FolderCreateRequest requestData)
    {
        var url = _serviceUrl + "/api/folders";

        var request = new HttpRequestMessage(HttpMethod.Post, url);

        var dataJson = JsonConvert.SerializeObject(requestData);
        request.Content = new StringContent(dataJson, Encoding.UTF8, MediaTypeJson);
        var client = GetHttpClient();

        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode)
            throw new GrafanaRequestException(response);

        var json = await response.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<FolderResponse>(json);
        return data!;
    }

    public async Task<FolderDetailResponse> FolderUpdateAsync(FolderUpdateRequest requestData)
    {
        var url = _serviceUrl + $"/api/folders/{requestData.Uid}";

        var request = new HttpRequestMessage(HttpMethod.Put, url);

        var dataJson = JsonConvert.SerializeObject(requestData);
        request.Content = new StringContent(dataJson, Encoding.UTF8, MediaTypeJson);
        var client = GetHttpClient();

        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode)
            throw new GrafanaRequestException(response);

        var json = await response.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<FolderDetailResponse>(json);
        return data!;
    }

    public async Task FolderDeleteAsync(string uid)
    {
        var url = _serviceUrl + $"/api/folders/{uid}";

        var request = new HttpRequestMessage(HttpMethod.Delete, url);

        var client = GetHttpClient();

        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode)
            throw new GrafanaRequestException(response);
    }
}