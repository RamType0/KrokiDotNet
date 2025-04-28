[![Version](https://img.shields.io/nuget/v/Kroki?logo=nuget&style=flat-square)](https://www.nuget.org/packages/RamType0.Markdig.Renderers.MudBlazor/)
[![Nuget downloads](https://img.shields.io/nuget/dt/Kroki?label=nuget%20downloads&logo=nuget&style=flat-square)](https://www.nuget.org/packages/RamType0.Markdig.Renderers.MudBlazor/)  
# [Kroki](https://github.com/yuzutech/kroki) client for .NET

## Getting started

Add `KrokiClient` to services.

```C#

builder.Services.AddKrokiClient();

```

Or just create `KrokiClient` directly.


```C#

KrokiClient client = new();

KrokiClient myHostedKrokiClient = new(new Uri("https://my-hosted-kroki.io"));

```


## How to use

```razor

@using global::Kroki
@using System.IO.Compression
@inject KrokiClient KrokiClient

<img src="@imageSrc" />

@code {
    [Parameter, EditorRequired]
    public required string DiagramType { get; set; }
    [Parameter, EditorRequired]
    public required string DiagramSource { get; set; }

    string imageSrc = "";

    protected override void OnParametersSet()
    {
        imageSrc = KrokiClient.CreateGetUri(new()
            {
                DiagramType = DiagramType,
                OutputFormat = FileFormat.Svg,
                DiagramSource = DiagramSource
            }, CompressionLevel.Optimal).AbsoluteUri;
    }
}

```