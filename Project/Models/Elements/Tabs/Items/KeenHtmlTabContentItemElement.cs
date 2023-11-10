using System;
using Ahada.Metronic.Contracts.Abstracts;
using Ahada.Metronic.Contracts.Elements.Abstracts.BuilderResults;
using Ahada.Metronic.Contracts.Elements.Tabs.Items;

namespace Ahada.Metronic.Models.Elements.Tabs.Items;

internal class KeenHtmlTabContentItemElement :
    KeenHtmlTabItemElement<IKeenHtmlTabContentItemElement, KeenHtmlTabContentItemElement>,
    IKeenHtmlTabContentItemElement
{
    public KeenHtmlTabContentItemElement(
        IKeenPartialRenderer partialRenderer,
        IKeenHtmlHelper htmlHelper,
        Action<bool> notified
    ) : base(partialRenderer, htmlHelper, notified)
    {
    }

    public override KeenHtmlTwoNullableElementBuildResult Build()
    {
        if (Inner is null)
            throw new Exception();


        return new KeenHtmlTwoNullableElementBuildResult(
            null,
            Inner.WhatIsReference(Reference).IsActivate(Activate).Build().Item1
        );
    }
}