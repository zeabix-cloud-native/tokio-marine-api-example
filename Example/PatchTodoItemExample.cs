using Microsoft.AspNetCore.JsonPatch;
using Swashbuckle.AspNetCore.Filters;
using TokioMarineApiExample.Models;

public class JsonPatchDocumentExample : IExamplesProvider<JsonPatchDocument<TodoItem>>
{
    public JsonPatchDocument<TodoItem> GetExamples()
    {
        var patchDoc = new JsonPatchDocument<TodoItem>();
        patchDoc.Replace(e => e.Name, "Updated Name");
        return patchDoc;
    }
}