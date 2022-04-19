﻿using System;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel.Core;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Toolkit.Uwp.Helpers;

namespace Al_Mathurat_UWP
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            var titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            Window.Current.SetTitleBar(AppTitleBar);
            for (int i = 1; i <= 34;)
            {
                AddImage("ms-appx:///Assets/" + i.ToString() + ".jpg");
                i++;
            }
            ImgView.ItemsSource = images;
            if (SystemInformation.Instance.IsFirstRun)
            {
                ShowInfoBar("Al-Mathurat UWP is now on Stable!", "Announcement", InfoBarSeverity.Success);
            }
            scrBar.Maximum = images.Count;
            scrBar.Minimum = 1;
            scrBar.Value = ImgView.SelectedIndex;
            nbrbxGoto.Maximum = images.Count;
            nbrbxGoto.Minimum = 1;
        }

        private void FlipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nbrbxGoto.Value = ImgView.SelectedIndex + 1;
            scrBar.Value = ImgView.SelectedIndex + 1;
            txtPageNo.Text = nbrbxGoto.Value.ToString() + " of " + images.Count;
        }


        private async void launchURI_Click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("mailto:itzbluebxrry@outlook.com?subject=Al-Mathurat%20UWP%20Feedback"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
        private void AddImage(string Path)
        {
            images.Add(BitMapImages.CreateNewImage(new BitmapImage(new Uri(Path))));
        }
        ObservableCollection<BitMapImages> images = new ObservableCollection<BitMapImages>();

        private void ShowInfoBar(string Message, string Title = null, InfoBarSeverity? Severity = null, Button ActionButton = null, Style CloseButtonStyle = null, Windows.UI.Xaml.Media.Brush Background = null)
        {
            InfoBar infoBar = new InfoBar();
            infoBar.Margin = new Thickness(0, 92, 0, 0);
            infoBar.Message = Message;
            if (Title != null)
            {
                infoBar.Title = Title;
            }
            if (Severity != null)
            {
                infoBar.Severity = (InfoBarSeverity)Severity;
            }
            if (ActionButton != null)
            {
                infoBar.ActionButton = ActionButton;
            }
            if (CloseButtonStyle != null)
            {
                infoBar.CloseButtonStyle = CloseButtonStyle;
            }
            if (Background != null)
            {
                infoBar.Background = Background;
            }
            Grid.Children.Add(infoBar);
            infoBar.IsOpen = true;
        }

        private void btnNavigatePage_Click(object sender, RoutedEventArgs e)
        {
            flyNavigate.Hide();
            ImgView.SelectedIndex = ((int)nbrbxGoto.Value) - 1;
        }

        private void scrBar_ValueChanged(object sender, Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {

            ImgView.SelectedIndex = ((int)scrBar.Value) - 1;
        }

        private async void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            await new About().ShowAsync();
        }
    }

    public class BitMapImages
    {
        public BitmapImage Image { get; set; }
        public BitMapImages(BitmapImage image)
        {
            Image = image;
        }
        public static BitMapImages CreateNewImage(BitmapImage Image)
        {
            return new BitMapImages(Image);
        }
    }

}