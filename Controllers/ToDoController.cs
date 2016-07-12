using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Azure_Demo_2.Controllers
{
    [Route("api/[controller]")]
    public class ToDoController : Controller
    {
        public ITodoRepository _iTodoRepository;
        public ToDoController(ITodoRepository iToDoRepo)
        {
            _iTodoRepository = iToDoRepo;
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _iTodoRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(string id)
        {
            var item = _iTodoRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _iTodoRepository.Add(item);
            return CreatedAtAction("GetTodo", new { id = item.Key }, item);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _iTodoRepository.Remove(id);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] TodoItem item)
        {
            if (item == null || item.Key != id)
            {
                return BadRequest();
            }

            var todo = _iTodoRepository.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _iTodoRepository.Update(item);
            return new NoContentResult();
        }

    }
}
