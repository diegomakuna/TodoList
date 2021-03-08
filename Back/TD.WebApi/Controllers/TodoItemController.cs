using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TD.Core.Todo.Models;
using TD.Core.Todo.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TD.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : Controller
    {
        private readonly ITodoItemRepo _repo;
        public TodoItemController(ITodoItemRepo repo)
        {
                _repo = repo;
        }
        // GET: api/<TodoItemController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _repo.GetAll();
            return Ok(response);
        }

        // GET api/<TodoItemController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _repo.GetBy(id);
                return Ok(response);
        }

        // POST api/<TodoItemController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TodoItemModel todoItem)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            todoItem.CreateAt = DateTime.UtcNow;
            todoItem.Completed = false;

            await _repo.Add(todoItem);
            return Ok(todoItem);
        }

        // PUT api/<TodoItemController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TodoItemModel todoitem)
        {
            var item = await _repo.GetBy(todoitem.Id);
            
            if (item == null)
                return NoContent();

            item.Title = todoitem.Title;
            item.Description = todoitem.Description;
            item.Completed = todoitem.Completed;
            item.UpdateAt = DateTime.UtcNow;

            var response = _repo.Update(todoitem);
            return Ok(item);
        }

        // DELETE api/<TodoItemController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _repo.GetBy(id);

            if (item == null)
                return NoContent();

            await _repo.Remove(item);

            return Ok();
        }
    }
}
