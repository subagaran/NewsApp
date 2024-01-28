using NewApp.Database;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using NewsApp.Helpers;
using NewsApp.MVVM.Model;
using NewsApp.MVVM.ViewModel;

namespace NewApp.Helper
{
    public class NewsListService 
    {
        public List<NewsArticle> newsList = new List<NewsArticle>();
        public List<Articles> articles = new List<Articles>(); 

        private const string ApiKey = "d236ab8a26cf41108aa1ed56056306bd";
        private const string ApiUrl = "https://newsapi.org/v2/top-headlines/sources";

        public NewsListService()
        {
            Task.Run(() => GetNewsFromApi()).Wait(); 
        }

        public async Task<List<Articles>> GetNewsFromApi()
        {

            bool Connection = await CheckInternetConnection();
            if (!Connection)
            {
                PopUpMessage.WarningMessage("No internet connection or poor connection please try again later. This Bill will be Saved as Pause bill");
            }

            var newsApiClient = new NewsApiClient("d236ab8a26cf41108aa1ed56056306bd");
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = "Apple"
            });
            if (articlesResponse.Status == Statuses.Ok)
            {
                // total results found
                Console.WriteLine(articlesResponse.TotalResults);
                // here's the first 20
                foreach (var article in articlesResponse.Articles)
                {
                    var newsArticle = new Articles
                    {
                        Title = article.Title,
                        Author = article.Author,
                        Description = article.Description,
                        UrlImage = LoadImage(article.UrlToImage),
                        Url = article.Url,
                        PublishedAt = article.PublishedAt
                    };

                    articles.Add(newsArticle);
                }
            }
            return articles;
        }

        public string LoadImage(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return "https://cdn.vectorstock.com/i/preview-1x/65/30/default-image-icon-missing-picture-page-vector-40546530.jpg";
            }

            return url;
        }


        public static Task<bool> CheckInternetConnection()
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                // Internet connection is available
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);

            }
        }
    }
}
