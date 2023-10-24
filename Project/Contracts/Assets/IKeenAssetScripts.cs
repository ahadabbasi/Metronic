namespace Ahada.Metronic.Contracts.Assets;

public interface IKeenAssetScripts : IKeenAssets
{
    IEnumerable<string> Scripts { get; }
}