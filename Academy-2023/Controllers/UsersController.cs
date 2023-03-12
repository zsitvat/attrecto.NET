using Academy_2023.Data;
using Academy_2023.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academy_2023.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UsersController()
        {
            _userRepository = new UserRepository();
        }

        // GET: api/<UsersController>/get
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userRepository.GetAll();
        }


        // GET: api/<UsersController>/getadults
        [HttpGet]
        public IEnumerable<User> GetAdults()
        {
            return _userRepository.GetAdults();
        }

        // GET api/<UsersController>/get/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _userRepository.GetById(id);

            return user == null ? NotFound() : user;
        }

        // POST api/<UsersController>/post
        [HttpPost]
        public ActionResult Post([FromBody] User data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _userRepository.Create(data);

            return NoContent();
        }

        // PUT api/<UsersController>/put/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User data)
        {
            var user = _userRepository.Update(id, data);

            return user == null ? NotFound() : NoContent();
        }

        // DELETE api/<UsersController>/delete/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return _userRepository.Delete(id) ? NoContent() : NotFound();
        }
    }
}
