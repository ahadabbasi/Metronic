using System.Collections.Generic;
using Ahada.Metronic.Contracts.Abstracts;

namespace Ahada.Metronic.Contracts.Assets;

public interface IKeenAssetFonts : IKeenAssets
{
    IEnumerable<string> Fonts { get; }
}