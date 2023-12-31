﻿using System.Threading.Tasks;
using Ahada.Metronic.Contracts.Elements.Abstracts;
using Ahada.Metronic.Contracts.Elements.Cards;
using Ahada.Metronic.Models.Elements.Abstracts.Generics;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahada.Metronic.Models.Elements.Cards;

internal class KeenHtmlCardBodyElement : KeenHtmlBodyElement<IKeenHtmlCardBodyElement, KeenHtmlCardBodyElement>, 
    IKeenHtmlCardBodyElement, IKeenHtmlDisposableHtmlElement
{
    public KeenHtmlCardBodyElement(IHtmlHelper html) : base(html)
    {
        Tag = new TagBuilder("div");
    }

    public override TagBuilder Tag { get; }

    public override Task Build()
    {
        MergeClasses("card-body");
        
        Tag.MergeAttributes(Attributes);
        
        return Task.CompletedTask;
    }
}