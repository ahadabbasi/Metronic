using Ahada.Metronic.Contracts.Abstracts;

namespace Ahada.Metronic.Contracts.Assets;

public interface IKeenAssetStyles : IKeenAssets
{
    IEnumerable<string> Styles { get; }
}