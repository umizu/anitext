using Anitext.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Anitext.Api.Controller.V2;

[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    [HttpGet("{id:int}")]
    public IActionResult GetById(string id)
    {
        var post = new Post
        {
            Id = Guid.NewGuid(),
            Text = $"hi from posts v2: {id}"
        };

        return Ok(post);
    }
}
