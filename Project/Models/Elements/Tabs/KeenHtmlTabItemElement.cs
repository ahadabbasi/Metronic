using System;
using Ahada.Metronic.Contracts.Abstracts;
using Ahada.Metronic.Contracts.Elements.Abstracts.Generics;
using Ahada.Metronic.Contracts.Elements.Tabs;
using Ahada.Metronic.Models.Elements.Abstracts.BuilderResults;
using Ahada.Metronic.Models.Elements.Abstracts.Generics;

namespace Ahada.Metronic.Models.Elements.Tabs;

internal abstract class KeenHtmlTabItemElement<TSelf, TBase> :
    KeenHtmlElement<IKeenHtmlTabItemElement<TSelf>, KeenHtmlTabItemElement<TSelf, TBase>>,
    IKeenHtmlTabItemElement<TSelf>,
    IKeenHtmlElementBuilder<KeenHtmlTwoNullableElementBuildResult>
    where TSelf : IKeenHtmlTabItemElement<TSelf>
    where TBase : KeenHtmlTabItemElement<TSelf, TBase>, TSelf
{
    protected string Reference { get; set; }

    protected bool Activate { get; set; }

    protected IKeenHtmlTabBodyInnerBuilderElement? Inner { get; set; }

    protected IKeenPartialRenderer PartialRenderer { get; }

    private Action<bool> Notified { get; }

    private IKeenHtmlHelper HtmlHelper { get; }

    public KeenHtmlTabItemElement(
        IKeenPartialRenderer partialRenderer,
        IKeenHtmlHelper htmlHelper,
        Action<bool> notified
    )
    {
        PartialRenderer = partialRenderer;

        HtmlHelper = htmlHelper;

        Notified = notified;

        Reference = $"keen_tab_pane_{HtmlHelper.Id.Generate()}";

        Activate = false;
    }


    public TSelf Activated(bool active = true)
    {
        Activate = active;

        Notified(active);

        return (TBase)this;
    }

    public TSelf ReferencesTo(string reference)
    {
        if (string.IsNullOrEmpty(reference) is false)
            Reference = reference;

        return (TBase)this;
    }

    public TSelf Body(Func<IKeenHtmlTabBodyInnerElement, IKeenHtmlTabBodyInnerElement> inner)
    {
        KeenHtmlTabBodyInnerElement? instance = new KeenHtmlTabBodyInnerElement(PartialRenderer);

        instance = inner(instance) as KeenHtmlTabBodyInnerElement;

        if (instance is not null)
            Inner = instance;

        return (TBase)this;
    }

    public abstract KeenHtmlTwoNullableElementBuildResult Build();
}