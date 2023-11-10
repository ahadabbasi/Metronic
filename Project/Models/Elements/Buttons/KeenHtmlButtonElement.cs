using System.IO;
using System.Text.Encodings.Web;
using Ahada.Metronic.Contracts.Elements.Buttons;
using Ahada.Metronic.Models.Elements.Abstracts.Generics;
using Ahada.Metronic.Models.Enums;
using Ahada.Metronic.Models.Enums.Elements;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahada.Metronic.Models.Elements.Buttons;

internal class KeenHtmlButtonElement : KeenHtmlInnerTextElement<IKeenHtmlButtonElement, KeenHtmlButtonElement>,
    IKeenHtmlButtonElement
{
    protected KeenType KeenType { get; set; }

    protected string Url { get; set; }

    protected string IndicatorText { get; set; }

    private string HrefAttributeName 
        => "href";

    private string TypeAttributeName 
        => "type";

    public KeenHtmlButtonElement()
    {
        Url = string.Empty;

        IndicatorText = string.Empty;
    }

    public void WriteTo(TextWriter writer, HtmlEncoder encoder)
    {
        TagBuilder buttonBuilder = new TagBuilder(string.IsNullOrEmpty(Url) ? "button" : "a");

        MergeClasses("btn", KeenType == KeenType.Custom ? string.Empty : $"btn-{KeenType.ToString().ToLower()}");

        buttonBuilder.MergeAttributes(Attributes);

        IHtmlContentBuilder inner = new HtmlContentBuilder().AppendHtml(InnerHtml);

        if (!string.IsNullOrEmpty(IndicatorText) && string.IsNullOrEmpty(Url))
        {
            TagBuilder spanTextIndicator = new TagBuilder("span")
            {
                Attributes =
                {
                    {
                        "class", "indicator-label"
                    }
                }
            };

            spanTextIndicator.InnerHtml.AppendHtml(InnerHtml);

            TagBuilder spanProgressIndicator = new TagBuilder("span")
            {
                Attributes =
                {
                    {
                        "class", "indicator-progress"
                    }
                }
            };

            spanProgressIndicator.InnerHtml.AppendHtml(new HtmlString(IndicatorText))
                .AppendHtml(new TagBuilder("span")
                    { Attributes = { { "class", "spinner-border spinner-border-sm align-middle ms-2" } } });

            inner.Clear()
                .AppendHtml(spanTextIndicator)
                .AppendHtml(spanProgressIndicator);
        }

        buttonBuilder.InnerHtml.AppendHtml(inner);

        buttonBuilder.WriteTo(writer, encoder);
    }

    public IKeenHtmlButtonElement Styled(KeenType type)
    {
        KeenType = type;

        return this;
    }

    public IKeenHtmlButtonElement Type(KeenButtonType type)
    {
        Attribute.Remove(HrefAttributeName);

        _ = LinkTo(string.Empty);
        
        if (type != KeenButtonType.None)
        {
            Attribute.Add(TypeAttributeName, type.ToString().ToLower());
        }
        
        return this;
    }

    public IKeenHtmlButtonElement LinkTo(string url)
    {
        Url = url;

        Attribute.Remove(TypeAttributeName);

        if (!string.IsNullOrEmpty(url))
            Attribute.Add(HrefAttributeName, url);

        return this;
    }

    public IKeenHtmlButtonElement IsIndicator(string indicatorText)
    {
        IndicatorText = indicatorText;

        return this;
    }
}