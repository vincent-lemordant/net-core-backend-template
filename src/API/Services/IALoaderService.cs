using Infrastructure.IA;

namespace API.Services;
/// <summary>
/// Service for managing loading/preloading of models at app startup
/// </summary>
/// <seealso cref="IHostedService" />
public class IALoaderService : IHostedService
{
    private readonly IAService _IAService;

    /// <summary>
    /// Initializes a new instance of the <see cref="IALoaderService"/> class.
    /// </summary>
    /// <param name="_IAService">The model service.</param>
    public IALoaderService(IAService iAService)
    {
        _IAService = iAService;
    }


    /// <summary>
    /// Triggered when the application host is ready to start the service.
    /// </summary>
    /// <param name="cancellationToken">Indicates that the start process has been aborted.</param>
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _ = _IAService.LoadModel();
        await Task.CompletedTask;
    }


    /// <summary>
    /// Triggered when the application host is performing a graceful shutdown.
    /// </summary>
    /// <param name="cancellationToken">Indicates that the shutdown process should no longer be graceful.</param>
    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }
}