using System;
using System.Collections.Generic;
using System.Text;

namespace artem_database
{
    public class SQLite
    {
        public interface ISQLite
        {
            string GetDatabasePath(string filename);
        }
    }
}
