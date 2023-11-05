using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Ahada.Metronic.Contracts.Elements.Abstracts;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahada.Metronic.Models.Elements.Abstracts;

internal class KeenHtmlElementAttributeBuilder : KeenHtmlElement<IKeenHtmlElementAttributeBuilder, KeenHtmlElementAttributeBuilder>, IKeenHtmlElementAttributeBuilder
{
    public Task<IDictionary<string, string>> GetAs()
    {
        return Task.FromResult(Attributes);
    }

    public async Task WriteTo(IHtmlHelper html)
    {
        IDictionary<string, string> attributes = await GetAs();
        
        await using StringWriter writer = new StringWriter();
        await writer.FlushAsync();
        foreach (KeyValuePair<string,string> attribute in attributes)
        {
            await writer.WriteAsync($" {attribute.Key}=\"{attribute.Value}\" ");
        }
        await html.ViewContext.Writer.WriteAsync(writer.ToString());
    }
}