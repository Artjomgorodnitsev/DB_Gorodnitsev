using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using static artem_database.SQLite;

namespace artem_database
{

    public class FriendRepository
    {
        SQLiteConnection database;
        static object locker = new object();


        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<Friend>(id);
            }
        }
        public FriendRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Friend>();
        }
        public IEnumerable<Friend> GetItems()
        {
            return (from i in database.Table<Friend>() select i).ToList();

        }
        public Friend GetItem(int id) //позволяет получить элемент типа T по id
        {
            return database.Get<Friend>(id);
        }
        public int SaveItem(Friend item)
        {
            if (item.Id != 0)
            {
                database.Update(item); //обновляет объект
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
