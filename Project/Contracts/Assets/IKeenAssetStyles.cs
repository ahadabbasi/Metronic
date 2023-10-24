namespace Ahada.Metronic.Contracts.Assets;

public interface IKeenAssetStyles : IKeenAssets
{
    IEnumerable<string> Styles { get; }
}