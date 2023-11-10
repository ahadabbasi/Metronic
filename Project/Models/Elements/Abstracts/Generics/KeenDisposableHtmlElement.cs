using System;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Ahada.Metronic.Contracts.Elements.Abstracts;
using Ahada.Metronic.Contracts.Elements.Abstracts.Generics;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahada.Metronic.Models.Elements.Abstracts.Generics;

internal abstract class KeenDisposableHtmlElement<TSelf, TBase, TDisposal, TBaseDisposal> :
    KeenHtmlElement<TSelf, TBase>,
    IKeenDisposableHtmlElement<TSelf, TDisposal>, IKeenHtmlDisposableHtmlElement
    where TSelf : IKeenHtmlElement<TSelf>
    where TDisposal : IKeenHtmlBodyElement<TDisposal>
    where TBase : KeenHtmlElement<TSelf, TBase>, TSelf
    where TBaseDisposal : KeenHtmlBodyElement<TDisposal, TBaseDisposal>, TDisposal, IKeenHtmlDisposableHtmlElement
{
    protected TBaseDisposal Disposal { get; }

    public IHtmlHelper Html { get; }

    public abstract TagBuilder Tag { get; }

    public KeenDisposableHtmlElement(IHtmlHelper html)
    {
        Html = html;

        System.Reflection.ConstructorInfo? constructor = typeof(TBaseDisposal)
            .GetConstructors()
            .Where(constructor => constructor.GetParameters().Length is 1)
            .FirstOrDefault(constructor =>
                constructor.GetParameters().Any(parameter => parameter.ParameterType == typeof(IHtmlHelper))
            );

        if (constructor is null)
            throw new Exception();

        Disposal = (TBaseDisposal)constructor.Invoke(new object[] { html });
    }

    public async Task<IDisposable> Body(Action<TDisposal>? action = null)
    {
        if (action is not null)
        {
            action.Invoke(Disposal);
        }

        await Initial();

        return new KeenHtmlElementBody(Terminate);
    }
    
    public abstract Task Build();

    public virtual async Task Initial()
    {
        //Tag.MergeAttributes(Attributes);

        await Build();
        
        await using StringWriter writer = new StringWriter();
        Tag.RenderStartTag().WriteTo(writer, HtmlEncoder.Default);
        await Html.ViewContext.Writer.WriteAsync(writer.ToString());

        await Disposal.Initial();
    }

    public virtual async Task Terminate()
    {
        await Disposal.Terminate();

        await using StringWriter writer = new StringWriter();
        Tag.RenderEndTag().WriteTo(writer, HtmlEncoder.Default);
        await Html.ViewContext.Writer.WriteAsync(writer.ToString());
    }
}