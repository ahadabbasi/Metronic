using System;
using System.Threading.Tasks;

namespace Ahada.Metronic.Models.Elements.Abstracts;

internal class KeenHtmlElementBody : IDisposable
{

    private Func<Task> Terminate { get; }
    public KeenHtmlElementBody(Func<Task> terminate)
    {
        Terminate = terminate;
    }

    public async void Dispose()
    {
        await Terminate();
    }

    
}