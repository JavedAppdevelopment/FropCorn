using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FropCorn.ViewModel;
using Newtonsoft.Json;

namespace FropCorn.Services
{
	public class VideoService
	{
		public VideoService()
		{
		}

		public async Task<List<VideosViewModel>> GetAllVideosBySearchAsync(string searchWord, string slug)
		{
			try
			{
				using (var client = new HttpClient())
				{
					string baseurl = Config.APIEndPoint + "search?query=" + searchWord;
					client.BaseAddress = new Uri(baseurl);
					client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
					client.DefaultRequestHeaders.Add("x-slug",slug);

					HttpResponseMessage responseMessage = await client.GetAsync(baseurl);
					if (responseMessage.IsSuccessStatusCode)
					{
						System.Diagnostics.Debug.WriteLine("Data Search Successfully.");
						System.Diagnostics.Debug.WriteLine("Response Result : " + await responseMessage.Content.ReadAsStringAsync());
						var searchResult = JsonConvert.DeserializeObject<List<VideosViewModel>>(await responseMessage.Content.ReadAsStringAsync());
						return searchResult;
					}
					else {
						throw new Exception("Exception in Fetchin Videos : Message : " + responseMessage.RequestMessage + " Reason : " + responseMessage.ReasonPhrase);
					}
				}
			}
			catch (Exception pException)
			{
				System.Diagnostics.Debug.WriteLine("Exception in search : " + pException.Message);
				throw pException;
			}
			finally
			{
				GC.Collect();
			}
			return null;
		}

	}
}

