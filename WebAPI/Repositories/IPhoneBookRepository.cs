using PhoneBookEntitiesLib;

namespace WebAPI.Repositories
{
    public interface IPhoneBookRepository
    {
        Task<PhoneBook?> CreateAsync(PhoneBook c);
        Task<IEnumerable<PhoneBook>> RetrieveAllAsync();
        Task<PhoneBook?> RetrieveAsync(int id);
        Task<PhoneBook?> UpdateAsync(int id, PhoneBook c);
        Task<bool?> DeleteAsync(int id);
    }
}
