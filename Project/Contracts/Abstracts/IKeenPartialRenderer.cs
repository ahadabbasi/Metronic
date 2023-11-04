using System.Threading.Tasks;

namespace Ahada.Metronic.Contracts.Abstracts;

public interface IKeenPartialRenderer
{
    Task<string> Render<TModel>(string partialName, TModel? model);
}