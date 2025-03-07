namespace SimoshStore;

public class BlogDTO
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public int userId { get; set; }
    public bool Enabled { get; set; } = true;
}