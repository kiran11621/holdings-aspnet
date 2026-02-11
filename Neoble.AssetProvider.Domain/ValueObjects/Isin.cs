namespace Neoble.AssetProvider.Domain.ValueObjects;

public readonly record struct Isin(string Value)
{
    public override string ToString() => Value;
}
