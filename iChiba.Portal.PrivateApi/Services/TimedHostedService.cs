using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace iChiba.Portal.PrivateApi.Services
{
    internal interface IScopedProcessingService
    {
        //Task ResetWarehouseEmp(CancellationToken stoppingToken);
    }

    internal class ScopedProcessingService : IScopedProcessingService
    {
        private readonly ILogger _logger;

        public ScopedProcessingService(
            ILogger<ScopedProcessingService> logger)
        {
            _logger = logger;
        }

        //public async Task ResetWarehouseEmp(CancellationToken stoppingToken)
        //{
        //    try
        //    {
        //        while (!stoppingToken.IsCancellationRequested)
        //        {
        //            var dateTime = DateTime.UtcNow.ToLocalTime();

        //            // 24h: Reset all data warehouse emp
        //            if (dateTime.Hour == 0 && dateTime.Minute == 0 && dateTime.Second <= 5)
        //            {
        //                try
        //                {
        //                    await _warehouseAppService.ResetEmp();
        //                    //_logger.LogInformation($"Timed Hosted Service: Reset data at {dateTime:dd/MM/yyyy HH:mm:ss}");
        //                }
        //                catch (Exception ex)
        //                {
        //                    _logger.LogError(ex, ex.Message);
        //                }
        //            }

        //            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, ex.Message);
        //    }
        //}
    }

    public class TimedHostedService : BackgroundService
    {
        private readonly ILogger<TimedHostedService> _logger;

        public TimedHostedService(IServiceProvider services, ILogger<TimedHostedService> logger)
        {
            Services = services;
            _logger = logger;
        }

        public IServiceProvider Services { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _ = Task.WhenAll(
                //DoSyncSurcharge(stoppingToken)
                );
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            await Task.CompletedTask;
        }

        //private async Task DoResetWarehouseEmp(CancellationToken stoppingToken)
        //{
        //    using (var scope = Services.CreateScope())
        //    {
        //        var scopedProcessingService = scope.ServiceProvider.GetRequiredService<IScopedProcessingService>();

        //        await scopedProcessingService.ResetWarehouseEmp(stoppingToken);
        //    }
        //}
    }
}