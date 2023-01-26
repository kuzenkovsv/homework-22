using PhoneBookContextLib;
using PhoneBookEntitiesLib;
using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace WebAPI.Repositories
{
    public class PhoneBookRepository : IPhoneBookRepository
    {
        // кэширование телефонных книжек
        private static ConcurrentDictionary<int, PhoneBook>? phoneBooksCache;
        private PhoneBooksContext pbdb;

        public PhoneBookRepository(PhoneBooksContext injectedContext)
        {
            pbdb = injectedContext;
            if (phoneBooksCache is null)
            {
                phoneBooksCache = new ConcurrentDictionary<int, PhoneBook>
                    (pbdb.PhoneBooks.ToDictionary(pbook => pbook.PhoneBookID));
            }
        }

        public async Task<PhoneBook?> CreateAsync(PhoneBook pb)
        {
            // добавление в базу данных
            EntityEntry<PhoneBook> addedpb = await pbdb.PhoneBooks.AddAsync(pb);

            int affected = await pbdb.SaveChangesAsync();
            if (affected == 1)
            {
                if (phoneBooksCache is null) return pb;

                // если телефонная книга новая, то добавление в кэш, иначе вызов метода UpdateCache
                return phoneBooksCache.AddOrUpdate(pb.PhoneBookID, pb, UpdateCache);
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<PhoneBook>> RetrieveAllAsync()
        {
            // извлечение из кэша
            return await Task.FromResult(phoneBooksCache is null ? Enumerable.Empty<PhoneBook>() : phoneBooksCache.Values);
        }

        public async Task<PhoneBook?> RetrieveAsync(int id)
        {
            return await Task.Run(() =>
            {
                if (phoneBooksCache is null) return null!;
                phoneBooksCache.TryGetValue(id, out PhoneBook? pbook);
                return Task.FromResult(pbook);
            });
        }



        private PhoneBook UpdateCache(int id, PhoneBook pbook)
        {
            if (phoneBooksCache is not null)
            {
                if (phoneBooksCache.TryGetValue(id, out PhoneBook? old))
                {
                    if (phoneBooksCache.TryUpdate(id, pbook, old))
                    {
                        return pbook;
                    }
                }
            }
            return null!;
        }

        public async Task<PhoneBook?> UpdateAsync(int id, PhoneBook pbook)
        {
            return await Task.Run(() =>
            {
                // обновление в базе данных
                pbdb.PhoneBooks.Update(pbook);
                int pbaffected = pbdb.SaveChanges();
                if (pbaffected == 1)
                {
                    // обновление в кэше
                    return Task.Run(() => UpdateCache(id, pbook));
                }
                return null;
            });
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            return await Task.Run(() =>
            {
                //удаление из базы данных
                PhoneBook? pbook = pbdb.PhoneBooks.Find(id);
                if (pbook is null) return null;
                pbdb.PhoneBooks.Remove(pbook);
                int affected = pbdb.SaveChanges();
                if (affected == 1)
                {
                    if (phoneBooksCache is null) return null;
                    // удаление из кэша
                    return Task.Run(() => phoneBooksCache.TryRemove(id, out pbook));
                }
                else
                {
                    return null;
                }
            });
        }
    }
}
