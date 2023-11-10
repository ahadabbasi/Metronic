using System;
using Ahada.Metronic.Contracts.Elements.Abstracts;
using Microsoft.AspNetCore.Html;

namespace Ahada.Metronic.Contracts.Elements.Tabs;

public interface IKeenHtmlTabElement<TItem> :
    IHtmlContent
    where TItem : IKeenHtmlTabItemElement<TItem>
{
    IKeenHtmlTabElement<TItem> NavigationAttributes(Action<IKeenHtmlElement> attribute);
    IKeenHtmlTabElement<TItem> ContentAttributes(Action<IKeenHtmlElement> attribute);
    IKeenHtmlTabElement<TItem> AddItem(Func<TItem, TItem> item);
}