namespace Ahada.Metronic.Contracts.Elements.Abstracts.Generics;

public interface IKeenHtmlElement<TSelf> where TSelf : IKeenHtmlElement<TSelf>
{
    TSelf Id(string id);
    
    TSelf Classes(params string[] classes);
    
    IKeenHtmlElementAttribute<TSelf> Attribute { get; }
}