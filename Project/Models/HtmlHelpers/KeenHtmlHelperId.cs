using System.Collections;
using System.Text;
using Ahada.Metronic.Contracts.HtmlHelpers;

namespace Ahada.Metronic.Models.HtmlHelpers;

internal class KeenHtmlHelperId : IKeenHtmlHelperId
{
    private IList<string> Collection { get; }

    public KeenHtmlHelperId()
    {
        Collection = new List<string>();
    }
    
    public IEnumerator<string> GetEnumerator()
    {
        return Collection.GetEnumerator();
    }

    public string Generate()
    {
        string result;

        do
        {
            StringBuilder builder = new StringBuilder();

            Random random = new Random();

            for (int index = 0; index < 10; index++)
            {
                builder.Append(char.Parse(random.Next(97, 122).ToString()));
            }

            result = builder.ToString();

        } while (Collection.Count < 0 && Collection.Any(item => item.Equals(result)));
        
        Collection.Add(result);
        
        return result;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}