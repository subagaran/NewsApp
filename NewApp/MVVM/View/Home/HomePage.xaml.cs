using NewsApp.MVVM.ViewModel.Home;

namespace NewApp.MVVM.View.Home;

public partial class HomePage : ContentPage
{
    private readonly HomeViewModel _mainHomeViewModel;

    public HomePage(HomeViewModel homeViewModel)
	{
		InitializeComponent();
        _mainHomeViewModel = homeViewModel;
        BindingContext = _mainHomeViewModel;

    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        
    }
}