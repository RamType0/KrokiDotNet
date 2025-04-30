namespace Aspire.Hosting.ApplicationModel;

public class KrokiServerResource(string name) : ContainerResource(name), IResourceWithServiceDiscovery, IResourceWithConnectionString
{
    internal const string HttpEndpointName = "http";

    private EndpointReference? httpReference;
    public EndpointReference HttpEndpoint => httpReference ??= new(this, HttpEndpointName);

    public ReferenceExpression ConnectionStringExpression 
        => ReferenceExpression.Create($"http://{HttpEndpoint.Property(EndpointProperty.HostAndPort)}");
}
