using Microsoft.AspNetCore.Mvc;
using Neoble.API.Contracts.Responses;
using Neoble.AssetProvider.Application.Services.Portfolio;
using Neoble.AssetProvider.Domain.Enums;

namespace Neoble.API.Controllers.New;

[ApiController]
[Route("api/[controller]")]
public class BrokerController : ControllerBase
{
    private readonly HoldingService _holdingService;

    public BrokerController(HoldingService holdingService)
    {
        _holdingService = holdingService;
    }

    [HttpGet("{brokerType}/holding")]
    public async Task<ActionResult<IReadOnlyCollection<HoldingResponse>>> GetHoldings(
        BrokerType brokerType,
        CancellationToken cancellationToken)
    {
        var holdings = await _holdingService.GetHoldingsAsync(brokerType, cancellationToken);
        var result = holdings.Select(x => new HoldingResponse
        {
            UserId = x.UserId,
            Broker = x.Broker.ToString(),
            Isin = x.Isin,
            TradingSymbol = x.TradingSymbol,
            Exchange = x.Exchange,
            Quantity = x.Quantity,
            LastPrice = x.LastPrice,
            Pnl = x.Pnl
        }).ToList();

        return Ok(result);
    }
}
