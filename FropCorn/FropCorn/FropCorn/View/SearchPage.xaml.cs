using System;
using System.Collections.Generic;
using System.Linq;
using FropCorn.Services;
using FropCorn.ViewModel;
using Xamarin.Forms;
using Plugin.Connectivity;

namespace FropCorn.Views
{
    public partial class SearchPage : ContentPage
    {
        private string slug = "";

        void VideoSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length >= 3 && CrossConnectivity.Current.IsConnected)
            {
                BindListData();
            }
        }

        void LstVideos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            VideosViewModel videosViewModel = (VideosViewModel)e.Item;
            Navigation.PushAsync(new DetailPage(videosViewModel), true);
        }

        public SearchPage()
        {
            InitializeComponent();
            Title = "FropCorn Video search";
            NavigationPage.SetHasNavigationBar(this, true);
            NavigationPage.SetHasBackButton(this, false);

            TapGestureRecognizer lblVideoAppTapGesture = new TapGestureRecognizer();
            lblVideoAppTapGesture.Tapped += LblVideoAppTapGesture_Tapped;

            lblPickerVideoApp.GestureRecognizers.Add(lblVideoAppTapGesture);

            lblPickerVideoApp.Text = "Spuul";
            slug = "spuul";

            lstVideos.ItemTapped += LstVideos_ItemTapped;
            videoSearchBar.TextChanged += VideoSearchBar_TextChanged;

            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        }

        private void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                videoSearchBar.IsEnabled = true;
                lblMsg.IsVisible = false;
                lblMsg.Text = "Data Not Found"; //set default message.
                if(videoSearchBar.Text.Length >= 3)
                {
                    BindListData();
                }
            }
            else
            {
                videoSearchBar.IsEnabled = false;
                lblMsg.IsVisible = true;
                lblMsg.Text = "Internet Connection Not Available";
            }
        }

        private async void LblVideoAppTapGesture_Tapped(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, string> videoAppDictionary = VideoAppViewModel.GetVideoApps();
                string[] videoSheetItems = new string[videoAppDictionary.Count];
                for (int i = 0; i < videoAppDictionary.Count; i++)
                {
                    videoSheetItems[i] = videoAppDictionary.ElementAt(i).Key;
                }
                var result = await DisplayActionSheet("Select Video App", null, null, videoSheetItems);

                lblPickerVideoApp.Text = result;
                slug = videoAppDictionary[lblPickerVideoApp.Text];   
                if(videoSearchBar.Text.Length >= 3 && CrossConnectivity.Current.IsConnected)             
                    BindListData();
                else
                {
                    lstVideos.ItemsSource = null;
                    lblMsg.IsVisible = true;                    
                }
            }
            catch (Exception pException)
            {
                System.Diagnostics.Debug.WriteLine("Exception : " + pException.Message + " " + pException.StackTrace);
            }
        }

        private async void BindListData()
        {
            try
            {                
                searchActivityIndicator.IsRunning = true;
                searchActivityIndicator.IsVisible = true;
                VideoService videoService = new VideoService();
                var listVideoViewModel = await videoService.GetAllVideosBySearchAsync(videoSearchBar.Text, slug);
                if (listVideoViewModel.Count > 0)
                {
                    lblMsg.IsVisible = false;
                    lstVideos.ItemsSource = listVideoViewModel;
                }
                else
                {
                    lstVideos.ItemsSource = null;
                    lblMsg.IsVisible = true;                    
                }
            }
            catch (Exception pException)
            {
                System.Diagnostics.Debug.WriteLine("Exception : " + pException.Message);
                lblMsg.IsVisible = true;
            }
            finally
            {
                GC.Collect();
                searchActivityIndicator.IsRunning = false;
                searchActivityIndicator.IsVisible = false;
            }
        }
    }
}

