using System;
using Ahada.Metronic.Contracts.Elements.Abstracts.Generics;
using Ahada.Metronic.Models.Enums;
using Microsoft.AspNetCore.Html;

namespace Ahada.Metronic.Contracts.Elements.Alerts;

public interface IKeenHtmlAlertElement : IKeenDisposableHtmlElement<IKeenHtmlAlertElement, IKeenHtmlAlertBodyElement>, IHtmlContent
{
    IKeenHtmlAlertElement Styled(KeenType type);
    IKeenHtmlAlertElement BorderIs(KeenBorder border);
    IKeenHtmlAlertElement PutTitleOnIt(string title);
    IKeenHtmlAlertElement MessageIs(string message);
    IKeenHtmlAlertElement MakeDisposable(bool disposable = true);
    IKeenHtmlAlertElement Body(Func<IKeenHtmlAlertBodyInnerElement, IKeenHtmlAlertBodyInnerElement> body);
}