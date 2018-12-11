using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinEFCoreSample.Models;

namespace XamarinEFCoreSample.Services
{
    public class ItemDataStore : IDataStore<Item>
    {
        public async Task<bool> AddItemAsync(Item item)
        {
            int count = 0;
            using (var context = new TodoDbContext())
            {
                context.Add(item);
                count = await context.SaveChangesAsync();
            }
            return await Task.FromResult(count == 1);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            int count = 0;
            using (var context = new TodoDbContext())
            {
                var item = context.Items.Where(p => p.Id == id).FirstOrDefault();
                context.Remove<Item>(item);
                count = await context.SaveChangesAsync();
            }
            return await Task.FromResult(count == 1);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            using (var context = new TodoDbContext())
            {
                return await context.FindAsync<Item>(id);
            }
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            using (var context = new TodoDbContext())
            {
                return await Task.FromResult(context.Items);
            }
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            int count = 0;
            using (var context = new TodoDbContext())
            {
                context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                count = await context.SaveChangesAsync();
            }
            return await Task.FromResult(count == 1);
        }
    }
}
