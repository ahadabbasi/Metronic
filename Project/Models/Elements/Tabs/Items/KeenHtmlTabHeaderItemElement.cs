using System;
using Ahada.Metronic.Contracts.Abstracts;
using Ahada.Metronic.Contracts.Elements.Tabs.Items;
using Ahada.Metronic.Models.Elements.Abstracts.BuilderResults;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Ahada.Metronic.Models.Elements.Tabs.Items;

internal class KeenHtmlTabHeaderItemElement :
    KeenHtmlTabItemElement<IKeenHtmlTabHeaderItemElement, KeenHtmlTabHeaderItemElement>, IKeenHtmlTabHeaderItemElement
{
    public KeenHtmlTabHeaderItemElement(
        IKeenPartialRenderer partialRenderer,
        IKeenHtmlHelper htmlHelper,
        Action<bool> notified
    ) : base(partialRenderer, htmlHelper, notified)
    {
        Title = string.Empty;
    }

    protected string Title { get; set; }

    public override KeenHtmlTwoNullableElementBuildResult Build()
    {
        TagBuilder title = new TagBuilder("li");

        MergeClasses("nav-item");

        Attribute.Add("role", "presentation");

        title.MergeAttributes(Attributes);

        bool referenceIsUri = Uri.IsWellFormedUriString(Reference, UriKind.Absolute);

        AttributeDictionary anchorAttributes = new AttributeDictionary()
        {
            { "class", $"nav-link {(Activate ? "active" : "")}" },
            { "aria-selected", Activate.ToString().ToLower() },
            {
                "href",
                referenceIsUri
                    ? Reference
                    : $"#{Reference}"
            }
        };

        if (referenceIsUri is false) 
            anchorAttributes.Add("data-bs-toggle", "tab");

        TagBuilder anchor = new TagBuilder("a");
        
        anchor.MergeAttributes(anchorAttributes, true);

        anchor.InnerHtml.AppendHtml(
            new HtmlString(Title)
        );

        title.InnerHtml.AppendHtml(anchor);

        return new KeenHtmlTwoNullableElementBuildResult(
            title,
            Inner?.WhatIsReference(Reference).IsActivate(Activate).Build().Item1
        );
    }

    public IKeenHtmlTabHeaderItemElement PutTitleAs(string title)
    {
        Title = title;
        return this;
    }
}