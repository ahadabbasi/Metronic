using System;
using System.IO;
using System.Text.Encodings.Web;
using Ahada.Metronic.Contracts.Elements.Buttons;
using Ahada.Metronic.Models.Elements.Abstracts;
using Ahada.Metronic.Models.Enums;
using Ahada.Metronic.Models.Enums.Elements;

namespace Ahada.Metronic.Models.Elements.Buttons;

internal class KeenHtmlButtonElement : KeenHtmlElement<IKeenHtmlButtonElement, KeenHtmlButtonElement> , IKeenHtmlButtonElement
{
    public void WriteTo(TextWriter writer, HtmlEncoder encoder)
    {
        throw new NotImplementedException();
    }

    public IKeenHtmlButtonElement Styled(KeenType type)
    {
        throw new NotImplementedException();
    }

    public IKeenHtmlButtonElement Type(KeenButtonType type)
    {
        throw new NotImplementedException();
    }

    public IKeenHtmlButtonElement LinkTo(string url)
    {
        throw new NotImplementedException();
    }

    public IKeenHtmlButtonElement IsIndicator(string indicatorText)
    {
        throw new NotImplementedException();
    }
}