using System.Collections.Generic;
using Ahada.Metronic.Contracts.Abstracts;

namespace Ahada.Metronic.Contracts.Assets;

public interface IKeenAssetScripts : IKeenAssets
{
    IEnumerable<string> Scripts { get; }
}