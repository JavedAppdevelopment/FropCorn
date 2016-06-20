using System;
using System.Collections.Generic;
using FropCorn.DB.Business;
using FropCorn.Helper;
using FropCorn.Model;
using Xamarin.Forms;

namespace FropCorn
{
	public partial class DetailPage : ContentPage
	{
		public DetailPage(VideosViewModel videoViewModel)
		{
			InitializeComponent();
			BindingContext = videoViewModel;
            			
			NavigationPage.SetHasNavigationBar(this, true);
			NavigationPage.SetHasBackButton(this, true);

			foreach (string cast in videoViewModel.Cast)
			{
				castStack.Children.Add(
					new Label
					{
						HorizontalOptions = LayoutOptions.FillAndExpand,
						Text = cast,
						TextColor = Color.Black,
						FontSize = 16,
						FontAttributes = FontAttributes.Italic,
					}
				);
			}

			foreach (string character in videoViewModel.Characters)
			{
				characterStack.Children.Add(
					new Label
					{
						HorizontalOptions = LayoutOptions.FillAndExpand,
						Text = character,
						TextColor = Color.Black,
						FontSize = 16,
						FontAttributes = FontAttributes.Italic,
					}
				);
			}

			foreach (string keyword in videoViewModel.Keywords)
			{
				keywordStack.Children.Add(
					new Label
					{
						HorizontalOptions = LayoutOptions.FillAndExpand,
						Text = keyword,
						TextColor = Color.Black,
						FontSize = 16,
						FontAttributes = FontAttributes.Italic,
					}
				);
			}

			try
			{
				Video video = TypeConvertHelper.ConvertVideoViewModelToVideo(videoViewModel);
				VideoBusiness videoBusiness = new VideoBusiness();
				if (videoBusiness.CreateVideo(video) > 0)
				{
					System.Diagnostics.Debug.WriteLine("Video Information added in table Successfully.");
				}
			}
			catch (Exception pException)
			{
				System.Diagnostics.Debug.WriteLine("Error in Adding Video Information in Database : Message : " + pException.Message);
			}
		}
	}
}

