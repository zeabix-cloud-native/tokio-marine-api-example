using Swashbuckle.AspNetCore.Filters;
using TokioMarineApiExample.Models;

public class UpdateTodoItemExample : IExamplesProvider<TodoItem>
{
    public TodoItem GetExamples()
    {
        return new TodoItem() 
        {
            Id = 1,
            Name = "Updated name",
            IsComplete = false 
        };
    }
}