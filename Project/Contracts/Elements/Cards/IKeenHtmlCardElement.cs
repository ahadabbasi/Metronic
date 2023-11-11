using System;
using Ahada.Metronic.Contracts.Elements.Abstracts;
using Ahada.Metronic.Contracts.Elements.Abstracts.Generics;
using Microsoft.AspNetCore.Html;

namespace Ahada.Metronic.Contracts.Elements.Cards;

public interface IKeenHtmlCardElement : IKeenDisposableHtmlElement<IKeenHtmlCardElement, IKeenHtmlCardBodyElement>, IHtmlContent
{
    IKeenHtmlCardElement Body(Func<IKeenHtmlCardBodyInnerElement, IKeenHtmlCardBodyInnerElement> body);

    IKeenHtmlCardElement HeaderAttributes(Action<IKeenHtmlElement> attribute);

    IKeenHtmlCardElement WhatIsTitle(string title);

    IKeenHtmlCardElement PutActionOnIt(string action);
    
    IKeenHtmlCardElement PutActionOnIt(IHtmlContent content);

    IKeenHtmlCardElement IsCollapsible(bool collapsible = true);
}