using Ahada.Metronic.Contracts.Elements.Abstracts;
using Ahada.Metronic.Models.Elements.Abstracts.Generics;

namespace Ahada.Metronic.Models.Elements.Abstracts;

internal class KeenHtmlElementAttributeBuilder : KeenHtmlElementAttributeBuilder<IKeenHtmlElement, KeenHtmlElementAttributeBuilder>, IKeenHtmlElementAttributeBuilder, IKeenHtmlElement
{
    public IKeenHtmlElementAttributeBuilder MargeCssClasses(params string[] classes)
    {
        MergeClasses(classes);
        
        return this;
    }
}