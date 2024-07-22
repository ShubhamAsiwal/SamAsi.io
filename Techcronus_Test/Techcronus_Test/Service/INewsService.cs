using Techcronus_Test.Models;

namespace Techcronus_Test.ServiceLayer
{
    public interface INewsService
    {
        Task<IEnumerable<NewsItemModel>> FetchAndStoreNewsAsync(string apiKey);
    }
}
