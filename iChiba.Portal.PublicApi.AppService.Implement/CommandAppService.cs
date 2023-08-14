using Core.CQRS.Bus.Interfaces;
using Core.CQRS.Model.Implements;
using Core.CQRS.Service.Interfaces;
using iChibaShopping.Core.AppService.Implement;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class RabbitMqConfig : IRabbitMqConfig
    {
        public string Environment { get; set; }
        public string BrokerName { get; set; }
        public string RoutingKey { get; set; }
        public string QueueName { get; set; }
        public string InstanceName { get; set; }
        public int ReceiveCommandTimeout { get; set; }
    }

    public class CommandAppService<TCommandConfig> : BaseAppService
        where TCommandConfig : IRabbitMqConfig
    {
        private readonly ICommandSender<TCommandConfig> commandSender;

        public CommandAppService(ILogger logger,
            ICommandSender<TCommandConfig> commandSender)
            : base(logger)
        {
            this.commandSender = commandSender;
        }

        public async Task<TResult> SendAndReceiveResult<TResult>(Command command)
            where TResult : CommandResult
        {
            var commandResult = await commandSender.SendAndReceiveResult<TResult>(command);

            return commandResult;
        }

        public async Task<string> Send(Command command)
        {
            var resultKey = await commandSender.Send(command);

            return resultKey;
        }
    }
}
