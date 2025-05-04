namespace Aspire.Hosting.ApplicationModel;

public class KrokiDiagramsNetServerContainerResource(string name) : ContainerResource(name)
{
    internal const string HttpEndpointName = "http";

    private EndpointReference? httpReference;
    public EndpointReference HttpEndpoint => httpReference ??= new(this, HttpEndpointName);
}
