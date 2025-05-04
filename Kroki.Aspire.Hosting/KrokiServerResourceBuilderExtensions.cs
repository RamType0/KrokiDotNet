using Aspire.Hosting.ApplicationModel;

namespace Aspire.Hosting;
public static class KrokiServerResourceBuilderExtensions
{
    public static IResourceBuilder<KrokiServerContainerResource> AddKrokiServer(
        this IDistributedApplicationBuilder builder,
        string name,
        int? httpPort = null)
    {
        KrokiServerContainerResource resource = new(name);
        return builder.AddResource(resource)
            .WithImage(KrokiServerContainerImageTags.Image, KrokiServerContainerImageTags.Tag)
            .WithImageRegistry(KrokiServerContainerImageTags.Registry)
            .WithHttpEndpoint(
            targetPort: 8000,
            port: httpPort,
            name: KrokiServerContainerResource.HttpEndpointName)
            .WithHttpHealthCheck("/health");
    }

    public static IResourceBuilder<T> WithKrokiMermaidServer<T>(
        this IResourceBuilder<T> builder,
        Action<IResourceBuilder<KrokiMermaidServerContainerResource>>? configureContainer = null,
        string? containerName = null)
        where T : KrokiServerContainerResource
    {
        IResourceBuilder<KrokiMermaidServerContainerResource> krokiMermaidServerBuilder;
        if (builder.ApplicationBuilder.Resources.OfType<KrokiMermaidServerContainerResource>().SingleOrDefault() is { } krokiMermaidServer)
        {
            krokiMermaidServerBuilder = builder.ApplicationBuilder.CreateResourceBuilder(krokiMermaidServer);
        }
        else
        {
            containerName ??= $"{builder.Resource.Name}-mermaid";

            krokiMermaidServer = new(containerName);

            krokiMermaidServerBuilder = builder.ApplicationBuilder.AddResource(krokiMermaidServer)
                .WithImage(KrokiMermaidServerContainerImageTags.Image, KrokiMermaidServerContainerImageTags.Tag)
                .WithImageRegistry(KrokiMermaidServerContainerImageTags.Registry)
                .WithHttpEndpoint(
                    targetPort: 8002,
                    name: KrokiMermaidServerContainerResource.HttpEndpointName)
                .WithHttpHealthCheck("/health");


        }

        configureContainer?.Invoke(krokiMermaidServerBuilder);

        builder.WaitFor(krokiMermaidServerBuilder);

        // https://github.com/dotnet/aspire/issues/8574
        if (builder.ApplicationBuilder.ExecutionContext.IsRunMode)
        {
            builder
                .WithEnvironment("KROKI_MERMAID_HOST", krokiMermaidServer.Name)
                .WithEnvironment("KROKI_MERMAID_PORT", $"{krokiMermaidServer.HttpEndpoint.Property(EndpointProperty.TargetPort)}");

        }
        else
        {
            builder
                .WithEnvironment("KROKI_MERMAID_HOST", $"{krokiMermaidServer.HttpEndpoint.Property(EndpointProperty.Host)}")
                .WithEnvironment("KROKI_MERMAID_PORT", $"{krokiMermaidServer.HttpEndpoint.Property(EndpointProperty.Port)}");
        }

            return builder;
    }
    public static IResourceBuilder<T> WithKrokiBpmnServer<T>(
        this IResourceBuilder<T> builder,
        Action<IResourceBuilder<KrokiBpmnServerContainerResource>>? configureContainer = null,
        string? containerName = null)
        where T : KrokiServerContainerResource
    {

        IResourceBuilder<KrokiBpmnServerContainerResource> krokiBpmnServerBuilder;
        if (builder.ApplicationBuilder.Resources.OfType<KrokiBpmnServerContainerResource>().SingleOrDefault() is { } krokiBpmnServer)
        {
            krokiBpmnServerBuilder = builder.ApplicationBuilder.CreateResourceBuilder(krokiBpmnServer);
        }
        else
        {
            containerName ??= $"{builder.Resource.Name}-bpmn";

            krokiBpmnServer = new(containerName);
            krokiBpmnServerBuilder = builder.ApplicationBuilder.AddResource(krokiBpmnServer)
                .WithImage(KrokiBpmnServerContainerImageTags.Image, KrokiBpmnServerContainerImageTags.Tag)
                .WithImageRegistry(KrokiBpmnServerContainerImageTags.Registry)
                .WithHttpEndpoint(
                    targetPort: 8003,
                    name: KrokiBpmnServerContainerResource.HttpEndpointName);


        }

        configureContainer?.Invoke(krokiBpmnServerBuilder);

        builder.WaitFor(krokiBpmnServerBuilder);

        // https://github.com/dotnet/aspire/issues/8574
        if (builder.ApplicationBuilder.ExecutionContext.IsRunMode)
        {
            builder
                .WithEnvironment("KROKI_BPMN_HOST", krokiBpmnServer.Name)
                .WithEnvironment("KROKI_BPMN_PORT", $"{krokiBpmnServer.HttpEndpoint.Property(EndpointProperty.TargetPort)}");

        }
        else
        {
            builder
                .WithEnvironment("KROKI_BPMN_HOST", $"{krokiBpmnServer.HttpEndpoint.Property(EndpointProperty.Host)}")
                .WithEnvironment("KROKI_BPMN_PORT", $"{krokiBpmnServer.HttpEndpoint.Property(EndpointProperty.Port)}");
        }
        return builder;
    }

    public static IResourceBuilder<T> WithKrokiExcalidrawServer<T>(
        this IResourceBuilder<T> builder,
        Action<IResourceBuilder<KrokiExcalidrawServerContainerResource>>? configureContainer = null,
        string? containerName = null)
        where T : KrokiServerContainerResource
    {
        IResourceBuilder<KrokiExcalidrawServerContainerResource> krokiExcalidrawServerBuilder;
        if (builder.ApplicationBuilder.Resources.OfType<KrokiExcalidrawServerContainerResource>().SingleOrDefault() is { } krokiExcalidrawServer)
        {
            krokiExcalidrawServerBuilder = builder.ApplicationBuilder.CreateResourceBuilder(krokiExcalidrawServer);
        }
        else
        {
            containerName ??= $"{builder.Resource.Name}-excalidraw";

            krokiExcalidrawServer = new(containerName);
            krokiExcalidrawServerBuilder = builder.ApplicationBuilder.AddResource(krokiExcalidrawServer)
                .WithImage(KrokiExcalidrawServerContainerImageTags.Image, KrokiExcalidrawServerContainerImageTags.Tag)
                .WithImageRegistry(KrokiExcalidrawServerContainerImageTags.Registry)
                .WithHttpEndpoint(
                    targetPort: 8004,
                    name: KrokiExcalidrawServerContainerResource.HttpEndpointName);


        }

        configureContainer?.Invoke(krokiExcalidrawServerBuilder);

        builder.WaitFor(krokiExcalidrawServerBuilder);

        // https://github.com/dotnet/aspire/issues/8574
        if (builder.ApplicationBuilder.ExecutionContext.IsRunMode)
        {
            builder
                .WithEnvironment("KROKI_EXCALIDRAW_HOST", krokiExcalidrawServer.Name)
                .WithEnvironment("KROKI_EXCALIDRAW_PORT", $"{krokiExcalidrawServer.HttpEndpoint.Property(EndpointProperty.TargetPort)}");

        }
        else
        {
            builder
                .WithEnvironment("KROKI_EXCALIDRAW_HOST", $"{krokiExcalidrawServer.HttpEndpoint.Property(EndpointProperty.Host)}")
                .WithEnvironment("KROKI_EXCALIDRAW_PORT", $"{krokiExcalidrawServer.HttpEndpoint.Property(EndpointProperty.Port)}");
        }


        return builder;
    }
    public static IResourceBuilder<T> WithKrokiDiagramsNetServer<T>(
        this IResourceBuilder<T> builder,
        Action<IResourceBuilder<KrokiDiagramsNetServerContainerResource>>? configureContainer = null,
        string? containerName = null)
        where T : KrokiServerContainerResource
    {
        IResourceBuilder<KrokiDiagramsNetServerContainerResource> krokiDiagramsNetServerBuilder;
        if (builder.ApplicationBuilder.Resources.OfType<KrokiDiagramsNetServerContainerResource>().SingleOrDefault() is { } krokiDiagramsNetServer)
        {
            krokiDiagramsNetServerBuilder = builder.ApplicationBuilder.CreateResourceBuilder(krokiDiagramsNetServer);
        }
        else
        {
            containerName ??= $"{builder.Resource.Name}-diagramsnet";

            krokiDiagramsNetServer = new(containerName);
            krokiDiagramsNetServerBuilder = builder.ApplicationBuilder.AddResource(krokiDiagramsNetServer)
                .WithImage(KrokiDiagramsNetServerContainerImageTags.Image, KrokiDiagramsNetServerContainerImageTags.Tag)
                .WithImageRegistry(KrokiDiagramsNetServerContainerImageTags.Registry)
                .WithHttpEndpoint(
                    targetPort: 8005,
                    name: KrokiDiagramsNetServerContainerResource.HttpEndpointName);


        }

        configureContainer?.Invoke(krokiDiagramsNetServerBuilder);

        builder.WaitFor(krokiDiagramsNetServerBuilder);

        // https://github.com/dotnet/aspire/issues/8574
        if (builder.ApplicationBuilder.ExecutionContext.IsRunMode)
        {
            builder
                .WithEnvironment("KROKI_DIAGRAMSNET_HOST", krokiDiagramsNetServer.Name)
                .WithEnvironment("KROKI_DIAGRAMSNET_PORT", $"{krokiDiagramsNetServer.HttpEndpoint.Property(EndpointProperty.TargetPort)}");

        }
        else
        {
            builder
                .WithEnvironment("KROKI_DIAGRAMSNET_HOST", $"{krokiDiagramsNetServer.HttpEndpoint.Property(EndpointProperty.Host)}")
                .WithEnvironment("KROKI_DIAGRAMSNET_PORT", $"{krokiDiagramsNetServer.HttpEndpoint.Property(EndpointProperty.Port)}");
        }


        return builder;
    }
}
