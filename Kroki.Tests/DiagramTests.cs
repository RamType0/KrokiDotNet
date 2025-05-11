using System.IO.Compression;

namespace Kroki.Tests;

public class DiagramTests(KrokiFixture fixture)
{
    [Theory]
    [ClassData(typeof(DiagramTestData))]
    public async Task DiagramsRequestReturnsOkStatusCode(string diagramType, FileFormat outputFormat, string diagramSource, CompressionLevel? compressionLevel)
    {
        KrokiRequest request = new()
        {
            DiagramType = diagramType,
            DiagramSource = diagramSource,
            OutputFormat = outputFormat,
        };
        var cancellationToken = TestContext.Current.CancellationToken;
        var response = compressionLevel is { } level ? await fixture.KrokiClient.GetAsync(request, level, cancellationToken) : await fixture.KrokiClient.PostAsync(request, cancellationToken);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    }
}
