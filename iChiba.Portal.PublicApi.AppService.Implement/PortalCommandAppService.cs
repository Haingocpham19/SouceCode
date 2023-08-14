using Core.CQRS.Service.Interfaces;
using Microsoft.Extensions.Logging;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class PortalCommandRabbitMqConfig : RabbitMqConfig
    {
    }

    public class PortalCommandAppService : CommandAppService<PortalCommandRabbitMqConfig>
    {
        private readonly ICommandSender<PortalCommandRabbitMqConfig> commandSender;

        public PortalCommandAppService(ILogger<PortalCommandAppService> logger,
            ICommandSender<PortalCommandRabbitMqConfig> commandSender)
            : base(logger, commandSender)
        {
            this.commandSender = commandSender;
        }
    }
}
