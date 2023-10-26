using Ahada.Metronic.Contracts;
using Ahada.Metronic.Contracts.Abstracts;
using Ahada.Metronic.Contracts.HtmlHelpers;
using Ahada.Metronic.Models.HtmlHelpers;

namespace Ahada.Metronic.Services;

public class KeenHtmlHelper : IKeenHtmlHelper
{
    public IKeenHtmlHelperId Id 
        => new KeenHtmlHelperId();
}