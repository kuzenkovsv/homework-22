using PhoneBookEntitiesLib;

namespace WebAPI.Repositories
{
    public interface IContactRepository
    {
        Task<Contact?> CreateAsync(Contact c);
        Task<IEnumerable<Contact>> RetrieveAllAsync();
        Task<Contact?> RetrieveAsync(int id);
        Task<Contact?> UpdateAsync(int id, Contact c);
        Task<bool?> DeleteAsync(int id);
    }
}
