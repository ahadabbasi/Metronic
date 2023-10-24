namespace Ahada.Metronic.Contracts.Assets;

public interface IKeenAssetFonts : IKeenAssets
{
    IEnumerable<string> Fonts { get; }
}