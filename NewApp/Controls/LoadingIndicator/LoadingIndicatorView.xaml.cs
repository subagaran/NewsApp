using CommunityToolkit.Maui.Views;

namespace NewsApp.Controls.LoadingIndicator;

public partial class LoadingIndicatorView : Popup
{
    [Obsolete]
    public LoadingIndicatorView()
    {
         

        InitializeComponent();
         
    }

    public void CloseLoadingIndicatorC()
    {
        this.Close();
    }
}