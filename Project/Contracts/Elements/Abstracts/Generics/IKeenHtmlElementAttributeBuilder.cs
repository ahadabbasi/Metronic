using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahada.Metronic.Contracts.Elements.Abstracts.Generics;

public interface IKeenHtmlElementAttributeBuilder<TElement> : IKeenHtmlElement<TElement> 
    where TElement : IKeenHtmlElement<TElement>
{
    Task<IDictionary<string, string>> GetAs();
    
    Task WriteTo(IHtmlHelper html);
}