namespace Anitext.Domain.Models;

public class Post
{
    public Guid Id { get; set; }
    public string Text { get; set; } = default!;
}
