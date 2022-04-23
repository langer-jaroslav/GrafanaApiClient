# GrafanaApiClient
[![NuGet version (GrafanaApiClient)](https://img.shields.io/nuget/v/GrafanaApiClient)](https://www.nuget.org/packages/GrafanaApiClient)

.NET Client library for [Grafana](https://grafana.com/ "Grafana's web site"). This is not official Grafana package.

Tested on Grafana 8.5

# Supported of [grafana apis](https://grafana.com/docs/grafana/latest/http_api/ "Grafana's api list")
- folder get/crud
- dashboard get/crud


## Getting started

   ```
   Package Manager : Install-Package Swashbuckle.AspNetCore -Version 6.3.1
   CLI : dotnet add package --version 6.3.1 Swashbuckle.AspNetCore
   ```

Add using and IGrafanaControlService as a service in Program.cs 

   ```csharp
   using GrafanaApiClient;
   ```

   ```csharp
   builder.Services.AddTransient<IGrafanaControlService, GrafanaControlService>();
   ```
   
Add Grafana block to your appsettings.json

    "Grafana": {
      "Url": "http://YOUR_GRAFANA_URL:3000",
      "ApiKey": "YOUR_API_KEY"
    }

# Using
Inject service then use service as following:

   ```csharp
   // get folders
   var result = await _grafanaControlService.FolderGetListAsync(limit);
   
   // create folder
   var requestData = new FolderCreateRequest()
   {
        Title = folderName,
   };
   try
   {
        var result = await _grafanaControlService.FolderCreateAsync(requestData);
   }
   catch(GrafanaRequestException ex)
   {
        Console.WriteLine(ex);
   }
   ```
   
# Example in api controller
Full useage example in custom controlller where grafana apis are called

   ```csharp
using System.ComponentModel.DataAnnotations;
using GrafanaApiClient;
using GrafanaApiClient.Models.Api.Folder;
using Microsoft.AspNetCore.Mvc;

namespace ExampleProject.MasterDataDao.Controllers.Grafana;

[Route("api/[controller]")]
[ApiController]
public class GrafanaFolderController : ControllerBase
{
    private readonly IGrafanaControlService _grafanaControlService;

    public GrafanaFolderController(IGrafanaControlService grafanaControlService)
    {
        _grafanaControlService = grafanaControlService;
    }
    [HttpGet("GetList")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<FolderResponse>> GetList(int? limit)
    {
        var result = await _grafanaControlService.FolderGetListAsync(limit);
        return Ok(result);
    }
    [HttpGet("GetItem")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<FolderResponse>> GetItem([Required] string uid)
    {
        var result = await _grafanaControlService.FolderGetItemAsync(uid);
        return Ok(result);
    }
    [HttpPost("Create")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<FolderResponse>> Create([FromBody, Required]string folderName)
    {
        var requestData = new FolderCreateRequest()
        {
            Title = folderName,
        };
        var result = await _grafanaControlService.FolderCreateAsync(requestData);
        return Ok(result);
    }
}
   ```
   
