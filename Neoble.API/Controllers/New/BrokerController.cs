using Microsoft.AspNetCore.Mvc;
using Neoble.API.Contracts.Requests;
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

    [HttpGet("{broker}/holding")]
    public async Task<ActionResult<IReadOnlyCollection<HoldingResponse>>> GetHoldings(
        Broker broker,
        [FromQuery] HoldingRequest request,
        CancellationToken cancellationToken)
    {
        var holdings = await _holdingService.GetHoldingsAsync(
            broker,
            request.UserId,
            request.DpId,
            request.ClientId,
            cancellationToken);

        var result = holdings.Select(x => new HoldingResponse
        {
            UserId = x.UserId,
            Broker = x.Broker.ToString(),
            Isin = x.Isin,
            TradingSymbol = x.TradingSymbol,
            InstrumentToken = x.InstrumentToken,
            Exchange = x.Exchange,
            CompanyName = x.CompanyName,
            Quantity = x.Quantity,
            LastPrice = x.LastPrice,
            MarketValue = x.MarketValue,
            ProfitandLoss = x.ProfitandLoss,
            Product = x.Product
        }).ToList();

        return Ok(result);
    }
}
