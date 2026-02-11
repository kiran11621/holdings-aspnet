# NeobleSolution (Dummy Clean Architecture Setup)

This repository now contains a scalable multi-project setup:

- `Neoble.API` - controllers, contracts, startup configuration.
- `Neoble.AssetProvider.Application` - use-case orchestration, DTOs, interfaces.
- `Neoble.AssetProvider.Domain` - entities, enums, value objects.
- `Neoble.AssetProvider.Infrastructure` - external API adapters and factory implementations.
- `Neoble.AssetProvider.Persistence` - placeholder persistence project for SQL/Mongo repositories.

## Implemented flow

1. `BrokerController` receives broker type in route.
2. `HoldingService` orchestrates use case.
3. `BrokerClientFactory` resolves strategy (`Upstox` / `Zerodha`).
4. Broker client calls the configured external endpoint through `ExternalApiExecutor`.
5. Data is mapped to application DTO and returned as API contract.

## Endpoints

- `GET /api/Broker/Upstox/holding`
- `GET /api/Broker/Zerodha/holding`

Configured remote APIs are Postman mock URLs inside `Neoble.API/appsettings.json`.
