using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseSQLite.Data
{
    public class TodoItemDatabase
    {
        SQLiteAsyncConnection connection;
        public TodoItemDatabase()
        {

        }

        async Task Init()
        {
            if (connection is not null)
            {
                return;
            }
            connection = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await connection.CreateTableAsync<TodoItem>();

        }


        public async Task<List<TodoItem>> GetItemsAsync()
        {
            await Init();
            return await connection.Table<TodoItem>().ToListAsync();
        }

        public async Task<List<TodoItem>> GetItemNotDoneAsync()
        {
            await Init();
            return await connection.Table<TodoItem>().Where(i => i.Done==false).ToListAsync();

            // SQL queries are also possible
            //return await Database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }


        public async Task<TodoItem> GetItemAsync(int id)
        {
            await Init();
            return await connection.Table<TodoItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(TodoItem item)
        {
            await Init();
            if (item.ID != 0)
            {
                await connection.UpdateAsync(item);
                return item.ID;
            }
            else
            {
                return await connection.InsertAsync(item);
            }
        }

        public async Task<int> DeleteItemAsync(TodoItem item)
        {
            await Init();
            return await connection.DeleteAsync(item);
        }
    }
}
