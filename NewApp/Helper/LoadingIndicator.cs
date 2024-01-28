﻿
using CommunityToolkit.Maui.Views;
using NewsApp.Controls.LoadingIndicator;

namespace NewsApp.Helpers
{

    public static class LoadingIndicator
    {
        static LoadingIndicatorView popup;
        public static bool IsLoadingActive = false;


        public static Task StartLoading()
        {

            popup = new LoadingIndicatorView();
            Shell.Current.ShowPopup(popup);
            IsLoadingActive = true;

            return Task.CompletedTask;
        }

        public static Task CloseLoading()
        {
            if (IsLoadingActive)
            {
                popup.CloseLoadingIndicatorC();
            }
            return Task.CompletedTask;
        }
    }
}
