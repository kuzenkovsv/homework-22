using PhoneBookContextLib;
using PhoneBookEntitiesLib;
using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace WebAPI.Repositories
{
    public class ContactRepository : IContactRepository
    {
        // кэширование контактов
        private static ConcurrentDictionary<int, Contact>? contactsCache;
        private PhoneBooksContext db;

        public ContactRepository(PhoneBooksContext injectedContext)
        {
            db = injectedContext;
            if (contactsCache is null)
            {
                contactsCache = new ConcurrentDictionary<int, Contact>
                    (db.Contacts.ToDictionary(c => c.ContactID));
            }
        }

        public async Task<Contact?> CreateAsync(Contact c)
        {
            // добавление в базу данных
            EntityEntry<Contact> added = await db.Contacts.AddAsync(c);

            int affected = await db.SaveChangesAsync();
            if (affected == 1)
            {
                if (contactsCache is null) return c;

                // если контакт новый, то добавление в кэш, иначе вызов метода UpdateCache
                return contactsCache.AddOrUpdate(c.ContactID, c, UpdateCache);
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Contact>> RetrieveAllAsync()
        {
            // извлечение из кэша
            return await Task.FromResult(contactsCache is null ? Enumerable.Empty<Contact>() : contactsCache.Values);
            //return await Task.Run<IEnumerable<Contact>>(() => contactsCache.Values);
        }

        public async Task<Contact?> RetrieveAsync(int id)
        {
            return await Task.Run(() =>
            {
                // извлечение из кэша
                //Contact c;
                //contactsCache.TryGetValue(id, out c);
                //return c;
                if (contactsCache is null) return null!;
                contactsCache.TryGetValue(id, out Contact? c);
                return Task.FromResult(c);
            });
        }



        private Contact UpdateCache(int id, Contact c)
        {
            if (contactsCache is not null)
            {
                if (contactsCache.TryGetValue(id, out Contact? old))
                {
                    if (contactsCache.TryUpdate(id, c, old))
                    {
                        return c;
                    }
                }
            }
            return null!;
        }

        public async Task<Contact?> UpdateAsync(int id, Contact c)
        {
            return await Task.Run(() =>
            {
                // обновление в базе данных
                db.Contacts.Update(c);
                int affected = db.SaveChanges();
                if (affected == 1)
                {
                    // обновление в кэше
                    return Task.Run(() => UpdateCache(id, c));
                }
                //else
                //{
                    return null;
                //}
            });
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            return await Task.Run(() =>
            {
                //удаление из базы данных
                Contact? c = db.Contacts.Find(id);
                if (c is null) return null;
                db.Contacts.Remove(c);
                int affected = db.SaveChanges();
                if (affected == 1)
                {
                    if (contactsCache is null) return null;
                    // удаление из кэша
                    return Task.Run(() => contactsCache.TryRemove(id, out c));
                }
                else
                {
                    return null;
                }
            });
        }
    }
}
