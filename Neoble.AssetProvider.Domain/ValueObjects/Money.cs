namespace Neoble.AssetProvider.Domain.ValueObjects;

public readonly record struct Money(decimal Value, string Currency = "INR")
{
    public override string ToString() => $"{Value:0.00} {Currency}";
}
