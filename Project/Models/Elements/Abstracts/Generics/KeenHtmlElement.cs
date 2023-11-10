using System.Collections.Generic;
using Ahada.Metronic.Contracts.Elements.Abstracts.Generics;

namespace Ahada.Metronic.Models.Elements.Abstracts.Generics;

internal abstract class KeenHtmlElement<TSelf, TBase> : IKeenHtmlElement<TSelf>, IKeenHtmlElementAttribute<TSelf>
    where TSelf : IKeenHtmlElement<TSelf>
    where TBase : KeenHtmlElement<TSelf, TBase>, TSelf
{
    public IKeenHtmlElementAttribute<TSelf> Attribute => this;

    protected IDictionary<string, string> Attributes { get; }

    protected string ClassAttributeName
        => "class";

    private char ClassAttributeSeparator => ' ';

    public KeenHtmlElement()
    {
        Attributes = new Dictionary<string, string>();
    }

    public TSelf Id(string id)
        => Add(nameof(Id).ToLower(), id);

    public TSelf Classes(params string[] classes)
    {
        return Add(ClassAttributeName, string.Join(ClassAttributeSeparator, classes));
    }

    public TSelf Add(string name, string value)
    {
        if (!Attributes.ContainsKey(name))
        {
            Attributes.Add(name, string.Empty);
        }

        Attributes[name] = value;

        return (TBase)this;
    }

    public TSelf Remove(string name)
    {
        if (!Attributes.ContainsKey(name))
        {
            Attributes.Add(name, string.Empty);
        }

        Attributes.Remove(name);

        return (TBase)this;
    }

    protected virtual void MergeClasses(params string[] classes)
    {
        string @class = string.Join(ClassAttributeSeparator, classes);

        if (
            Attributes.TryGetValue(ClassAttributeName, out string? attribute) &&
            string.IsNullOrEmpty(attribute) is false
        )
        {
            @class = $"{@class} {attribute}";
        }

        _ = Add(ClassAttributeName, @class);
    }
}