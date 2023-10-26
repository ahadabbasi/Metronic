namespace Ahada.Metronic.Contracts.Elements.Abstracts;

public interface IKeenHtmlElementBody<TDisposal> : IDisposable where TDisposal : IKeenHtmlElement<TDisposal>
{
    TDisposal Attribute { get; }
}