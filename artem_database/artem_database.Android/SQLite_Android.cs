using System;
using System.Collections.Generic;
using System.IO;
using artem_database.Droid;
using System.Text;
using static artem_database.SQLite;
using artem_database;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace artem_database
{

    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }
        public string GetDatabasePath(string sqliteFilename)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            return path;
        }
    }
}
