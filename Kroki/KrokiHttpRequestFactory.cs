using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.IO.Compression;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Web;

namespace Kroki;
public class KrokiHttpRequestFactory
{
    public KrokiHttpRequestFactory() : this(KrokiEndpoint.Default) { }
    /// <param name="endpoint">The Kroki endpoint to use. This should not include diagram type or output format. For example: <c>https://kroki.io</c>.</param>
    public KrokiHttpRequestFactory(Uri endpoint)
    {
        if (!endpoint.IsAbsoluteUri)
        {
            throw new ArgumentException($"The {nameof(endpoint)} must be an absolute URI.", nameof(endpoint));
        }
        Endpoint = endpoint;
    }

    Uri Endpoint { get; }

    public Uri CreateGetRequestUri(KrokiRequest request, CompressionLevel diagramSourceCompressionLevel) => new(Endpoint, CreateGetRequestRelativeUri(request, diagramSourceCompressionLevel));
    public static Uri CreateGetRequestRelativeUri(KrokiRequest request, CompressionLevel diagramSourceCompressionLevel)
    {
        var query = DiagramOptionsToQuery(request.DiagramOptions);
        EncodedDiagram encodedDiagram = new(request.DiagramSource, diagramSourceCompressionLevel);

        Uri requestUri = new($"{request.DiagramType}/{request.OutputFormat.ToEndpointPath()}/{encodedDiagram}?{query}", UriKind.Relative);
        return requestUri;
    }

    [return: NotNullIfNotNull(nameof(diagramOptions))]
    public static string? DiagramOptionsToQuery(JsonObject? diagramOptions)
    {
        NameValueCollection? query;
        if (diagramOptions is not null)
        {
            query = HttpUtility.ParseQueryString("");
            foreach (var keyValue in diagramOptions)
            {
#if NET9_0_OR_GREATER
                query.Add(keyValue.Key, keyValue.Value?.ToJsonString(JsonSerializerOptions.Web));
#else
                query.Add(keyValue.Key, keyValue.Value?.ToJsonString());
#endif
            }
        }
        else
        {
            query = null;
        }

        return query?.ToString();
    }

    public HttpRequestMessage CreatePostRequest(KrokiRequest request)
    {
        var httpRequestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = Endpoint,
            Content = JsonContent.Create(request),
        };
        return httpRequestMessage;
    }
}
