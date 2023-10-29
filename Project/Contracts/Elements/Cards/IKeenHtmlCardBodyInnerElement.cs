using Ahada.Metronic.Contracts.Elements.Abstracts;
using Microsoft.AspNetCore.Html;

namespace Ahada.Metronic.Contracts.Elements.Cards;

public interface IKeenHtmlCardBodyInnerElement : IKeenHtmlElement<IKeenHtmlCardBodyInnerElement>, IHtmlContent
{
    IKeenHtmlCardBodyInnerElement RenderAsBody();
}