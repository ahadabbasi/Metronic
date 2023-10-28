namespace Ahada.Metronic.Contracts.Elements.Abstracts;

public interface IKeenHtmlInnerTextElement<TSelf> : IKeenHtmlElement<TSelf> where TSelf : IKeenHtmlElement<TSelf>
{
    TSelf InnerText(string text);
}