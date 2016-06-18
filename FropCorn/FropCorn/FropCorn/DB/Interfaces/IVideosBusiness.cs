using System;
using System.Collections.Generic;
using FropCorn.Model;

namespace FropCorn.DB.Intefaces
{
	public interface IVideosBusiness
	{
		List<Video> GetAllVideos();

		int CreateVideo(Video video);

		bool UpdateVideo(Video video);

		bool DeleteVideo(Video video);

		Video GetVideoByID(int ID);
	}
}

