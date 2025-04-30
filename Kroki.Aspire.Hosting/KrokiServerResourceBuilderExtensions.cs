using Aspire.Hosting.ApplicationModel;

namespace Aspire.Hosting;
public static class KrokiServerResourceBuilderExtensions
{
    public static IResourceBuilder<KrokiServerResource> AddKrokiServer(
        this IDistributedApplicationBuilder builder,
        string name,
        int? httpPort = null)
    {
        KrokiServerResource resource = new(name);
        return builder.AddResource(resource)
            .WithImage(KrokiServerContainerImageTags.Image)
            .WithImageRegistry(KrokiServerContainerImageTags.Registry)
            .WithHttpEndpoint(
            targetPort: 8000,
            port: httpPort,
            name: KrokiServerResource.HttpEndpointName);
    }
}
