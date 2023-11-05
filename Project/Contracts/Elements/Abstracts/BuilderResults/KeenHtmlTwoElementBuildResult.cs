﻿using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahada.Metronic.Contracts.Elements.Abstracts.BuilderResults;

internal class KeenHtmlTwoElementBuildResult : Tuple<TagBuilder, TagBuilder>, IKeenHtmlElementBuildResult
{
    public KeenHtmlTwoElementBuildResult(TagBuilder item1, TagBuilder item2) : base(item1, item2)
    {
    }
}