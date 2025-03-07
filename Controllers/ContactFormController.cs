using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimoshStore;
using SimoshStoreAPI;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    
    [ApiController]
    public class ContactFormController : ControllerBase
    {
        private readonly IContactFormService _contactFormService;
        public ContactFormController(IContactFormService contactFormService)
        {
            _contactFormService = contactFormService;
        }
        [HttpGet("/api/contactforms")]
        public async Task<IActionResult> GetContactForms()
        {
            try
            {
                var contactForms = await _contactFormService.GetContactFormsAsync();
                return Ok(contactForms);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("/api/delete/contactform/{id}")]
        public async Task<IActionResult> DeleteContactForm(int id)
        {
            var result = await _contactFormService.DeleteContactFormAsync(id);
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpPost("/api/create/contactform")]
        public async Task<IActionResult> CreateContactForm(ContactDTO dto)
        {
            var result = await _contactFormService.CreateContactFormAsync(dto);
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpGet("/api/contactforms/{id}")]
        public async Task<IActionResult> GetContactForm(int id)
        {
            var contactForm = await _contactFormService.GetContactFormAsync(id);
            if(contactForm == null)
            {
                return NotFound();
            }
            return Ok(contactForm);
        }
    }
}
