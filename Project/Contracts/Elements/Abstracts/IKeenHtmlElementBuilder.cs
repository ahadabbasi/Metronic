namespace Ahada.Metronic.Contracts.Elements.Abstracts;

public interface IKeenHtmlElementBuilder<TResult>
    where TResult : IKeenHtmlElementBuildResult
{
    TResult Build();
}