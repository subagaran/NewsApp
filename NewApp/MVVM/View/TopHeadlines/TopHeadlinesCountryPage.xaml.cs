using NewsApp.Helper;
using NewsApp.MVVM.ViewModel.TopHeadlines;

namespace NewsApp.MVVM.View.TopHeadlines;

public partial class TopHeadlinesCountryPage : ContentPage
{
    private readonly HeadlinesCountryViewModel _topHeadlinesViewModel;
	public TopHeadlinesCountryPage(HeadlinesCountryViewModel topHeadlinesViewModel)
	{
		InitializeComponent();
        _topHeadlinesViewModel = topHeadlinesViewModel;
        BindingContext = _topHeadlinesViewModel;

        BtnChange("UnitedStates");
    }

    private void todayBtn_Pressed(object sender, EventArgs e)
    {
        var BtnStatus = (sender as Button).Text;

        BtnChange(BtnStatus);
    }

    [Obsolete]
    private void BtnChange(string BtnStatus)
    {
        Device.InvokeOnMainThreadAsync(async () =>
        {
            switch (BtnStatus)
            {
                case "UnitedStates":
                    GlobalVariables.SetCategory("us");
                    Slovakia.BackgroundColor = Color.FromRgb(132, 171, 232);
                    UnitedStates.BackgroundColor = Color.FromRgb(40, 122, 250);
                    Slovenia.BackgroundColor = Color.FromRgb(132, 171, 232);
                    Morocco.BackgroundColor = Color.FromRgb(132, 171, 232);
                    break;

                case "Health":
                    GlobalVariables.SetCategory("si");
                    Slovakia.BackgroundColor = Color.FromRgb(132, 171, 232);
                    UnitedStates.BackgroundColor = Color.FromRgb(132, 171, 232);
                    Slovenia.BackgroundColor = Color.FromRgb(40, 122, 250);
                    Morocco.BackgroundColor = Color.FromRgb(132, 171, 232);
                    break;

                case "Morocco":
                    GlobalVariables.SetCategory("ma");

                    Slovakia.BackgroundColor = Color.FromRgb(132, 171, 232);
                    UnitedStates.BackgroundColor = Color.FromRgb(132, 171, 232);
                    Slovenia.BackgroundColor = Color.FromRgb(132, 171, 232);
                    Morocco.BackgroundColor = Color.FromRgb(40, 122, 250);
                    break;

                default:
                    GlobalVariables.SetCategory("sk");

                    Slovakia.BackgroundColor = Color.FromRgb(40, 122, 250);
                    UnitedStates.BackgroundColor = Color.FromRgb(132, 171, 232);
                    Slovenia.BackgroundColor = Color.FromRgb(132, 171, 232);
                    Morocco.BackgroundColor = Color.FromRgb(132, 171, 232);
                    break;
            }
        });
    }

}