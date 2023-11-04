using System.Threading.Tasks;
using Ahada.Metronic.Contracts.Elements.Abstracts;
using Microsoft.AspNetCore.Html;

namespace Ahada.Metronic.Contracts.Elements.Tabs;

public interface IKeenHtmlTabBodyInnerElement : IKeenHtmlElement<IKeenHtmlTabBodyInnerElement>
{
    Task<IKeenHtmlTabBodyInnerElement> RenderAsBody<TModel>(string partialName, TModel? model);
    
    Task<IKeenHtmlTabBodyInnerElement> RenderAsBody(Task<IHtmlContent> partial);
    
    IKeenHtmlTabBodyInnerElement RenderAsBody(IHtmlContent partial);
}