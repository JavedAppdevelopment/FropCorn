using System;
using System.Collections.Generic;

namespace FropCorn.ViewModel
{
	public class VideoAppViewModel
	{
		public static List<KeyValuePair<string, string>> lstVideoApp = new List<KeyValuePair<string, string>>();

		public VideoAppViewModel()
		{

		}

		public static List<KeyValuePair<string, string>> GetVideoApps()
		{
			lstVideoApp.Add(new KeyValuePair<string, string>("Spuul", "spuul"));
			lstVideoApp.Add(new KeyValuePair<string, string>("Eros Now", "erosNow"));
			lstVideoApp.Add(new KeyValuePair<string, string>("Fropcorn", "fropcorn"));
			lstVideoApp.Add(new KeyValuePair<string, string>("Hotstar", "hotstar"));
			lstVideoApp.Add(new KeyValuePair<string, string>("TVF Play", "tvfPlay"));
			lstVideoApp.Add(new KeyValuePair<string, string>("Hooq", "hooq"));
			lstVideoApp.Add(new KeyValuePair<string, string>("Viu", "Viu"));
			lstVideoApp.Add(new KeyValuePair<string, string>("Voot", "Voot"));

			return lstVideoApp;
		}

	}
}

