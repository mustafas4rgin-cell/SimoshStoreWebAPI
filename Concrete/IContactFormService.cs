using App.Data.Entities;
using SimoshStore;

namespace SimoshStoreAPI;

public interface IContactFormService
{
    Task<IServiceResult> DeleteContactFormAsync(int id);
    Task<IEnumerable<ContactFormEntity>> GetContactFormsAsync();
    Task<ContactFormEntity> GetContactFormAsync(int id);
    Task<IServiceResult> UpdateContactFormAsync(int id, ContactDTO dto);
    Task<IServiceResult> CreateContactFormAsync(ContactDTO dto);

}
