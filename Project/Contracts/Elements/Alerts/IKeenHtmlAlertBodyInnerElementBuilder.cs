namespace Ahada.Metronic.Contracts.Elements.Alerts;

internal interface IKeenHtmlAlertBodyInnerElementBuilder : IKeenHtmlAlertBodyInnerElement
{
    IKeenHtmlAlertBodyInnerElementBuilder PutTitleOnIt(string title);
    IKeenHtmlAlertBodyInnerElementBuilder MessageIs(string message);
}