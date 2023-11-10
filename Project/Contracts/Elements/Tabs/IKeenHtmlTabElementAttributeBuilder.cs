using Ahada.Metronic.Contracts.Elements.Abstracts;
using Ahada.Metronic.Contracts.Elements.Abstracts.Generics;

namespace Ahada.Metronic.Contracts.Elements.Tabs;

public interface IKeenHtmlTabElementAttributeBuilder : IKeenHtmlElementAttributeBuilder<IKeenHtmlElement>
{
    IKeenHtmlTabElementAttributeBuilder MargeCssClasses(params string[] classes);
}