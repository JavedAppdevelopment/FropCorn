using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FropCorn;
using Xamarin.Forms;
using FropCorn.Droid.DB;
using FropCorn.DB;
using SQLite;
using System.IO;

[assembly: Dependency(typeof(SQLite_Android))]
namespace FropCorn.Droid.DB
{
    public class SQLite_Android : ISQLiteDB
    {
        public SQLite_Android()
        {
        }

        public SQLiteConnection GetConnection()
        {
            string dbName = Config.DBName;
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, dbName);           
            Config.DBPath = path;
            var Connection = new SQLite.SQLiteConnection(path);
            return Connection;
        }
    }
}