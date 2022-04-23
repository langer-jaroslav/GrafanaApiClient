# GrafanaApiClient
[![NuGet version (Newtonsoft.Json)](https://img.shields.io/nuget/v/GrafanaApiClient)](https://www.nuget.org/packages/GrafanaApiClient)

## Instalation
Add IGrafanaControlService as a service in Program.cs 

    builder.Services.AddTransient<IGrafanaControlService, GrafanaControlService>();
    
Add Grafana block to your appsettings

    "Grafana": {
      "Url": "http://YOUR_GRAFANA_URL:3000",
      "ApiKey": "YOUR_API_KEY"
    }
