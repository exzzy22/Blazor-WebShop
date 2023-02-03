namespace ViewModels;

public class ReviewVM
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string Description { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int StarRating { get; set; }
    public DateTime CreatedDate { get; set; }
}
