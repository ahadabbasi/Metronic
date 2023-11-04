using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ahada.Metronic.Contracts.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;

namespace Ahada.Metronic.Services;

internal class KeenPartialRenderer : IKeenPartialRenderer
{
    private IRazorViewEngine ViewEngine { get; }
    private ITempDataProvider TempDataProvider { get; }
    private IServiceProvider ServiceProvider { get; }

    public KeenPartialRenderer(
        IRazorViewEngine viewEngine,
        ITempDataProvider tempDataProvider,
        IServiceProvider serviceProvider
    )
    {
        ViewEngine = viewEngine;
        TempDataProvider = tempDataProvider;
        ServiceProvider = serviceProvider;
    }

    public async Task<string> Render<TModel>(string partialName, TModel? model)
    {
        ActionContext actionContext = GetActionContext();

        IView partial = FindView(actionContext, partialName);

        await using StringWriter output = new StringWriter();

        ViewDataDictionary viewData = new ViewDataDictionary<TModel>(
            metadataProvider: new EmptyModelMetadataProvider(),
            modelState: new ModelStateDictionary()
        );

        if (model is not null)
            viewData.Model = model;

        ViewContext viewContext = new ViewContext(
            actionContext,
            partial,
            viewData,
            new TempDataDictionary(
                actionContext.HttpContext,
                TempDataProvider
            ),
            output,
            new HtmlHelperOptions()
        );

        await partial.RenderAsync(viewContext);

        return output.ToString();
    }

    private IView FindView(ActionContext actionContext, string partialName)
    {
        ViewEngineResult partialView = ViewEngine.GetView(null, partialName, false);

        IView? result = partialView.Success ? partialView.View : null;

        if (result is null)
        {
            partialView = ViewEngine.FindView(actionContext, partialName, false);

            result = partialView.Success ? partialView.View : null;

            if (result is null)
            {
                IEnumerable<string> searchedLocations =
                    partialView.SearchedLocations.Concat(partialView.SearchedLocations);

                string errorMessage = string.Join(
                    Environment.NewLine,
                    new[]
                    {
                        $"Unable to find partial '{partialName}'. The following locations were searched:"
                    }.Concat(
                        searchedLocations
                    )
                );

                throw new InvalidOperationException(errorMessage);
            }
        }

        return result;
    }

    private ActionContext GetActionContext()
    {
        HttpContext httpContext = new DefaultHttpContext
        {
            RequestServices = ServiceProvider
        };

        return new ActionContext(httpContext, new RouteData(), new ActionDescriptor());
    }
}