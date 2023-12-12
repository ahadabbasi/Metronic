using System.IO;
using System.Text.Encodings.Web;
using Ahada.Metronic.Contracts.Abstracts;
using Ahada.Metronic.Contracts.Elements.Alerts;
using Ahada.Metronic.Models.Elements.Abstracts.Generics;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahada.Metronic.Models.Elements.Alerts;

internal class KeenHtmlAlertBodyInnerElement: KeenHtmlBodyInnerElement<IKeenHtmlAlertBodyInnerElement, KeenHtmlAlertBodyInnerElement>, IKeenHtmlAlertBodyInnerElementBuilder
{
    private string? Message { get; set; }
    
    private string? Title { get; set; }
    
    private TagBuilder Tag { get; }
    
    public KeenHtmlAlertBodyInnerElement(IKeenPartialRenderer partialRenderer) : base(partialRenderer)
    {
        Tag = new TagBuilder("div")
        {
            Attributes =
            {
                {
                    ClassAttributeName, 
                    "d-flex flex-column pe-0 pe-sm-10"
                }
            }
        };
    }

    public void WriteTo(TextWriter writer, HtmlEncoder encoder)
    {
        if (Message is not null || Title is not null)
        {
            if (string.IsNullOrEmpty(Title) is false)
            {
                TagBuilder header = new TagBuilder("h4")
                {
                    Attributes = { { ClassAttributeName, "mb-1" } }
                };

                header.InnerHtml.AppendHtml(
                    new HtmlString(
                        Title
                    )
                );

                _ = Tag.InnerHtml.AppendHtml(header);
            }

            if (string.IsNullOrEmpty(Message) is false)
            {
                TagBuilder content = new TagBuilder("span");

                content.InnerHtml.AppendHtml(
                    new HtmlString(
                        Message
                    )
                );

                _ = Tag.InnerHtml.AppendHtml(content);
            }
            
            Tag.WriteTo(writer, encoder);
        }
        else
        {
            Body.WriteTo(writer, encoder);
        }
    }

    public IKeenHtmlAlertBodyInnerElementBuilder PutTitleOnIt(string title)
    {
        Title = title;

        return this;
    }

    public IKeenHtmlAlertBodyInnerElementBuilder MessageIs(string message)
    {
        Message = message;

        return this;
    }
}