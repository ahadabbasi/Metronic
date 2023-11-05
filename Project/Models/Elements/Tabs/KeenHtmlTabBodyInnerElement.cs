using System.Collections.Generic;
using System.Linq;
using Ahada.Metronic.Contracts.Abstracts;
using Ahada.Metronic.Contracts.Elements.Abstracts.BuilderResults;
using Ahada.Metronic.Contracts.Elements.Tabs;
using Ahada.Metronic.Models.Elements.Abstracts;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahada.Metronic.Models.Elements.Tabs;

internal class KeenHtmlTabBodyInnerElement :
    KeenHtmlBodyInnerElement<IKeenHtmlTabBodyInnerElement, KeenHtmlTabBodyInnerElement>,
    IKeenHtmlTabBodyInnerElement,
    IKeenHtmlTabBodyInnerBuilderElement
{
    public KeenHtmlTabBodyInnerElement(IKeenPartialRenderer partialRenderer) : base(partialRenderer)
    {
        Activate = false;
    }

    private bool Activate { get; set; }

    public IKeenHtmlTabBodyInnerBuilderElement WhatIsReference(string reference)
    {
        return (IKeenHtmlTabBodyInnerBuilderElement)Id(reference);
    }

    public IKeenHtmlTabBodyInnerBuilderElement IsActivate(bool activate)
    {
        Activate = activate;

        return this;
    }

    public KeenHtmlOneElementBuildResult Build()
    {
        TagBuilder result = new TagBuilder("div");

        IList<string> classes = new List<string>()
        {
            "tab-pane", "fade"
        };

        if (Activate)
        {
            classes.Add("show");
            classes.Add("active");
        }

        MergeClasses(classes.ToArray());

        Attribute.Add("role", "tabpanel");

        result.MergeAttributes(Attributes);

        result.InnerHtml.AppendHtml(Body);

        return new KeenHtmlOneElementBuildResult(result);
    }
}