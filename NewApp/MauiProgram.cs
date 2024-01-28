using Microsoft.Extensions.Logging;
using NewApp.Database;
using NewApp.MVVM.View.Home;
using NewApp.MVVM.View.NewsArticles;
using NewsApp.MVVM.ViewModel.NewsArticles;
using NewsApp.MVVM.ViewModel.Home;
using SkiaSharp.Views.Maui.Controls.Hosting;
using CommunityToolkit.Maui;
using NewsApp.MVVM.ViewModel.TopHeadlines;
using NewsApp.MVVM.View.TopHeadlines;
using NewsApp.MVVM.View.Search;
using NewsApp.MVVM.ViewModel.View_Articles;
using NewsApp.MVVM.View.View_Articles;

namespace NewApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseSkiaSharp() 
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif
            //Database
            builder.Services.AddTransient<DatabaseContext>();
            //View           
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<NewsArticleHistoryPage>();
            builder.Services.AddTransient<TopHeadlinesPage>();
            builder.Services.AddTransient<SearchArticlePage>();
            builder.Services.AddTransient<ViewArticlePage>();
            builder.Services.AddTransient<TopHeadlinesCountryPage>();
            //viewModels
            builder.Services.AddTransient<HomeViewModel>();
            builder.Services.AddTransient<NewsArticleHistoryViewModel>();
            builder.Services.AddTransient<TopHeadlinesViewModel>();
            builder.Services.AddTransient<ViewArticleViewModel>();
            builder.Services.AddTransient<TopHeadlinesViewModel>();
            builder.Services.AddTransient<HeadlinesCountryViewModel>();

            return builder.Build();
        }
    }
}