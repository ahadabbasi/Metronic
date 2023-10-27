using System.Threading.Tasks;
using Ahada.Metronic.Contracts.Elements.Abstracts;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahada.Metronic.Models.Elements.Abstracts;

internal class KeenHtmlBodyElement : KeenHtmlElement<IKeenHtmlBodyElement, KeenHtmlBodyElement>, IKeenHtmlBodyElement, IKeenHtmlDisposableHtmlElement
{
    public IHtmlHelper Html { get; }

    public KeenHtmlBodyElement(IHtmlHelper html)
    {
        Html = html;
    }
    
    public Task Initial()
    {
        throw new System.NotImplementedException();
    }

    public Task Terminate()
    {
        throw new System.NotImplementedException();
    }
}