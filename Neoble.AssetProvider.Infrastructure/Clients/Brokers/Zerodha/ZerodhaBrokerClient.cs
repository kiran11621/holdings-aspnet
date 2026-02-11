using Neoble.AssetProvider.Application.DTOs;
using Neoble.AssetProvider.Application.Interfaces.Clients.Brokers;
using Neoble.AssetProvider.Domain.Enums;
using Neoble.AssetProvider.Infrastructure.Http.Abstractions;

namespace Neoble.AssetProvider.Infrastructure.Clients.Brokers.Zerodha;

public class ZerodhaBrokerClient : IBrokerHoldingClient
{
    private readonly IExternalApiExecutor _externalApiExecutor;

    public ZerodhaBrokerClient(IExternalApiExecutor externalApiExecutor)
    {
        _externalApiExecutor = externalApiExecutor;
    }

    public BrokerType BrokerType => BrokerType.Zerodha;

    public async Task<IReadOnlyCollection<HoldingDto>> GetHoldingsAsync(CancellationToken cancellationToken = default)
    {
        var response = await _externalApiExecutor.GetAsync<ZerodhaHoldingResponse>("Zerodha", "Holding", cancellationToken);

        return response?.Data.Select(x => new HoldingDto
        {
            Broker = BrokerType,
            Isin = x.Isin,
            TradingSymbol = x.TradingSymbol,
            Exchange = x.Exchange,
            Quantity = x.Quantity,
            LastPrice = x.LastPrice,
            Pnl = x.Pnl
        }).ToList() ?? [];
    }
}
