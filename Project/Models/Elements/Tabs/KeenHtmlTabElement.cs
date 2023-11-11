using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Encodings.Web;
using Ahada.Metronic.Contracts.Abstracts;
using Ahada.Metronic.Contracts.Elements.Abstracts;
using Ahada.Metronic.Contracts.Elements.Abstracts.Generics;
using Ahada.Metronic.Contracts.Elements.Tabs;
using Ahada.Metronic.Models.Elements.Abstracts.BuilderResults;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahada.Metronic.Models.Elements.Tabs;

internal class KeenHtmlTabElement<TSelfItem, TBaseItem> : IKeenHtmlTabElement<TSelfItem>
    where TSelfItem : IKeenHtmlTabItemElement<TSelfItem>
    where TBaseItem : KeenHtmlTabItemElement<TSelfItem, TBaseItem>, IKeenHtmlElementBuilder<KeenHtmlTwoNullableElementBuildResult>, TSelfItem
{
    public IList<TBaseItem> Items { get; }

    private IKeenPartialRenderer PartialRenderer { get; }

    private IKeenHtmlHelper HtmlHelper { get; }
    
    private IKeenHtmlTabElementAttributeBuilder NavigationAttribute { get; set; }
    
    private IKeenHtmlTabElementAttributeBuilder ContentAttribute { get; set; }
    
    private IDictionary<Type, ConstructorInfo?> Item { get; }

    private bool Activate { get; set; }

    public KeenHtmlTabElement(
        IKeenPartialRenderer partialRenderer,
        IKeenHtmlHelper htmlHelper
    )
    {
        Item = new Dictionary<Type, ConstructorInfo?>();
        
        NavigationAttribute = new KeenHtmlTabElementAttributeBuilder();

        ContentAttribute = new KeenHtmlTabElementAttributeBuilder();
        
        HtmlHelper = htmlHelper;

        PartialRenderer = partialRenderer;

        Items = new List<TBaseItem>();

        Activate = false;
    }

    public IKeenHtmlTabElement<TSelfItem> NavigationAttributes(Action<IKeenHtmlElement> attribute)
    {
        NavigationAttribute = new KeenHtmlTabElementAttributeBuilder();
        
        attribute.Invoke((((IKeenHtmlElement<IKeenHtmlElement>)NavigationAttribute) ?? throw new Exception()) as IKeenHtmlElement ?? throw new Exception());
        
        return this;
    }

    public IKeenHtmlTabElement<TSelfItem> ContentAttributes(Action<IKeenHtmlElement> attribute)
    {
        ContentAttribute = new KeenHtmlTabElementAttributeBuilder();
        
        attribute.Invoke((((IKeenHtmlElement<IKeenHtmlElement>)NavigationAttribute) ?? throw new Exception()) as IKeenHtmlElement ?? throw new Exception());
        
        return this;
    }

    public IKeenHtmlTabElement<TSelfItem> AddItem(Func<TSelfItem, TSelfItem> item)
    {
        ConstructorInfo? constructor;

        if (Item.ContainsKey(typeof(TSelfItem)) is false)
        {
            constructor = typeof(TBaseItem).GetConstructors()
                .Where(info => info.GetParameters().Length == 3)
                .Where(info => info.GetParameters()
                    .Any(parameter => parameter.ParameterType == typeof(IKeenPartialRenderer))
                )
                .Where(info => info.GetParameters()
                    .Any(parameter => parameter.ParameterType == typeof(IKeenHtmlHelper))
                )
                .FirstOrDefault(info => info.GetParameters()
                    .Any(parameter => parameter.ParameterType == typeof(Action<bool>))
                );
            
            Item.Add(typeof(TSelfItem), constructor);
        }

        constructor = Item[typeof(TSelfItem)];

        if (constructor is null)
            throw new Exception();

        TBaseItem? instance = (TBaseItem?)constructor.Invoke(
            new object?[]
            {
                PartialRenderer,
                HtmlHelper,
                ItemBeActivated
            }
        );
        
        if (instance is null)
            throw new Exception();

        instance = (TBaseItem)item((TSelfItem)instance);

        Items.Add(instance);

        return this;
    }

    private void ItemBeActivated(bool active)
    {
        if (active && Activate)
            throw new Exception();

        Activate = active;
    }

    public async void WriteTo(TextWriter writer, HtmlEncoder encoder)
    {
        TagBuilder navigation = new TagBuilder("ul");
        
        NavigationAttribute.MargeCssClasses("nav", "nav-tabs", "nav-line-tabs", "mb-5", "fs-6");
        
        NavigationAttribute.Attribute.Add("role", "tablist");
        
        navigation.MergeAttributes(await NavigationAttribute.GetAs(), true);
        
        TagBuilder content = new TagBuilder("div");

        ContentAttribute.MargeCssClasses("tab-content");
        
        content.MergeAttributes(await ContentAttribute.GetAs(), true);
        
        foreach (TBaseItem item in Items)
        {
            (TagBuilder? link, TagBuilder? body) = item.Build();

            if (link is not null)
                navigation.InnerHtml.AppendHtml(link);

            if (body is not null)
                content.InnerHtml.AppendHtml(body);
        }
        
        if (navigation.HasInnerHtml)
            navigation.WriteTo(writer, encoder);

        if (content.HasInnerHtml)
            content.WriteTo(writer, encoder);
    }
}