using System;

namespace FropCorn.Model
{
	public class Video : BaseModel
	{
		
		public string Title { get; set; }

		public string Language { get; set; }

		//comma separated value.
		public string Keyords { get; set; }

		//comma separated value.
		public string Characters { get; set; }

		//comma separated value.
		public string Casts { get; set; }

	}
}

