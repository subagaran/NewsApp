using CommunityToolkit.Maui.Views;
using NewsApp.MVVM.ViewModel.NewsArticles;

namespace NewsApp.MVVM.View.NewsArticles;

public partial class ArticleDateRange : Popup
{
    private readonly NewsArticleHistoryViewModel _newsArticleHistoryViewModel;
    public ArticleDateRange(NewsArticleHistoryViewModel newsArticleHistoryViewModel)
	{
		InitializeComponent();
        _newsArticleHistoryViewModel = newsArticleHistoryViewModel;
        BindingContext = _newsArticleHistoryViewModel;
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        this.Close();
    }

    private void Cancelbtn_Clicked(object sender, EventArgs e)
    {
        this.Close();
    }

    private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {

    }
}