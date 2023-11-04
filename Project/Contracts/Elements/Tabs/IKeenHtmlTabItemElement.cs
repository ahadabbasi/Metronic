using System;
using Ahada.Metronic.Contracts.Elements.Abstracts;

namespace Ahada.Metronic.Contracts.Elements.Tabs;

public interface IKeenHtmlTabItemElement<TItem> : IKeenHtmlElement<IKeenHtmlTabItemElement<TItem>>
    where TItem : IKeenHtmlTabItemElement<TItem>
{
    TItem Activated(bool active = true);

    TItem ReferencesTo(string reference);

    TItem Body(Func<IKeenHtmlTabBodyInnerElement, IKeenHtmlTabBodyInnerElement> inner);
}