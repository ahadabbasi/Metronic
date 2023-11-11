using System;
using Ahada.Metronic.Contracts.Elements.Abstracts;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahada.Metronic.Models.Elements.Abstracts.BuilderResults;

public class KeenHtmlTwoNullableElementBuildResult : Tuple<TagBuilder?, TagBuilder?>, IKeenHtmlElementBuildResult
{
    public KeenHtmlTwoNullableElementBuildResult(TagBuilder? item1, TagBuilder? item2) : base(item1, item2)
    {
    }
}