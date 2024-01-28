using NewsApp.MVVM.ViewModel.Home;

namespace NewsApp.MVVM.View.Search;

public partial class SearchArticlePage : ContentPage
{
    private readonly HomeViewModel _mainHomeViewModel;

    public SearchArticlePage(HomeViewModel homeViewModel)
	{
		InitializeComponent();
        _mainHomeViewModel = homeViewModel;
        BindingContext = _mainHomeViewModel;
    }
}