using System;
using Ahada.Metronic.Contracts.Elements.Abstracts;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahada.Metronic.Models.Elements.Abstracts.BuilderResults;

internal class KeenHtmlOneElementBuildResult : Tuple<TagBuilder>, IKeenHtmlElementBuildResult
{
    public KeenHtmlOneElementBuildResult(TagBuilder item1) : base(item1)
    {
    }
}