using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahada.Metronic.Contracts.Elements.Abstracts;

public interface IKeenHtmlDisposableHtmlElement
{
    IHtmlHelper Html { get; }
    Task Initial();
    Task Terminate();
}