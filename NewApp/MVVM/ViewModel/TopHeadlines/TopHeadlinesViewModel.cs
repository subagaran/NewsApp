using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using NewsApp.Helper;
using NewsApp.Helpers;
using NewsApp.MVVM.Model;
using NewsApp.MVVM.View.View_Articles;
using System.Collections.ObjectModel;

namespace NewsApp.MVVM.ViewModel.TopHeadlines
{
    public partial class TopHeadlinesViewModel : BaseViewModel
    { 
        public ObservableCollection<Headlines> AllTopHeadlines { get; set; } = new ObservableCollection<Headlines>();

        public TopHeadlinesViewModel()
        {
            Task.Run(async () => await GetTopHeadlinesBasedOnCategoryFromApi("Business"));
        }
        public async Task GetTopHeadlinesBasedOnCategoryFromApi(string catType)
        {
            try
            {

                bool Connection = await CheckInternetConnection();
                if (!Connection)
                {
                    PopUpMessage.WarningMessage("No internet connection or poor connection please try again later. This Bill will be Saved as Pause bill");
                }

                IsBusy = true;



                var newsApiClient = new NewsApiClient("d236ab8a26cf41108aa1ed56056306bd");
                
                Categories category;

                Enum.TryParse(catType, out category);

                var articlesResponse = await newsApiClient.GetTopHeadlinesAsync(new TopHeadlinesRequest
                {
                    Country = Countries.US,
                    Category = category
                });

                AllTopHeadlines.Clear();
                foreach (var article in articlesResponse.Articles)
                {

                    var newsArticle = new Headlines
                    {
                        Title = article.Title,
                        Author = article.Author,
                        Description = article.Description,
                        Url = article.Url,
                        UrlImage = article.UrlToImage,
                        PublishedAt = article.PublishedAt
                    };

                    AllTopHeadlines.Add(newsArticle);
                } 
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }


        [RelayCommand]
        public async Task GetTopHeadlinesBasedOnCategory()
        {
            var catType = GlobalVariables.GetCategory();
            await GetTopHeadlinesBasedOnCategoryFromApi(catType);
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
    }
}
