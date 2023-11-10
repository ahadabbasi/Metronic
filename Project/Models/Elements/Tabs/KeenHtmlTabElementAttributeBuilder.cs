using Ahada.Metronic.Contracts.Elements.Abstracts;
using Ahada.Metronic.Contracts.Elements.Tabs;
using Ahada.Metronic.Models.Elements.Abstracts.Generics;

namespace Ahada.Metronic.Models.Elements.Tabs;

internal class KeenHtmlTabElementAttributeBuilder : KeenHtmlElementAttributeBuilder<IKeenHtmlElement, KeenHtmlTabElementAttributeBuilder>, 
    IKeenHtmlElement,
    IKeenHtmlTabElementAttributeBuilder
{
    public IKeenHtmlTabElementAttributeBuilder MargeCssClasses(params string[] classes)
    {
        MergeClasses(classes);
        
        return this;
    }
}