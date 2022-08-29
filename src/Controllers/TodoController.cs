using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApiEfCorePagination.Data;
using WebApiEfCorePagination.Models;



namespace WebApiEfCorePagination.Controllers
{
    [ApiController]
    [Route("api/v1/todos")]
    public class TodoController : Controller
    {
        [HttpGet("load")]
        public async Task<IActionResult> LoadAsync([FromServices] AppDbContext context)
        {
            for (int i = 0; i < 1500; i++)
            {
                var todo = new Todo
                {
                    Id = i + 1,
                    Done = false,
                    DateTime = DateTime.Now,
                    Title = $"Tarefa {i}"
                };

                await context.Todos.AddAsync(todo);
                await context.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpGet("skip/{pageIndex:int}/take/{pageSize:int}")]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context, [FromRoute] int pageIndex = 0,
            [FromRoute] int pageSize = 10)
        {
            var total = await context.Todos.CountAsync();

            var todos = await context.Todos
                                     .AsNoTracking()
                                     .Skip(pageSize * (pageIndex - 1))
                                     .Take(pageSize)
                                     .ToListAsync();

            return Ok(new PagedResult<Todo>(todos, total, pageIndex, pageSize));
        }
    }
}

