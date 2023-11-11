using System;
using Ahada.Metronic.Contracts.Abstracts;
using Ahada.Metronic.Contracts.Elements.Tabs;
using Ahada.Metronic.Contracts.Elements.Tabs.Items;
using Ahada.Metronic.Models.Elements.Tabs;
using Ahada.Metronic.Models.Elements.Tabs.Items;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;

namespace Ahada.Metronic.Extensions.HtmlHelper.Elements;

public static class CreateKeenTabExtension
{
    public static IKeenHtmlTabElement<IKeenHtmlTabHeaderItemElement> CreateKeenTab(this IHtmlHelper html)
    {
        return new KeenHtmlTabElement<IKeenHtmlTabHeaderItemElement, KeenHtmlTabHeaderItemElement>(
            html.ViewContext.HttpContext.RequestServices.GetService<IKeenPartialRenderer>() ?? throw new Exception(),
            html.ViewContext.HttpContext.RequestServices.GetService<IKeenHtmlHelper>() ?? throw new Exception()
        );
    }
    
    public static IKeenHtmlTabElement<IKeenHtmlTabContentItemElement> RenderKeenTabContent(this IHtmlHelper html)
    {
        return new KeenHtmlTabElement<IKeenHtmlTabContentItemElement, KeenHtmlTabContentItemElement>(
            html.ViewContext.HttpContext.RequestServices.GetService<IKeenPartialRenderer>() ?? throw new Exception(),
            html.ViewContext.HttpContext.RequestServices.GetService<IKeenHtmlHelper>() ?? throw new Exception()
        );
    }
}