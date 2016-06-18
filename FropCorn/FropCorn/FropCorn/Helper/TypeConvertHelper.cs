using System;
using System.Linq;
using FropCorn.Model;

namespace FropCorn.Helper
{
	public class TypeConvertHelper
	{		
		public static VideosViewModel ConvertVideoToVideoViewModel(Video video)
		{
			try
			{
				VideosViewModel tVideoViewModel = new VideosViewModel();
				tVideoViewModel.Title = video.Title;
				tVideoViewModel.Language = video.Language;
				tVideoViewModel.Characters = video.Characters.Split(',').ToList();
				tVideoViewModel.Cast = video.Casts.Split(',').ToList();
				tVideoViewModel.Keywords = video.Keyords.Split(',').ToList();
				return tVideoViewModel;
			}
			catch (Exception pException)
			{
				System.Diagnostics.Debug.WriteLine("Exception in Convert from video to VideosViewModel : " + pException.Message);
			}
			finally
			{
				GC.Collect();
			}
			return null;
		}

		public static Video ConvertVideoViewModelToVideo(VideosViewModel videosViewModel)
		{
			try
			{
				Video tVideo = new Video();
				tVideo.Title = videosViewModel.Title;
				tVideo.Language = videosViewModel.Language;
				tVideo.Casts = string.Join(",", videosViewModel.Cast);
				tVideo.Keyords = string.Join(",", videosViewModel.Keywords);
				tVideo.Characters = string.Join(",", videosViewModel.Characters);
				return tVideo;
			}
			catch (Exception pException)
			{
				System.Diagnostics.Debug.WriteLine("Exception in Convert from VideosViewModel To Video : " + pException.Message);
			}
			finally
			{
				GC.Collect();
			}
			return null;
		}
	}
}

