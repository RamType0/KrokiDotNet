[![Version](https://img.shields.io/nuget/v/Kroki?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Kroki/)
[![Nuget downloads](https://img.shields.io/nuget/dt/Kroki?label=nuget%20downloads&logo=nuget&style=flat-square)](https://www.nuget.org/packages/Kroki/)  
# [Kroki](https://github.com/yuzutech/kroki) integration for .NET

## Kroki Client

### Getting started

Add `KrokiHttpRequestFactory` to services.

```C#

builder.Services.AddKrokiHttpRequestFactory();

```

Or just create `KrokiHttpRequestFactory` directly.


```C#

KrokiHttpRequestFactory krokiHttpRequestFactory = new();

KrokiHttpRequestFactory myHostedKrokiHttpRequestFactory = new(new Uri("https://my-hosted-kroki.io"));

```


### How to use

```razor

@using global::Kroki
@using System.IO.Compression
@inject KrokiHttpRequestFactory KrokiHttpRequestFactory

<img src="@imageSrc" />

@code {
    [Parameter, EditorRequired]
    public required string DiagramType { get; set; }
    [Parameter, EditorRequired]
    public required string DiagramSource { get; set; }

    string imageSrc = "";

    protected override void OnParametersSet()
    {
        imageSrc = KrokiHttpRequestFactory.CreateGetRequestUri(new()
            {
                DiagramType = DiagramType,
                OutputFormat = FileFormat.Svg,
                DiagramSource = DiagramSource
            }, CompressionLevel.Optimal).AbsoluteUri;
    }
}

```
## Kroki Server Hosting

### Getting started

```C#

var kroki = builder.AddKrokiServer("kroki")
    .WithKrokiMermaidServer()
    .WithKrokiBpmnServer()
    .WithKrokiExcalidrawServer()
    .WithKrokiDiagramsNetServer();

var webFrontend = builder.AddProject<Projects.Web>("web-frontend")
    .WithExternalHttpEndpoints()
    .WithReference(kroki)

```
### How to use

Forward to Kroki server in your frontend project.

```C#


using Yarp.ReverseProxy.Forwarder;
using Yarp.ReverseProxy.Transforms;

public static IEndpointConventionBuilder MapKrokiForwarder(this IEndpointRouteBuilder endpoints)
{
    return endpoints.MapForwarder("/Kroki/{**apiPath}", "http://kroki", ForwarderRequestConfig.Empty,
        transformBuilderContext
        => transformBuilderContext
        .AddPathRemovePrefix("/Kroki")
        
        // Custom authorization logic!
        .AddRequestTransform(transformContext =>
        {

            HttpContext httpContext = transformContext.HttpContext;
            if(httpContext.User.Identity?.IsAuthenticated != true)
            {
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            }
            return new();
        }));
}

```
