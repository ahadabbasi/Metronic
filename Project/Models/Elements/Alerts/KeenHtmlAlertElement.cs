using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Ahada.Metronic.Contracts.Abstracts;
using Ahada.Metronic.Contracts.Elements.Abstracts;
using Ahada.Metronic.Contracts.Elements.Alerts;
using Ahada.Metronic.Models.Elements.Abstracts.Generics;
using Ahada.Metronic.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;

namespace Ahada.Metronic.Models.Elements.Alerts;

internal class KeenHtmlAlertElement : KeenDisposableHtmlElement<IKeenHtmlAlertElement, KeenHtmlAlertElement,
        IKeenHtmlAlertBodyElement, KeenHtmlAlertBodyElement>,
    IKeenHtmlAlertElement, IKeenHtmlDisposableHtmlElement
{
    public KeenHtmlAlertElement(IHtmlHelper html) : base(html)
    {
        Tag = new TagBuilder("div");
        Type = KeenType.Custom;
        Title = string.Empty;
        Message = string.Empty;
    }

    public override TagBuilder Tag { get; }

    protected string Title { get; set; }

    protected string Message { get; set; }

    protected KeenType Type { get; set; }

    protected TagBuilder? DisposableButton { get; set; }

    protected IKeenHtmlAlertBodyInnerElementBuilder? BodyInner { get; set; }

    protected KeenBorder? Border { get; set; }

    public override Task Build()
    {
        IList<string> classes = new List<string>()
        {
            "alert",
            "d-flex",
            "flex-column",
            "flex-sm-row",
            "p-5"
        };

        if (Type is not KeenType.Custom)
            classes.Add($"alert-{Type.ToString().ToLower()}");

        if (DisposableButton is not null)
            classes.Add("alert-dismissible");

        if (Border is not null)
        {
            classes.Add("border");

            if (Type is not KeenType.Custom)
                classes.Add($"border-{Type.ToString().ToLower()}");

            string? borderName = Border.ToString();

            if (string.IsNullOrEmpty(borderName) is false)
            {
                if (borderName.ToLower().StartsWith(KeenBorder.Thick.ToString().ToLower()))
                    classes.Add("border-3");

                if (borderName.ToLower().EndsWith(KeenBorder.Dashed.ToString().ToLower()))
                    classes.Add("border-dashed");
            }
        }

        MergeClasses(classes.ToArray());

        if (BodyInner is null)
        {
            BodyInner = CreateInstance();

            if (string.IsNullOrEmpty(Title) is false)
            {
                BodyInner = BodyInner.PutTitleOnIt(
                    Title
                );
            }

            if (string.IsNullOrEmpty(Message) is false)
            {
                BodyInner = BodyInner.MessageIs(
                    Message
                );
            }
        }

        _ = Tag.InnerHtml.AppendHtml(BodyInner);

        Tag.MergeAttributes(Attributes, true);

        return Task.CompletedTask;
    }

    public async void WriteTo(TextWriter writer, HtmlEncoder encoder)
    {
        bool disposableButtonAppended = false;

        if (BodyInner is not null && DisposableButton is not null)
        {
            _ = Tag.InnerHtml.AppendHtml(DisposableButton);
            disposableButtonAppended = true;
        }

        await Build();

        if (DisposableButton is not null && disposableButtonAppended is false)
        {
            DisposableButton.AddCssClass("position-sm-relative m-sm-0 ms-sm-auto");
            _ = Tag.InnerHtml.AppendHtml(DisposableButton);
        }

        Tag.WriteTo(writer, encoder);
    }

    public IKeenHtmlAlertElement Styled(KeenType type)
    {
        Type = type;

        return this;
    }

    public IKeenHtmlAlertElement BorderIs(KeenBorder border)
    {
        Border = border;

        return this;
    }

    public IKeenHtmlAlertElement PutTitleOnIt(string title)
    {
        Title = title;

        return this;
    }

    public IKeenHtmlAlertElement MessageIs(string message)
    {
        Message = message;

        return this;
    }

    public IKeenHtmlAlertElement MakeDisposable(bool disposable = true)
    {
        DisposableButton = disposable
            ? new TagBuilder("button")
            {
                Attributes =
                {
                    {
                        ClassAttributeName,
                        "position-absolute m-2 top-0 end-0 btn btn-icon"
                    },
                    {
                        "data-bs-dismiss",
                        "alert"
                    }
                }
            }
            : null;

        if (DisposableButton is not null)
        {
            TagBuilder icon = new TagBuilder("i")
            {
                Attributes =
                {
                    {
                        ClassAttributeName,
                        "ki-duotone ki-cross fs-1"
                    }
                }
            };

            for (int index = 1; index <= 2; index++)
            {
                icon.InnerHtml.AppendHtml(
                    new TagBuilder("span")
                    {
                        Attributes =
                        {
                            {
                                ClassAttributeName,
                                $"path{index}"
                            }
                        }
                    }
                );
            }

            _ = DisposableButton.InnerHtml.AppendHtml(icon);
        }

        return this;
    }

    public IKeenHtmlAlertElement Body(Func<IKeenHtmlAlertBodyInnerElement, IKeenHtmlAlertBodyInnerElement> body)
    {
        KeenHtmlAlertBodyInnerElement element = (KeenHtmlAlertBodyInnerElement)body(
            CreateInstance()
        );

        BodyInner = element;

        return this;
    }

    public override async Task Initial()
    {
        await Build();
        
        await using StringWriter writer = new StringWriter();
        Tag.RenderStartTag().WriteTo(writer, HtmlEncoder.Default);
        if (DisposableButton is not null) 
            DisposableButton.WriteTo(writer, HtmlEncoder.Default);
        await Html.ViewContext.Writer.WriteAsync(writer.ToString());

        await Disposal.Initial();
    }

    private KeenHtmlAlertBodyInnerElement CreateInstance()
    {
        return new KeenHtmlAlertBodyInnerElement(
            Html.ViewContext.HttpContext.RequestServices.GetService<IKeenPartialRenderer>() ?? throw new Exception()
        );
    }
}