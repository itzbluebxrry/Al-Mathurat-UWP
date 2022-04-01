using System;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel.Core;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Al_Mathurat_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;

            // Set XAML element as a drag region.
            Window.Current.SetTitleBar(AppTitleBar);


        }



        private void FlipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private async void launchURI_Click(object sender, RoutedEventArgs e)
        {
            // The URI to launch
            var uriBing = new Uri("mailto:itzbluebxrry@outlook.com?subject=Al-Mathurat%20UWP%20Feedback");

            // Launch the URI
            var success = await Windows.System.Launcher.LaunchUriAsync(uriBing);

            // Set the option to show a warning
            var promptOptions = new Windows.System.LauncherOptions();
            promptOptions.TreatAsUntrusted = true;

            if (success)
            {
                // URI launched
            }
            else
            {
                // URI launch failed
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExtendAcrylicIntoTitleBar()
        {
            Windows.ApplicationModel.Core.CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            Windows.UI.ViewManagement.ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = Windows.UI.Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
        }




    }
}