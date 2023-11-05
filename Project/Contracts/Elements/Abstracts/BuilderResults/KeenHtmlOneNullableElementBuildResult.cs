﻿using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahada.Metronic.Contracts.Elements.Abstracts.BuilderResults;

internal class KeenHtmlOneNullableElementBuildResult : Tuple<TagBuilder?>, IKeenHtmlElementBuildResult
{
    public KeenHtmlOneNullableElementBuildResult(TagBuilder? item1) : base(item1)
    {
    }
}