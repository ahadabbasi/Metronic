using Ahada.Metronic.Contracts.HtmlHelpers;

namespace Ahada.Metronic.Contracts;

public interface IKeenHtmlHelper
{
    /// <summary>
    /// Get collection of ids is reserve in the request to be not generate duplicate id
    /// </summary>
    IKeenHtmlHelperId Id { get; }
}