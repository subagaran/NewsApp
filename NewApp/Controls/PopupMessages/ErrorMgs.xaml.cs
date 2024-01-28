using CommunityToolkit.Maui.Views;
using NewsApp.MVVM.Model;

namespace NewsApp.Controls.PopupMessages;

public partial class ErrorMgs : Popup
{
    public ErrorMgs(PopUpMessagesLocalModel popUpMessagesModel)
    {
        InitializeComponent();
        this.BindingContext = popUpMessagesModel;
    }

    private void OnClickedClosebtn(object sender, EventArgs e)
    {
        this.Close();
    }

}