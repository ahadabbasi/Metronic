namespace Ahada.Metronic.Contracts.Elements.Abstracts;

public interface IKeenDisposableHtmlElement<TSelf, TDisposal> : IKeenHtmlElement<TSelf>
    where TSelf : IKeenHtmlElement<TSelf>
    where TDisposal : IKeenHtmlElement<TDisposal>, new()
{
    IKeenHtmlElementBody<TDisposal> Body(Func<TDisposal, TDisposal>? func = null);
}