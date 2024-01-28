using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NewApp.Helper;
using NewApp.MVVM.View.NewsArticles;
using NewsAPI.Models;
using NewsApp.Helpers;
using NewsApp.MVVM.Model;
using NewsApp.MVVM.View.Search;
using NewsApp.MVVM.View.TopHeadlines;
using NewsApp.MVVM.View.View_Articles;
using System.Collections.ObjectModel;

namespace NewsApp.MVVM.ViewModel.Home
{
    public partial class HomeViewModel : BaseViewModel
    { 
        public ObservableCollection<Articles> Article { get; set; } = new ObservableCollection<Articles>();
        private readonly NewsListService _newsListService;

        [ObservableProperty]
        string searchKeyword;

        [ObservableProperty]
        int topHeadlinesCount;

        [ObservableProperty]
        int newsArticlesCount;

        public HomeViewModel()
        {
            Task.Run(() => LoadNewsArticles()).Wait(); 
        }

        public async Task LoadNewsArticles()
        {
            Article.Clear();
            foreach (var article in AllArticles.Take(10))
            {
                Article.Add(article);
            }

            NewsArticlesCount = Article.Count();
        }

        partial void OnSearchKeywordChanging(string _searchKeyword)
        {
            try
            {
                if (string.IsNullOrEmpty(_searchKeyword))
                {
                    Article.Clear();
                    LoadNewsArticles();
                    return;
                }

                var FilterCustomer = new List<Articles>();


                var searchKeywordChaArray = _searchKeyword.ToCharArray();
                var GetLasrsearchCh = searchKeywordChaArray.LastOrDefault();

                if (AllArticles != null)
                {
                    FilterCustomer = AllArticles.Where(a => a.Author.StartsWith(_searchKeyword, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                if (FilterCustomer.Count != 0)
                {
                    Article.Clear();
                    foreach (var item in FilterCustomer)
                    {
                        Article.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [RelayCommand]
        public async Task GotoNewsArticlePage()
        {
            await Shell.Current.GoToAsync($"{nameof(NewsArticleHistoryPage)}");
        }

        [RelayCommand]
        public async Task GotoHeadlinePage()
        {
            await Shell.Current.GoToAsync($"{nameof(TopHeadlinesPage)}");
        }

        [RelayCommand]
        public async Task GoToArticleVew(Articles article)
        {
            articles.Clear();
            var newsArticle = new Articles
            {
                Title = article.Title,
                Author = article.Author,
                Description = article.Description,
                Url = article.Url,
                UrlImage = article.UrlImage,
                PublishedAt = article.PublishedAt
            };

            articles.Add(newsArticle);

            await Shell.Current.GoToAsync($"{nameof(ViewArticlePage)}");
        }

        [RelayCommand]
        public async Task GotoSearchPage()
        {
            await Shell.Current.GoToAsync($"{nameof(SearchArticlePage)}");
        }

        [RelayCommand]
        public async Task GotoHeadlineCountryPage()
        {
            await Shell.Current.GoToAsync($"{nameof(TopHeadlinesCountryPage)}");
        }
    }
}
