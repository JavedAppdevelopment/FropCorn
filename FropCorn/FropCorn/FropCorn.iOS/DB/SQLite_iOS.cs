using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using FropCorn;
using Xamarin.Forms;
using FropCorn.iOS.DB;
using FropCorn.DB;
using System.IO;

[assembly:Dependency(typeof(SQLite_iOS))]
namespace FropCorn.iOS.DB
{
    public class SQLite_iOS : ISQLiteDB
    {
        public SQLite_iOS()
        {
        }

        public SQLite.SQLiteConnection GetConnection()
        {
            try
            {
                string dbName = Config.DBName;
                string doumentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string libraryPath = Path.Combine(doumentPath, "..", "Library");
                string path = Path.Combine(libraryPath, dbName);                
                Config.DBPath = path;
                var Connection = new SQLite.SQLiteConnection(path);                
                return Connection;
            }
            catch (Exception pException)
            {
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
