using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_tut_1.Data;
using Web_API_tut_1.Models;

namespace Web_API_tut_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : Controller
    {
        private ContactAPIDbContext dbContext;
        public ContactsController(ContactAPIDbContext dbContext)
        {
            this.dbContext = dbContext;

        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            return Ok(await dbContext.Contacts.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddContacts(AddContactRequest addContactRequest)
        {
            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                FullName = addContactRequest.FullName,
                Address = addContactRequest.Address,
                Phone = addContactRequest.Phone,
                Email = addContactRequest.Email,
            };

            await dbContext.Contacts.AddAsync(contact);
            await dbContext.SaveChangesAsync();

            return Ok( contact);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateContact([FromRoute] Guid id ,UpdateContactRequest updateContactRequest)
        {
            var  contact = await dbContext.Contacts.FindAsync(id);
            if (contact != null)
            {
                contact.FullName = updateContactRequest.FullName;
                contact.Address = updateContactRequest.Address;
                contact.Phone = updateContactRequest.Phone;
                contact.Email = updateContactRequest.Email;

                await dbContext.SaveChangesAsync();
                return Ok( contact);
            }

            return NotFound();
        }
    }
}
