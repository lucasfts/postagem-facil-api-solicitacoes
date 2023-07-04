using Azure.Messaging.ServiceBus;
using PostagemFacil.Solicitacoes.API.Business.Events;
using System.Text.Json;

namespace PostagemFacil.Solicitacoes.API.Business
{
    public class ColetaService : IHostedService, IDisposable
    {
        ServiceBusProcessor? _processor;
        private readonly ServiceBusClient _client;
        private readonly IServiceProvider _serviceProvider;

        public ColetaService(ServiceBusClient client, IServiceProvider serviceProvider)
        {
            _client = client;
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _processor = _client.CreateProcessor("coletas", new ServiceBusProcessorOptions());
            _processor.ProcessMessageAsync += MessageHandler;
            _processor.ProcessErrorAsync += ErrorHandler;
            _processor.StartProcessingAsync();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _processor?.DisposeAsync();
        }

        async Task MessageHandler(ProcessMessageEventArgs args)
        {
            var body = args.Message.Body.ToString();
            var coleta = JsonSerializer.Deserialize<SolicitacaoColetada>(body);
            using (var scope = _serviceProvider.CreateScope())
            {
                var _solictacoesService = scope.ServiceProvider.GetRequiredService<ISolicitacoesService>();
                await _solictacoesService.AtualizarStatus(coleta.SolicitacaoId, Enums.StatusEnum.COLETADO);
            }
            await args.CompleteMessageAsync(args.Message);
        }

        Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }
    }
}
