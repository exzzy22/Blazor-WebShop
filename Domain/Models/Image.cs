namespace Domain.Models;

public class Image
{
    public int Id { get; set; }
    public string File { get; set; } = null!;
    public int ProductId { get; set; }
    public bool MainImage { get; set; }
}
