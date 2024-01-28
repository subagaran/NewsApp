using NewsApp.Helper;
using NewsApp.MVVM.ViewModel.TopHeadlines;

namespace NewsApp.MVVM.View.TopHeadlines;

public partial class TopHeadlinesPage : ContentPage
{
	private readonly TopHeadlinesViewModel _topHeadlinesViewModel;
	public TopHeadlinesPage(TopHeadlinesViewModel topHeadlinesViewModel)
	{
		InitializeComponent();
		_topHeadlinesViewModel = topHeadlinesViewModel;
		BindingContext = _topHeadlinesViewModel;

        BtnChange("Business");
    }


    [Obsolete]
    private void BtnChange(string BtnStatus)
    {
        Device.InvokeOnMainThreadAsync(async () =>
        {
            switch (BtnStatus)
            {
                case "Business":
                    GlobalVariables.SetCategory("Business");
                    Entertainment.BackgroundColor = Color.FromRgb(132, 171, 232);
                    Business.BackgroundColor = Color.FromRgb(40, 122, 250);
                    Health.BackgroundColor = Color.FromRgb(132, 171, 232);
                    Sports.BackgroundColor = Color.FromRgb(132, 171, 232); 
                    break;

                case "Health":
                    GlobalVariables.SetCategory("Health");
                    Entertainment.BackgroundColor = Color.FromRgb(132, 171, 232);
                    Business.BackgroundColor = Color.FromRgb(132, 171, 232);
                    Health.BackgroundColor = Color.FromRgb(40, 122, 250);
                    Sports.BackgroundColor = Color.FromRgb(132, 171, 232); 
                    break;

                case "Sports":
                    GlobalVariables.SetCategory("Sports");

                    Entertainment.BackgroundColor = Color.FromRgb(132, 171, 232);
                    Business.BackgroundColor = Color.FromRgb(132, 171, 232);
                    Health.BackgroundColor = Color.FromRgb(132, 171, 232);
                    Sports.BackgroundColor = Color.FromRgb(40, 122, 250); 
                    break;

                default:
                    GlobalVariables.SetCategory("Entertainment");

                    Entertainment.BackgroundColor = Color.FromRgb(40, 122, 250);
                    Business.BackgroundColor = Color.FromRgb(132, 171, 232);
                    Health.BackgroundColor = Color.FromRgb(132, 171, 232);
                    Sports.BackgroundColor = Color.FromRgb(132, 171, 232); 
                    break;
            }
        });
    }

    private void todayBtn_Pressed(object sender, EventArgs e)
    {
        var BtnStatus = (sender as Button).Text;

        BtnChange(BtnStatus);
    }
}

