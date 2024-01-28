using CommunityToolkit.Maui.Views;
using NewsApp.Controls.PopupMessages;
using NewsApp.Controls.PopupMessages;
using NewsApp.MVVM.Model;

namespace NewsApp.Helpers
{
    public static class PopUpMessage
    {
         

        public static void ErrorMessage(string mgs)
        {
            Device.InvokeOnMainThreadAsync(() =>
            {
                PopUpMessagesLocalModel popUpMessagesModel = new PopUpMessagesLocalModel();
                popUpMessagesModel.Tile = "Error";
                popUpMessagesModel.Mgs = mgs;

                var errorMgs = new ErrorMgs(popUpMessagesModel);
                Shell.Current.ShowPopup(errorMgs);
            });
        }

        public static void WarningMessage(string mgs)
        {
            Device.InvokeOnMainThreadAsync(() =>
            {
                PopUpMessagesLocalModel popUpMessagesModel = new PopUpMessagesLocalModel();
                popUpMessagesModel.Tile = "Warning";
                popUpMessagesModel.Mgs = mgs;

                var warningMgs = new WarningMgs(popUpMessagesModel);
                Shell.Current.ShowPopupAsync(warningMgs);
            });
        }


         
    }
}
