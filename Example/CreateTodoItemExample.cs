using Swashbuckle.AspNetCore.Filters;
using TokioMarineApiExample.Models;

public class CreateTodoItemExample : IExamplesProvider<CreateTodoItemDto>
{
    public CreateTodoItemDto GetExamples()
    {
        return new CreateTodoItemDto() 
        {
            Name = "John Doe",
            IsComplete = true
        };
    }
}