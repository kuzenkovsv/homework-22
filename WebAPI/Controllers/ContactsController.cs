using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc; // [Route], [ApiController], ControllerBase
using PhoneBookEntitiesLib; // Contact
using WebAPI.Repositories; // IContactRepository

namespace WebAPI.Controllers
{
    // базовый адрес: api/contacts
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository repo;

        // конструктор вводит зарегистрированный репозиторий
        public ContactsController(IContactRepository repo)
        {
            this.repo = repo;
        }

        // вывод всех контактов, либо контактов определённой телефонной книги (по PhoneBookID)
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Contact>))]
        public async Task<IEnumerable<Contact>> GetContact(int? phoneBookID)
        {
            if (string.IsNullOrWhiteSpace(phoneBookID.ToString()))
            {
                return await repo.RetrieveAllAsync();
            }
            else
            {
                return (await repo.RetrieveAllAsync())
                .Where(contact => contact.PhoneBookID == phoneBookID);
            }
        }

        // GET: api/contacts/[id] 
        [HttpGet("{id}", Name = nameof(GetContact))] // named route
        [ProducesResponseType(200, Type = typeof(Contact))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetContact(int id)
        {
            Contact? c = await repo.RetrieveAsync(id);
            if (c == null)
            {
                return NotFound(); // 404 Resource not found
            }
            return Ok(c); // 200 OK with contact in body
        }

        // POST: api/contacts
        // BODY: Contact (JSON, XML)
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Contact))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] Contact c)
        {
            if (c == null)
            {
                return BadRequest(); // 400 Bad request
            }
            Contact? addedContact = await repo.CreateAsync(c);
            if (addedContact == null)
            {
                return BadRequest("Не удалось создать контакт.");
            }
            else
            {
                return CreatedAtRoute( // 201 Created
                routeName: nameof(GetContact),
                routeValues: new { id = addedContact.ContactID },
                value: addedContact);
            }
        }

        // PUT: api/contacts/[id]
        // BODY: Contact (JSON, XML)
        [HttpPut("{id}")]
        //[Authorize(Roles = "Administrators")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(
        int id, [FromBody] Contact c)
        {
            if (c == null || c.ContactID != id)
            {
                return BadRequest(); // 400 Bad request
            }
            Contact? existing = await repo.RetrieveAsync(id);
            if (existing == null)
            {
                return NotFound(); // 404 Resource not found
            }
            await repo.UpdateAsync(id, c);
            return new NoContentResult(); // 204 No content
        }

        // DELETE: api/contacts/[id]
        [HttpDelete("{id}")]
        //[Authorize(Roles = "Administrators")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            Contact? existing = await repo.RetrieveAsync(id);
            if (existing == null)
            {
                return NotFound(); // 404 Resource not found
            }
            bool? deleted = await repo.DeleteAsync(id);
            if (deleted.HasValue && deleted.Value) // short circuit AND
            {
                return new NoContentResult(); // 204 No content
            }
            else
            {
                return BadRequest( // 400 Bad request
                $"Contact {id} was found but failed to delete.");
            }
        }

    }
}

