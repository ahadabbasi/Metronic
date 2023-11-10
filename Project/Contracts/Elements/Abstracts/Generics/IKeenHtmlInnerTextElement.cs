namespace Ahada.Metronic.Contracts.Elements.Abstracts.Generics;

public interface IKeenHtmlInnerTextElement<TSelf> : IKeenHtmlElement<TSelf> where TSelf : IKeenHtmlElement<TSelf>
{
    TSelf InnerText(string text);
}