using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Filters;
using TokioMarinApiExample.Configuration;
using TokioMarineApiExample.Models;

namespace TokioMarineApiExample.Controllers;

[Route("todos")]
[ApiController]
public class TodoItemsController(TodoContext context, IOptions<MetaData> _metaData) : Controller
{
    [HttpGet]
    public async Task<BaseResponseDto<List<TodoItemDTO>>> GetTodoItems()
    {
       List<TodoItemDTO> totoItems = await context.TodoItems
            .Select(x => ItemToDto(x))
            .ToListAsync();

       return new BaseResponseDto<List<TodoItemDTO>>
       {
           data = totoItems,
           meta_data = _metaData.Value
       };
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponseDto<TodoItemDTO>>> GetTodoItem(long id)
    {
        var todoItem = await context.TodoItems.FindAsync(id);

        if (todoItem == null)
        {
            return NotFound();
        }
        
        return new BaseResponseDto<TodoItemDTO>
        {
            data =  ItemToDto(todoItem),
            meta_data = _metaData.Value
        };
    }
    
    [HttpPost]
    [SwaggerRequestExample(typeof(CreateTodoItemDto), typeof(CreateTodoItemExample))]
    public async Task<BaseResponseDto<TodoItemDTO>> PostTodoItem(TodoItemDTO todoDTO)
    {
        var todoItem = new TodoItem
        {
            IsComplete = todoDTO.IsComplete,
            Name = todoDTO.Name
        };

        context.TodoItems.Add(todoItem);
        await context.SaveChangesAsync();

        return new BaseResponseDto<TodoItemDTO>
        {
            data =  ItemToDto(todoItem),
            meta_data = _metaData.Value
        };
    }
    
    [HttpPut("{id}")]
    [SwaggerRequestExample(typeof(TodoItem), typeof(UpdateTodoItemExample))]
    public async Task<ActionResult<BaseResponseDto<string>>> PutTodoItem(long id, TodoItem todoItem)
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

        return new BaseResponseDto<string>
        {
            data =  "Update success",
            meta_data = _metaData.Value
        };
    }
    
    [HttpPatch("{id}")]
    [SwaggerRequestExample(typeof(JsonPatchDocument<TodoItem>), typeof(JsonPatchDocumentExample))]
    public async Task<ActionResult<BaseResponseDto<string>>> PatchTodoItem(long id, [FromBody] JsonPatchDocument<TodoItem> patchDoc)
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

        return new BaseResponseDto<string>
        {
            data =  "Update success",
            meta_data = _metaData.Value
        };
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<BaseResponseDto<string>>> DeleteTodoItem(long id)
    {
        var todoItem = await context.TodoItems.FindAsync(id);
        if (todoItem == null)
        {
            return NotFound();
        }

        context.TodoItems.Remove(todoItem);
        await context.SaveChangesAsync();

        return new BaseResponseDto<string>
        {
            data =  "Delete success",
            meta_data = _metaData.Value
        };
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