using Microsoft.AspNetCore.Mvc; // [Route], [ApiController], ControllerBase
using PhoneBookEntitiesLib; // PhoneBook
using WebAPI.Repositories; // IPhoneBookRepository

namespace WebAPI.Controllers
{
    // базовый адрес: api/phoneBooks
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBooksController : ControllerBase
    {
        private readonly IPhoneBookRepository pbrepo;

        // конструктор вводит зарегистрированный репозиторий
        public PhoneBooksController(IPhoneBookRepository pbrepo)
        {
            this.pbrepo = pbrepo;
        }

        // вывод всех телефонных книг
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PhoneBook>))]
        public async Task<IEnumerable<PhoneBook>> GetPhoneBook(int? phoneBookID)
        {
            if (string.IsNullOrWhiteSpace(phoneBookID.ToString()))
            {
                return await pbrepo.RetrieveAllAsync();
            }
            else
            {
                return (await pbrepo.RetrieveAllAsync())
                .Where(phoneBook => phoneBook.PhoneBookID >= phoneBookID);
            }

        }

        // GET: api/phoneBooks/[id] 
        [HttpGet("{id}", Name = nameof(GetPhoneBook))] // named route
        [ProducesResponseType(200, Type = typeof(PhoneBook))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetPhoneBook(int id)
        {
            PhoneBook? pb = await pbrepo.RetrieveAsync(id);
            if (pb == null)
            {
                return NotFound(); // 404 Resource not found
            }
            return Ok(pb); // 200 OK with PhoneBook in body
        }

        // POST: api/phoneBooks
        // BODY: PhoneBook (JSON, XML)
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(PhoneBook))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] PhoneBook pb)
        {
            if (pb == null)
            {
                return BadRequest(); // 400 Bad request
            }
            PhoneBook? addedPhoneBook = await pbrepo.CreateAsync(pb);
            if (addedPhoneBook == null)
            {
                return BadRequest("Не удалось создать телефонную книжку.");
            }
            else
            {
                return CreatedAtRoute( // 201 Created
                routeName: nameof(GetPhoneBook),
                routeValues: new { id = addedPhoneBook.PhoneBookID },
                value: addedPhoneBook);
            }
        }

        // PUT: api/phoneBooks/[id]
        // BODY: phoneBooks (JSON, XML)
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(
        int id, [FromBody] PhoneBook pb)
        {
            if (pb == null || pb.PhoneBookID != id)
            {
                return BadRequest(); // 400 Bad request
            }
            PhoneBook? existing = await pbrepo.RetrieveAsync(id);
            if (existing == null)
            {
                return NotFound(); // 404 Resource not found
            }
            await pbrepo.UpdateAsync(id, pb);
            return new NoContentResult(); // 204 No content
        }

        // DELETE: api/phoneBooks/[id]
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            PhoneBook? existing = await pbrepo.RetrieveAsync(id);
            if (existing == null)
            {
                return NotFound(); // 404 Resource not found
            }
            bool? deleted = await pbrepo.DeleteAsync(id);
            if (deleted.HasValue && deleted.Value) // short circuit AND
            {
                return new NoContentResult(); // 204 No content
            }
            else
            {
                return BadRequest( // 400 Bad request
                $"PhoneBook {id} was found but failed to delete.");
            }
        }
    }
}
