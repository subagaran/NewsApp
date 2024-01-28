using CommunityToolkit.Mvvm.ComponentModel;
using NewApp.Helper;
using NewsAPI;
using NewsApp.Helpers;
using NewsApp.MVVM.Model;

namespace NewsApp.MVVM.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        protected static List<NewsArticle> NewsList = new List<NewsArticle>();
        protected static List<Articles> AllArticles = new List<Articles>();
        protected static List<Articles> articles = new List<Articles>();

        private readonly NewsApiClient _newsApiClient;
        private readonly NewsListService _newsListService;

        [ObservableProperty]
        bool isBusy;
        [ObservableProperty]
        string showMessage;
        public BaseViewModel()
        {
            _newsListService = new NewsListService();

            Task.Run(() => GetNews()).Wait();
        }

        public Task GetNews()
        {
            AllArticles = _newsListService.articles;
            return Task.CompletedTask;
        }

        partial void OnIsBusyChanged(bool value)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (value)
                {
                    LoadingIndicator.StartLoading();
                }
                else
                {
                    LoadingIndicator.CloseLoading();
                }
            });
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
