using NewApp.MVVM.View.Home;
using NewApp.MVVM.View.NewsArticles;
using NewsApp.MVVM.View.Search;
using NewsApp.MVVM.View.TopHeadlines;
using NewsApp.MVVM.View.View_Articles;

namespace NewApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(NewsArticleHistoryPage), typeof(NewsArticleHistoryPage));
            Routing.RegisterRoute(nameof(TopHeadlinesPage), typeof(TopHeadlinesPage));
            Routing.RegisterRoute(nameof(SearchArticlePage), typeof(SearchArticlePage));
            Routing.RegisterRoute(nameof(ViewArticlePage), typeof(ViewArticlePage));
            Routing.RegisterRoute(nameof(TopHeadlinesCountryPage), typeof(TopHeadlinesCountryPage));
        }
    }
}