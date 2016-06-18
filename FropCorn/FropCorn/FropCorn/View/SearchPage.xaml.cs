using System;
using System.Collections.Generic;
using System.Linq;
using FropCorn.Services;
using FropCorn.ViewModel;
using Xamarin.Forms;

namespace FropCorn.Views
{
	public partial class SearchPage : ContentPage
	{
		private string slug = "";

		void PickerVideoApp_SelectedIndexChanged(object sender, EventArgs e)
		{
			slug = VideoAppViewModel.GetVideoApps()[pickerVideoApp.SelectedIndex].Value;
			BindListData();
		}

		void VideoSearchBar_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (e.NewTextValue.Length >= 3)
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

			BindPickerData();
			lstVideos.ItemTapped += LstVideos_ItemTapped;
			videoSearchBar.TextChanged += VideoSearchBar_TextChanged;
			pickerVideoApp.SelectedIndexChanged += PickerVideoApp_SelectedIndexChanged;
		}

		public void BindPickerData()
		{
			List<KeyValuePair<string,string>> videoAppDictionary = VideoAppViewModel.GetVideoApps();
			foreach (var videoAppItem in videoAppDictionary)
			{
				pickerVideoApp.Items.Add(videoAppItem.Key);
			}
			pickerVideoApp.SelectedIndex = 0;
			slug = videoAppDictionary[pickerVideoApp.SelectedIndex].Value;
			BindListData();
		}

		private async void BindListData()
		{
			try
			{
				VideoService videoService = new VideoService();
				var listVideoViewModel = await videoService.GetAllVideosBySearchAsync(videoSearchBar.Text, slug);
				if (listVideoViewModel.Count > 0)
				{
					lblMsg.IsVisible = false;
					lstVideos.ItemsSource = listVideoViewModel;
				}
				else {
					lblMsg.IsVisible = true;
				}
			}
			catch (Exception pException)
			{
				System.Diagnostics.Debug.WriteLine("Exception : " + pException.Message);
				lblMsg.IsVisible = true;
			}
			finally {
				GC.Collect();
			}
		}
	}
}

