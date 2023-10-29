using System;
using Ahada.Metronic.Contracts.Elements.Abstracts;
using Microsoft.AspNetCore.Html;

namespace Ahada.Metronic.Contracts.Elements.Cards;

public interface IKeenHtmlCardElement : IKeenDisposableHtmlElement<IKeenHtmlCardElement, IKeenHtmlCardBodyElement>, IHtmlContent
{
    IKeenHtmlCardElement Body(Func<IKeenHtmlCardBodyInnerElement, IKeenHtmlCardBodyInnerElement> body);
}