using Ahada.Metronic.Contracts.Elements.Alerts;
using Ahada.Metronic.Models.Elements.Alerts;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahada.Metronic.Extensions.HtmlHelper.Elements;

public static class CreateKeenAlertExtension
{
    public static IKeenHtmlAlertElement CreateKeenAlert(this IHtmlHelper html)
        => new KeenHtmlAlertElement(html);
}