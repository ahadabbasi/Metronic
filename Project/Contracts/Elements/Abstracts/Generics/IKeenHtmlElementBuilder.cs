namespace Ahada.Metronic.Contracts.Elements.Abstracts.Generics;

public interface IKeenHtmlElementBuilder<TResult>
    where TResult : IKeenHtmlElementBuildResult
{
    TResult Build();
}