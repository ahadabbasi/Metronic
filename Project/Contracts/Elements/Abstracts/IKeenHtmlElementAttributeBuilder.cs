using Ahada.Metronic.Contracts.Elements.Abstracts.Generics;

namespace Ahada.Metronic.Contracts.Elements.Abstracts;

public interface IKeenHtmlElementAttributeBuilder : 
    IKeenHtmlElementAttributeBuilder<IKeenHtmlElement>
{
    IKeenHtmlElementAttributeBuilder MargeCssClasses(params string[] classes);
}