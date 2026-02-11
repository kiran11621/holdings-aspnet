namespace Neoble.AssetProvider.Domain.ValueObjects;

public readonly record struct Quantity(int Value)
{
    public static Quantity Zero => new(0);
    public override string ToString() => Value.ToString();
}
