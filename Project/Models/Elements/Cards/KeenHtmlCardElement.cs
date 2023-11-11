using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Ahada.Metronic.Contracts.Abstracts;
using Ahada.Metronic.Contracts.Elements.Abstracts;
using Ahada.Metronic.Contracts.Elements.Abstracts.Generics;
using Ahada.Metronic.Contracts.Elements.Cards;
using Ahada.Metronic.Models.Elements.Abstracts;
using Ahada.Metronic.Models.Elements.Abstracts.Generics;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;

namespace Ahada.Metronic.Models.Elements.Cards;

internal class KeenHtmlCardElement : KeenDisposableHtmlElement<IKeenHtmlCardElement, KeenHtmlCardElement,
        IKeenHtmlCardBodyElement, KeenHtmlCardBodyElement>,
    IKeenHtmlCardElement, IKeenHtmlDisposableHtmlElement
{
    public override TagBuilder Tag { get; }

    private TagBuilder? Collapse { get; set; }

    private TagBuilder? CardHeader { get; set; }

    private string Title { get; set; }

    private IHtmlContent? Action { get; set; }

    private IKeenHtmlHelper KeenHtml { get; }

    private string Collapsible { get; set; }

    private IKeenHtmlElementAttributeBuilder HeaderAttribute { get; set; }

    private IKeenHtmlElementAttributeBuilder BodyAttribute { get; set; }

    protected IKeenHtmlCardBodyInnerElement? InnerElement { get; set; }

    public KeenHtmlCardElement(IHtmlHelper html) : base(html)
    {
        HeaderAttribute = new KeenHtmlElementAttributeBuilder();

        BodyAttribute = new KeenHtmlElementAttributeBuilder();

        KeenHtml = Html.ViewContext.HttpContext.RequestServices.GetService<IKeenHtmlHelper>()
                   ?? throw new Exception();

        Title = string.Empty;

        Collapsible = string.Empty;

        Action = new HtmlString(string.Empty);

        Tag = new TagBuilder("div");
    }

    public async void WriteTo(TextWriter writer, HtmlEncoder encoder)
    {
        await Build();

        if (CardHeader is not null)
            _ = Tag.InnerHtml.AppendHtml(CardHeader);

        if (Collapse is not null)
            _ = Tag.InnerHtml.AppendHtml(Collapse);

        if (InnerElement is not null)
        {
            _ = Collapse is not null
                ? Collapse.InnerHtml.AppendHtml(InnerElement)
                : Tag.InnerHtml.AppendHtml(InnerElement);
        }

        Tag.WriteTo(writer, encoder);
    }

    public IKeenHtmlCardElement Body(Func<IKeenHtmlCardBodyInnerElement, IKeenHtmlCardBodyInnerElement> body)
    {
        InnerElement = body(
            new KeenHtmlCardBodyInnerElement(
                Html.ViewContext.HttpContext.RequestServices.GetService<IKeenPartialRenderer>() ?? throw new Exception()
            )
        );

        return this;
    }

    public IKeenHtmlCardElement HeaderAttributes(Action<IKeenHtmlElement> attribute)
    {
        HeaderAttribute = new KeenHtmlElementAttributeBuilder();

        attribute.Invoke(
            (
                HeaderAttribute as IKeenHtmlElement<IKeenHtmlElement> ?? throw new Exception()
            ) as IKeenHtmlElement ?? throw new Exception()
        );

        return this;
    }

    public IKeenHtmlCardElement BodyAttributes(Action<IKeenHtmlElement> attribute)
    {
        BodyAttribute = new KeenHtmlElementAttributeBuilder();

        attribute.Invoke(
            (
                BodyAttribute as IKeenHtmlElement<IKeenHtmlElement> ?? throw new Exception()
            ) as IKeenHtmlElement ?? throw new Exception()
        );

        return this;
    }

    public IKeenHtmlCardElement WhatIsTitle(string title)
    {
        Title = title;

        return this;
    }

    public IKeenHtmlCardElement PutActionOnIt(string action)
    {
        return PutActionOnIt(new HtmlString(action));
    }

    public IKeenHtmlCardElement PutActionOnIt(IHtmlContent content)
    {
        Action = content;

        return this;
    }

    public IKeenHtmlCardElement IsCollapsible(bool collapsible = true)
    {
        Collapsible = collapsible
            ? $"keen_card_{KeenHtml.Id.Generate().ToLower()}_collapsible".ToLower()
            : string.Empty;


        if (collapsible)
        {
            Collapse = new TagBuilder("div")
            {
                Attributes =
                {
                    { "class", "collapse" },
                    { "id", Collapsible }
                }
            };

            _ = PutActionOnIt(new TagBuilder("i")
            {
                Attributes =
                {
                    { "class", "ki-duotone ki-down fs-1" }
                }
            });
        }
        else
        {
            Collapse = null;
            _ = PutActionOnIt(string.Empty);
        }

        return this;
    }

    public override async Task Build()
    {
        MergeClasses("card");

        Tag.MergeAttributes(Attributes);

        if (!string.IsNullOrEmpty(Title))
        {
            CardHeader = await CreateCardHeader();

            TagBuilder headerTitle = new TagBuilder("h3")
            {
                Attributes =
                {
                    { "class", "card-title" }
                }
            };

            headerTitle.InnerHtml.AppendHtml(new HtmlString(Title));

            _ = CardHeader.InnerHtml.AppendHtml(headerTitle);
        }

        if (Action is not null)
        {
            CardHeader ??= await CreateCardHeader();

            TagBuilder headerToolbar = new TagBuilder("div")
            {
                Attributes =
                {
                    { "class", "card-toolbar" }
                }
            };

            if (!string.IsNullOrEmpty(Collapsible))
            {
                CardHeader.AddCssClass("collapsible cursor-pointer rotate");
                CardHeader.MergeAttributes(
                    new Dictionary<string, string>(new[]
                    {
                        new KeyValuePair<string, string>("data-bs-toggle", "collapse"),
                        new KeyValuePair<string, string>("data-bs-target", $"#{Collapsible}")
                    }));
                headerToolbar.AddCssClass("rotate-180");
            }

            headerToolbar.InnerHtml.AppendHtml(Action);

            _ = CardHeader.InnerHtml.AppendHtml(headerToolbar);
        }
    }

    private async Task<TagBuilder> CreateCardHeader()
    {
        TagBuilder result = new TagBuilder("div");

        result.MergeAttributes(
            await HeaderAttribute.MargeCssClasses("card-header").GetAs(),
            true
        );

        return result;
    }

    public override async Task Initial()
    {
        await Build();

        await using StringWriter writer = new StringWriter();

        Tag.RenderStartTag().WriteTo(writer, HtmlEncoder.Default);

        if (CardHeader is not null)
            CardHeader.WriteTo(writer, HtmlEncoder.Default);

        if (string.IsNullOrEmpty(Collapsible) is false && Collapse is not null)
            Collapse.RenderStartTag().WriteTo(writer, HtmlEncoder.Default);

        await Html.ViewContext.Writer.WriteAsync(writer.ToString());

        await Disposal.Initial();
    }

    public override async Task Terminate()
    {
        await Disposal.Terminate();

        await using StringWriter writer = new StringWriter();

        if (string.IsNullOrEmpty(Collapsible) is false && Collapse is not null)
            Collapse.RenderEndTag().WriteTo(writer, HtmlEncoder.Default);

        Tag.RenderEndTag().WriteTo(writer, HtmlEncoder.Default);

        await Html.ViewContext.Writer.WriteAsync(writer.ToString());
    }
}