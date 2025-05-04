namespace Aspire.Hosting.ApplicationModel;

public class KrokiServerContainerResource(string name) : ContainerResource(name), IResourceWithServiceDiscovery
{
    internal const string HttpEndpointName = "http";

    private EndpointReference? httpReference;
    public EndpointReference HttpEndpoint => httpReference ??= new(this, HttpEndpointName);
}
