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

        if (DisposableButton is not null)
        {
            _ = Tag.InnerHtml.AppendHtml(DisposableButton);
        }

        return Task.CompletedTask;
    }

    public async void WriteTo(TextWriter writer, HtmlEncoder encoder)
    {
        await Build();

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
                        "position-absolute position-sm-relative m-2 m-sm-0 top-0 end-0 btn btn-icon ms-sm-auto"
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
                        "ki-duotone ki-cross fs-1 text-light"
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

    private KeenHtmlAlertBodyInnerElement CreateInstance()
    {
        return new KeenHtmlAlertBodyInnerElement(
            Html.ViewContext.HttpContext.RequestServices.GetService<IKeenPartialRenderer>() ?? throw new Exception()
        );
    }
}