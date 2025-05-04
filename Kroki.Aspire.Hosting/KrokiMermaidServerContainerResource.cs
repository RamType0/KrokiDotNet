namespace Aspire.Hosting.ApplicationModel;

public class KrokiMermaidServerContainerResource(string name) : ContainerResource(name)
{
    internal const string HttpEndpointName = "http";

    private EndpointReference? httpReference;
    public EndpointReference HttpEndpoint => httpReference ??= new(this, HttpEndpointName);
}
