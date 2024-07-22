using Techcronus_Test.Models;

namespace Techcronus_Test.DataLayer
{
    public interface INewsRepository
    {
        Task<IEnumerable<NewsItemModel>> GetAllNewsAsync();
        Task AddNewsAsync(NewsItemModel newsItem);
    }

}
