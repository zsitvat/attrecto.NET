using Academy_2023.Data;
using Academy_2023.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Academy_2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly CourseRepository _courseRepository;

        public CourseController()
        {
            _courseRepository = new CourseRepository();
        }

        // GET: api/<CourseController>
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return _courseRepository.GetAll();
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public ActionResult<Course> Get(int id)
        {
            var user = _courseRepository.GetById(id);

            return user == null ? NotFound() : user;
        }

        // POST api/<CourseController>
        [HttpPost]
        public ActionResult Post([FromBody] Course data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _courseRepository.Create(data);

            return NoContent();
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Course data)
        {
            var user = _courseRepository.Update(id, data);

            return user == null ? NotFound() : NoContent();
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return _courseRepository.Delete(id) ? NoContent() : NotFound();
        }
    }
}
