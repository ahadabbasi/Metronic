using System;
using System.Threading.Tasks;

namespace Ahada.Metronic.Contracts.Elements.Abstracts.Generics;

public interface IKeenDisposableHtmlElement<TSelf, TDisposal> : IKeenHtmlElement<TSelf>
    where TSelf : IKeenHtmlElement<TSelf>
    where TDisposal : IKeenHtmlBodyElement<TDisposal>
{
    Task<IDisposable> Body(Action<TDisposal>? action = null);
}