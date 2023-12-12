using System.Threading.Tasks;
using Ahada.Metronic.Contracts.Elements.Abstracts;
using Ahada.Metronic.Contracts.Elements.Alerts;
using Ahada.Metronic.Models.Elements.Abstracts.Generics;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahada.Metronic.Models.Elements.Alerts;

internal class KeenHtmlAlertBodyElement : KeenHtmlBodyElement<IKeenHtmlAlertBodyElement, KeenHtmlAlertBodyElement>, 
    IKeenHtmlAlertBodyElement, IKeenHtmlDisposableHtmlElement
{
    
    public KeenHtmlAlertBodyElement(IHtmlHelper html) : base(html)
    {
        Tag = new TagBuilder("div")
        {
            Attributes =
            {
                {
                    ClassAttributeName, 
                    "d-flex flex-column text-light pe-0 pe-sm-10"
                }
            }
        };
    }

    public override TagBuilder Tag { get; }
    
    public override Task Build()
    {
        return Task.CompletedTask;
    }
}