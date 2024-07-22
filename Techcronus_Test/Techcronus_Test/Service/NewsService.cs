using Newtonsoft.Json.Linq;
using Techcronus_Test.DataLayer;
using Techcronus_Test.Models;

namespace Techcronus_Test.ServiceLayer
{
    public class NewsService : INewsService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly INewsRepository _newsRepository;

        public NewsService(IHttpClientFactory clientFactory, INewsRepository newsRepository)
        {
            _clientFactory = clientFactory;
            _newsRepository = newsRepository;
        }

        public async Task<IEnumerable<NewsItemModel>> FetchAndStoreNewsAsync(string apiKey)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.nytimes.com/svc/topstories/v2/home.json?api-key={apiKey}");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to fetch data from NYT API");
            }

            var data = await response.Content.ReadAsStringAsync();
            var jsonData = JObject.Parse(data);

            var newsItems = new List<NewsItemModel>();
            foreach (var item in jsonData["results"])
            {
                var newsItem = new NewsItemModel
                {
                    Title = item["title"].ToString(),
                    Abstract = item["abstract"].ToString()
                };
                await _newsRepository.AddNewsAsync(newsItem);
                newsItems.Add(newsItem);
            }

            return newsItems;
        }
    }
}
