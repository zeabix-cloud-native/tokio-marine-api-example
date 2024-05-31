using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Filters;
using TokioMarineApiExample.Models;

namespace TokioMarineApiExample.Controllers;

[Route("todos")]
[ApiController]
public class TodoItemsController(TodoContext context) : Controller
{
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItems()
    {
        return await context.TodoItems
            .Select(x => ItemToDto(x))
            .ToListAsync();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<TodoItemDTO>> GetTodoItem(long id)
    {
        var todoItem = await context.TodoItems.FindAsync(id);

        if (todoItem == null)
        {
            return NotFound();
        }

        return ItemToDto(todoItem);
    }
    
    [HttpPost]
    [SwaggerRequestExample(typeof(CreateTodoItemDto), typeof(CreateTodoItemExample))]
    public async Task<ActionResult<TodoItemDTO>> PostTodoItem(TodoItemDTO todoDTO)
    {
        var todoItem = new TodoItem
        {
            IsComplete = todoDTO.IsComplete,
            Name = todoDTO.Name
        };

        context.TodoItems.Add(todoItem);
        await context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetTodoItem),
            new { id = todoItem.Id },
            ItemToDto(todoItem));
    }
    
    [HttpPut("{id}")]
    [SwaggerRequestExample(typeof(TodoItem), typeof(UpdateTodoItemExample))]
    public async Task<IActionResult> PutTodoItem(long id, TodoItem todoItem)
    {
        if (id != todoItem.Id)
        {
            return BadRequest();
        }

        context.Entry(todoItem).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TodoItemExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }
    
    [HttpPatch("{id}")]
    [SwaggerRequestExample(typeof(JsonPatchDocument<TodoItem>), typeof(JsonPatchDocumentExample))]
    public async Task<IActionResult> PatchTodoItem(long id, [FromBody] JsonPatchDocument<TodoItem> patchDoc)
    {
        if (patchDoc == null)
        {
            return BadRequest();
        }

        var todoItem = await context.TodoItems.FindAsync(id);
        if (todoItem == null)
        {
            return NotFound();
        }

        patchDoc.ApplyTo(todoItem, (error) => ModelState.AddModelError("", error.ErrorMessage));

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TodoItemExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoItem(long id)
    {
        var todoItem = await context.TodoItems.FindAsync(id);
        if (todoItem == null)
        {
            return NotFound();
        }

        context.TodoItems.Remove(todoItem);
        await context.SaveChangesAsync();

        return NoContent();
    }
    
    private bool TodoItemExists(long id)
    {
        return context.TodoItems.Any(e => e.Id == id);
    }
    
    private static TodoItemDTO ItemToDto(TodoItem todoItem) =>
        new TodoItemDTO
        {
            Id = todoItem.Id,
            Name = todoItem.Name,
            IsComplete = todoItem.IsComplete
        };
}