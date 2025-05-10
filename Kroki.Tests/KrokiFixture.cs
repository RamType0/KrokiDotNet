using Aspire.Hosting;
using Kroki.Tests;

[assembly: AssemblyFixture(typeof(KrokiFixture))]
namespace Kroki.Tests;
public class KrokiFixture : IAsyncLifetime
{
    public DistributedApplication App { get; private set; } = null!;

    public HttpClient HttpClient { get; private set; } = null!;
    public KrokiClient KrokiClient { get; private set; } = null!;
    public async ValueTask InitializeAsync()
    {
        // Arrange
        var appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.Kroki_Tests_AppHost>();
        appHost.Services.ConfigureHttpClientDefaults(clientBuilder =>
        {
            clientBuilder.AddStandardResilienceHandler();
        });
        // To output logs to the xUnit.net ITestOutputHelper, consider adding a package from https://www.nuget.org/packages?q=xunit+logging

        App = await appHost.BuildAsync();
        var resourceNotificationService = App.Services.GetRequiredService<ResourceNotificationService>();
        await App.StartAsync();

        // Act
        HttpClient = App.CreateHttpClient("kroki");
        KrokiClient = new KrokiClient(HttpClient);
        await resourceNotificationService.WaitForResourceAsync("kroki", KnownResourceStates.Running).WaitAsync(TimeSpan.FromSeconds(30));

    }
    public ValueTask DisposeAsync() => App.DisposeAsync();

}