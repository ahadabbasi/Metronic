using Ahada.Metronic.Contracts.Elements.Abstracts;
using Ahada.Metronic.Models.Enums;
using Ahada.Metronic.Models.Enums.Elements;
using Microsoft.AspNetCore.Html;

namespace Ahada.Metronic.Contracts.Elements.Buttons;

public interface IKeenHtmlButtonElement : IKeenHtmlInnerTextElement<IKeenHtmlButtonElement>, IHtmlContent
{
    IKeenHtmlButtonElement Styled(KeenType type);
    
    IKeenHtmlButtonElement Type(KeenButtonType type);
    
    IKeenHtmlButtonElement LinkTo(string url);
    
    IKeenHtmlButtonElement IsIndicator(string indicatorText);
}