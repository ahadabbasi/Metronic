using System;
using System.Linq;
using System.Threading.Tasks;
using Ahada.Metronic.Contracts.Elements.Abstracts;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahada.Metronic.Models.Elements.Abstracts;

internal abstract class KeenDisposableHtmlElement<TSelf, TBase, TDisposal> : KeenHtmlElement<TSelf, TBase>,
    IKeenDisposableHtmlElement<TSelf, TDisposal>, IKeenHtmlDisposableHtmlElement
    where TSelf : IKeenHtmlElement<TSelf>
    where TDisposal : IKeenHtmlBodyElement, IKeenHtmlDisposableHtmlElement
    where TBase : KeenHtmlElement<TSelf, TBase>, TSelf
{
    protected TDisposal Disposal { get; }

    public IHtmlHelper Html { get; }

    public KeenDisposableHtmlElement(IHtmlHelper html)
    {
        Html = html;

        System.Reflection.ConstructorInfo? constructor = typeof(TDisposal)
            .GetConstructors()
            .Where(constructor => constructor.GetParameters().Length is 1)
            .FirstOrDefault(constructor =>
                constructor.GetParameters().Any(parameter => parameter.ParameterType == typeof(IHtmlHelper))
            );

        if (constructor is null)
            throw new Exception();
        
        Disposal = (TDisposal)constructor.Invoke(new object[] { html });
    }

    public IDisposable Body(Action<TDisposal>? action = null)
    {
        if (action is not null)
        {
            action.Invoke(Disposal);
        }

        return new KeenHtmlElementBody(Terminate);
    }


    public Task Initial()
    {
        Disposal.Initial();
        
        return Task.CompletedTask;
    }

    public Task Terminate()
    {
        Disposal.Terminate();
        
        return Task.CompletedTask;
    }
}