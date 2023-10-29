using Microsoft.AspNetCore.Html;

namespace Ahada.Metronic.Contracts.Elements.Cards;

public interface IKeenHtmlCardBodyInnerElement : IKeenHtmlCardBodyElement, IHtmlContent
{
    IKeenHtmlCardBodyInnerElement RenderAsBody();
}