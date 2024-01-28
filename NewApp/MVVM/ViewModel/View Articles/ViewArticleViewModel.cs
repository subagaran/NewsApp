using NewsAPI.Models;
using NewsApp.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.MVVM.ViewModel.View_Articles
{
    public partial class ViewArticleViewModel : BaseViewModel
    {
        public ObservableCollection<Articles> Article { get; set; } = new ObservableCollection<Articles>();
        public ViewArticleViewModel()
        {
            LoadNewsArticles();
        }
        public Task LoadNewsArticles()
        {
            Article.Clear();
            foreach (var article in articles)
            {
                Article.Add(article);
            }

            return Task.CompletedTask;
        }
    }
}
