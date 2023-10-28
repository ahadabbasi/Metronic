using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahada.Metronic.Contracts.Elements.Abstracts;

public interface IKeenHtmlElementBuilder : IKeenHtmlElement<IKeenHtmlElementBuilder>
{
    Task<IDictionary<string, string>> GetAs();
    
    Task WriteTo(IHtmlHelper html);
}