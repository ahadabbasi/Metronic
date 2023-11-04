using System.Threading.Tasks;
using Ahada.Metronic.Contracts.Elements.Abstracts;
using Microsoft.AspNetCore.Html;

namespace Ahada.Metronic.Contracts.Elements.Cards;

public interface IKeenHtmlCardBodyInnerElement : IKeenHtmlElement<IKeenHtmlCardBodyInnerElement>, IHtmlContent
{
    Task<IKeenHtmlCardBodyInnerElement> RenderAsBody<TModel>(string partialName, TModel? model);
    Task<IKeenHtmlCardBodyInnerElement> RenderAsBody(Task<IHtmlContent> partial);
    IKeenHtmlCardBodyInnerElement RenderAsBody(IHtmlContent partial);
}