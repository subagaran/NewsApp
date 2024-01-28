using CommunityToolkit.Mvvm.Input;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using NewsApp.Helper;
using NewsApp.Helpers;
using NewsApp.MVVM.Model;
using NewsApp.MVVM.View.View_Articles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.MVVM.ViewModel.TopHeadlines
{
    public partial class HeadlinesCountryViewModel : BaseViewModel
    {
        public ObservableCollection<Headlines> AllTopHeadlines { get; set; } = new ObservableCollection<Headlines>();

        public HeadlinesCountryViewModel()
        {
            GetTopHeadlinesBasedOnCategoryFromApi("us").Wait();
        }
        public async Task GetTopHeadlinesBasedOnCategoryFromApi(string cou)
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

                Countries country;

                Enum.TryParse(cou, out country);

                var articlesResponse = await newsApiClient.GetTopHeadlinesAsync(new TopHeadlinesRequest
                {
                    Country = country, 
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
            var country = GlobalVariables.GetCategory();
            await GetTopHeadlinesBasedOnCategoryFromApi(country);
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
