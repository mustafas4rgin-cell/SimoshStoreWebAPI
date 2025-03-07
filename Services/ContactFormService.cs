using App.Data.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SimoshStore;

namespace SimoshStoreAPI;

public class ContactFormService : IContactFormService
{
    private readonly IDataRepository _Repository;
    private readonly IValidator<ContactDTO> _Validator;
    public ContactFormService(IValidator<ContactDTO> validator, IDataRepository repository)
    {
        _Validator = validator;
        _Repository = repository;
    }
    public async Task<ContactFormEntity> GetContactFormAsync(int id)
    {
        var contactForm = await _Repository.GetByIdAsync<ContactFormEntity>(id);
        if (contactForm is null)
        {
            throw new NullReferenceException("Contact form not found");
        }
        return contactForm;
    }
    public async Task<IServiceResult> UpdateContactFormAsync(int id, ContactDTO dto)
    {
        var contactForm = await _Repository.GetByIdAsync<ContactFormEntity>(id);
        if (contactForm is null)
        {
            return new ServiceResult(false, "Contact form not found");
        }
        var validationResult = _Validator.Validate(dto);
        if (!validationResult.IsValid)
        {
            return new ServiceResult(false, validationResult.Errors.First().ErrorMessage);
        }
        contactForm.Name = dto.Name;
        contactForm.Email = dto.Email;
        contactForm.Message = dto.Message;
        await _Repository.UpdateAsync(contactForm);
        return new ServiceResult(true, "Contact form updated successfully");
    }
    public async Task<IServiceResult> CreateContactFormAsync(ContactDTO dto)
    {
        var validationResult = _Validator.Validate(dto);
        if (!validationResult.IsValid)
        {
            return new ServiceResult(false, validationResult.Errors.First().ErrorMessage);
        }
        var contactForm = MappingHelper.MappingContactForm(dto);
        await _Repository.AddAsync(contactForm);
        return new ServiceResult(true, "Contact form created successfully");
    }
    public async Task<IServiceResult> DeleteContactFormAsync(int id)
    {
        var contactForm = await _Repository.GetByIdAsync<ContactFormEntity>(id);
        if (contactForm is null)
        {
            return new ServiceResult(false, "Contact form not found");
        }
        await _Repository.DeleteAsync<ContactFormEntity>(id);
        return new ServiceResult(true, "Contact form deleted successfully");
    }
    public async Task<IEnumerable<ContactFormEntity>> GetContactFormsAsync()
    {
        var contactForms = await _Repository.GetAll<ContactFormEntity>().ToListAsync();
        if (contactForms == null)
        {
            throw new Exception("No contact forms found");
        }
        return contactForms;
    }
}
