using System.IO.Compression;
using System.Net.Http.Json;

namespace Kroki;

public class KrokiClient(HttpClient httpClient)
{
    HttpClient HttpClient { get; } = httpClient;
    public Task<HttpResponseMessage> GetAsync(KrokiRequest request, CompressionLevel diagramCompressionLevel, CancellationToken cancellationToken = default)
    {
        var requestUri = KrokiHttpRequestFactory.CreateGetRequestRelativeUri(request, diagramCompressionLevel);
        return HttpClient.GetAsync(requestUri, cancellationToken);
    }
    public Task<HttpResponseMessage> PostAsync(KrokiRequest request, CancellationToken cancellationToken = default)
    {
        return HttpClient.PostAsJsonAsync((Uri?)null, request, cancellationToken);
    }
}
