using Ahada.Metronic.Contracts.Elements.Abstracts.Generics;
using Ahada.Metronic.Models.Elements.Abstracts.BuilderResults;

namespace Ahada.Metronic.Contracts.Elements.Tabs;

internal interface IKeenHtmlTabBodyInnerBuilderElement : IKeenHtmlElementBuilder<KeenHtmlOneElementBuildResult>
{
    IKeenHtmlTabBodyInnerBuilderElement WhatIsReference(string reference);
    
    IKeenHtmlTabBodyInnerBuilderElement IsActivate(bool activate);
}