namespace SimoshStoreAPI;

public class ProductCommentDTO
{
    public string Text { get; set; } = null!;
    public int StarCount { get; set; }
    public bool IsConfirmed { get; set; }
}
