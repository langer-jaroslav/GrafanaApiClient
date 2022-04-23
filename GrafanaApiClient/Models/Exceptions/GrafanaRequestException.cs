using System;
using System.Net;
using System.Net.Http;

namespace GrafanaApiClient.Models.Exceptions;

/// <summary>
/// Exception of grafana operations that failed
/// </summary>
public class GrafanaRequestException : Exception
{
    public HttpStatusCode ErrorCode => Response.StatusCode;
    public string ErrorMessage => Response.ReasonPhrase;
    public HttpResponseMessage Response { get; }
        
    public GrafanaRequestException(HttpResponseMessage response) 
        : base(response.ReasonPhrase)
    {
        Response = response;
    }
}