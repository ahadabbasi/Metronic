namespace Ahada.Metronic.Contracts.HtmlHelpers;

public interface IKeenHtmlHelperId : IEnumerable<string>
{
    /// <summary>
    /// Generate new id not be use in the request
    /// </summary>
    /// <returns><see cref="string"/> The new id after generate and length wold be 10</returns>
    string Generate();
}