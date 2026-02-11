# NeobleSolution (Clean Architecture Dummy Project)

This solution follows your architecture style with separated layers and scalable broker integrations.

## Projects
- `Neoble.API`
- `Neoble.AssetProvider.Application`
- `Neoble.AssetProvider.Domain`
- `Neoble.AssetProvider.Infrastructure`
- `Neoble.AssetProvider.Persistence`

## Implemented patterns
- Clean Architecture and layered separation.
- Factory pattern via `BrokerProviderFactory`.
- Strategy-like broker adapters (`UpstoxBrokerClient`, `ZerodhaBrokerClient`).
- Mapper resolver pattern via Infrastructure `HoldingMapperResolver` and broker-specific `IHoldingMapper<T>` implementations (external DTO mapping kept outside Application).
- External HTTP resolver/executor pattern via `ExternalApiConfigResolver` and `ExternalApiExecutor`.

## Holdings flow
1. API receives broker + request context (`userId`, `dpId`, `clientId`).
2. `HoldingService` resolves broker provider through factory.
3. Provider calls `IExternalApiExecutor.PostAsync(...)`.
4. Provider maps response through `HoldingMapperResolver`.
5. API returns normalized holding response.

## Endpoints
- `GET /api/Broker/Upstox/holding?userId=1&dpId=dp1&clientId=client1`
- `GET /api/Broker/Zerodha/holding?userId=1&dpId=dp1&clientId=client1`

## Configuration
External API URLs are resolved from `Neoble.API/appsettings.json` under `AssetProvider` section.
