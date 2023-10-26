namespace Ahada.Metronic.Contracts.Elements.Abstracts;

public interface IKeenHtmlElementAttribute<TSelf> where TSelf : IKeenHtmlElement<TSelf>
{
    TSelf Add(string name, string value);
    
    TSelf Remove(string name);
}