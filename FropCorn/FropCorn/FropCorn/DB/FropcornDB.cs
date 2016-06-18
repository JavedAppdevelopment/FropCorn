using System;
using FropCorn.Model;
using SQLite;
using Xamarin.Forms;

namespace FropCorn.DB
{
	public class FropcornDB
	{
		public SQLiteConnection Connection;
		public FropcornDB()
		{
			Connection = DependencyService.Get<ISQLiteDB>().GetConnection();
			Connection.CreateTable<Video>(CreateFlags.None);
		}
	}
}

