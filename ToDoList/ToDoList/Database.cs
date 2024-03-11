using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class Database
    {
        private readonly SQLiteAsyncConnection _connection;
        public Database(String dbpath)
        {
            _connection = new SQLiteAsyncConnection(dbpath);
            _connection.CreateTableAsync<Item>();
        }
        public Task<int> SaveItemAsync(Item item)
        {
            if (item.Id != 0)
            {
                return _connection.UpdateAsync(item);
            }
            else
            {
                return _connection.InsertAsync(item);
            }
        }

        public Task<List<Item>> GetItemsAsync()
        {
            return _connection.Table<Item>().ToListAsync();
        }


    }
}
