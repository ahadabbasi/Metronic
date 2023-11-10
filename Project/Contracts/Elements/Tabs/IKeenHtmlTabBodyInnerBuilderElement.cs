using Ahada.Metronic.Contracts.Elements.Abstracts.BuilderResults;
using Ahada.Metronic.Contracts.Elements.Abstracts.Generics;

namespace Ahada.Metronic.Contracts.Elements.Tabs;

internal interface IKeenHtmlTabBodyInnerBuilderElement : IKeenHtmlElementBuilder<KeenHtmlOneElementBuildResult>
{
    IKeenHtmlTabBodyInnerBuilderElement WhatIsReference(string reference);
    
    IKeenHtmlTabBodyInnerBuilderElement IsActivate(bool activate);
}