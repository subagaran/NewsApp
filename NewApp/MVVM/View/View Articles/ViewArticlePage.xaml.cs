using NewsApp.MVVM.ViewModel.View_Articles;

namespace NewsApp.MVVM.View.View_Articles;

public partial class ViewArticlePage : ContentPage
{
	private readonly ViewArticleViewModel _viewModel;
	public ViewArticlePage(ViewArticleViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

    }
}