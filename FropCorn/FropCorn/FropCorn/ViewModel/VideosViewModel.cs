using System;
using System.Collections.Generic;
using FropCorn.Model;

namespace FropCorn
{
	public class VideosViewModel
	{
		public string Title { get; set; }

		public string Language { get; set; }

		private List<string> _characters = new List<string>();

		public List<string> Characters { get { return _characters; } set { _characters = value; } }

		private List<string> _keywords = new List<string>();

		public List<string> Keywords { get { return _keywords; } set { _keywords = value; } }

		private List<string> _casts = new List<string>();

		public List<string> Cast { get { return _casts; } set { _casts = value; } }

		public VideosViewModel()
		{

		}

	}
}

