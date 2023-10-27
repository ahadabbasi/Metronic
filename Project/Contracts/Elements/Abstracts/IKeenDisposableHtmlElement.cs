using System;

namespace Ahada.Metronic.Contracts.Elements.Abstracts;

public interface IKeenDisposableHtmlElement<TSelf, TDisposal> : IKeenHtmlElement<TSelf>
    where TSelf : IKeenHtmlElement<TSelf>
    where TDisposal : IKeenHtmlBodyElement
{
    IDisposable Body(Action<TDisposal>? action = null);
}