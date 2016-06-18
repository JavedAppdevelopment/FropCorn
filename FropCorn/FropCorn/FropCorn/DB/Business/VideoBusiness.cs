using System;
using System.Collections.Generic;
using System.Linq;
using FropCorn.DB.Intefaces;
using FropCorn.Model;

namespace FropCorn.DB.Business
{
	public class VideoBusiness : FropcornDB, IVideosBusiness
	{
		public VideoBusiness()
		{
		}

		public int CreateVideo(Video video)
		{
			try
			{
				var searchRecord = Connection.Table<Video>().Where(x => x.Title.Equals(video.Title) && x.Language.Equals(video.Language) && x.Casts.Equals(video.Casts) && x.Characters.Equals(video.Characters) && x.Keyords.Equals(video.Keyords)).ToList();
				if (!(searchRecord.Count > 0))
					return Connection.Insert(video);
				else
					throw new Exception("Record Already Existing.");
			}
			catch (Exception pException)
			{
				System.Diagnostics.Debug.WriteLine("Error in inserting Video : " + pException.Message);
				throw pException;
			}
			return 0;
		}

		public bool DeleteVideo(Video video)
		{
			try
			{
				return Connection.Delete(video) > 0;
			}
			catch (Exception pException)
			{
				System.Diagnostics.Debug.WriteLine("Error in Deleting : " + pException.Message);
				throw pException;
			}
			return false;
		}

		public List<Video> GetAllVideos()
		{

			try
			{
				return Connection.Table<Video>().ToList();
			}
			catch (Exception pException)
			{
				System.Diagnostics.Debug.WriteLine("Error in getting All Videos : " + pException.Message);
				throw pException;
			}
			return null;
		}

		public Video GetVideoByID(int ID)
		{

			try
			{
				return Connection.Get<Video>(ID);
			}
			catch (Exception pException)
			{
				System.Diagnostics.Debug.WriteLine("Error in : " + pException.Message);
				throw pException;
			}
			return null;
		}

		public bool UpdateVideo(Video video)
		{

			try
			{
				return Connection.Update(video) > 0;
			}
			catch (Exception pException)
			{
				System.Diagnostics.Debug.WriteLine("Error in Deleting : " + pException.Message);
				throw pException;
			}
			return false;
		}
	}
}

