using NewsApp.MVVM.ViewModel.NewsArticles;

namespace NewApp.MVVM.View.NewsArticles;

public partial class NewsArticleHistoryPage : ContentPage
{

	private readonly NewsArticleHistoryViewModel _newsArticleHistoryViewModel;
	public NewsArticleHistoryPage(NewsArticleHistoryViewModel newsArticleHistoryViewModel)
	{
		InitializeComponent();
		_newsArticleHistoryViewModel = newsArticleHistoryViewModel;
		BindingContext = _newsArticleHistoryViewModel;
	}

    private void todayBtn_Pressed(object sender, EventArgs e)
    {

    }
}