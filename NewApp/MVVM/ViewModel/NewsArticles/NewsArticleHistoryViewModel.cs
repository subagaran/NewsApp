using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NewsApp.MVVM.Model;
using NewsApp.MVVM.View.NewsArticles;
using NewsApp.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.MVVM.ViewModel.NewsArticles
{
    public partial class NewsArticleHistoryViewModel : BaseViewModel
    {
        public ObservableCollection<Articles> Article { get; set; } = new ObservableCollection<Articles>();

        [ObservableProperty]
        DateTime startDateRange = DateTime.UtcNow.Date;

        [ObservableProperty]
        DateTime endDateRange = DateTime.UtcNow.Date;

        public NewsArticleHistoryViewModel()
        {
            //Task.Run(() => LoadNewsArticles().Wait());

            //GetLastMonthArticles();
        }

        public Task LoadNewsArticles()
        {
            ShowMessage = "";
            if (AllArticles.Count() == 0)
            {
                ShowMessage = "No Articles found.";
            }
            Article.Clear();
            foreach (var article in AllArticles)
            {
                Article.Add(article);
            }

            return Task.CompletedTask;
        } 

        [RelayCommand]
        public Task GetTodayArticles()
        {
            ShowMessage = "";
            var date = DateTime.Now.Date;
            var ArticleList = AllArticles.Where(a => a.PublishedAt == date);

            if (ArticleList.Count() == 0)
            {
                ShowMessage = "No Articles found.";
            }

            Article.Clear();
            foreach (var item in ArticleList)
            {
                Article.Add(item);
            }

            return Task.CompletedTask;
        }

        [RelayCommand]
        public Task GetYesterdayArticles()
        {
            ShowMessage = "";

            var date = DateTime.Now.Date.AddDays(-1);
            var ArticleList = AllArticles.Where(a => a.PublishedAt == date);
            if (ArticleList.Count() == 0)
            {
                ShowMessage = "No Articles found.";
            }
            Article.Clear();
            foreach (var item in ArticleList)
            {
                Article.Add(item);
            }

            return Task.CompletedTask;
        }
        [RelayCommand]

        public Task GetLast7DaysArticles()
        {
            ShowMessage = "";

            var date = DateTime.Now.Date.AddDays(-7);
            var ArticleList = AllArticles.Where(a => a.PublishedAt == date);
            Article.Clear();

            if (ArticleList.Count() == 0)
            {
                ShowMessage = "No Articles found.";
            }

            foreach (var item in ArticleList)
            {
                Article.Add(item);
            }

            return Task.CompletedTask;
        }
        [RelayCommand]

        public Task GetLastMonthArticles()
        {
            IsBusy = true; 

            var ArticleList = AllArticles.Where(a => a.PublishedAt >= StartDateRange && a.PublishedAt <= EndDateRange);
            Article.Clear();
            foreach (var item in ArticleList)
            {
                Article.Add(item);
            }

            IsBusy = false;
            return Task.CompletedTask;
        }

        [RelayCommand]
        public async Task GetDateRange()
        {
            ArticleDateRange articleDateRange = new ArticleDateRange(this); 
            Shell.Current.ShowPopup(articleDateRange);
        }
    }
}
