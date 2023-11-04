using Ahada.Metronic.Contracts.Elements.Cards;
using Ahada.Metronic.Models.Elements.Cards;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahada.Metronic.Extensions.HtmlHelper.Elements;

public static class CreateKeenCardExtension
{
    public static IKeenHtmlCardElement CreateKeenCard(this IHtmlHelper html)
        => new KeenHtmlCardElement(html);
}