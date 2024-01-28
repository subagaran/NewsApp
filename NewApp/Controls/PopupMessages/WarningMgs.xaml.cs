using CommunityToolkit.Maui.Views;
using NewsApp.MVVM.Model;

namespace NewsApp.Controls.PopupMessages;

public partial class WarningMgs : Popup
{
    public WarningMgs(PopUpMessagesLocalModel popUpMessagesModel)
    {
        InitializeComponent();
        this.BindingContext = popUpMessagesModel;
    }

    private void OnClickedClosebtn(object sender, EventArgs e)
    {
        this.Close();
    }

}