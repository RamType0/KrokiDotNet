namespace Kroki.Tests;

public class HealthTests(KrokiFixture fixture)
{
    [Fact]
    public async Task GetHealthReturnsOkStatusCode()
    {
        var response = await fixture.HttpClient.GetAsync("/health", TestContext.Current.CancellationToken);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
