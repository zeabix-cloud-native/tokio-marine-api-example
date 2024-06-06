using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TokioMarinApiExample.Configuration;

namespace TokioMarineApiExample.Models;

public class BaseResponseDto<T> 
{
   public T data { get; set; }
   public MetaData meta_data { get; set; }
}