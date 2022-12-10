namespace Shared.DataTransferObjects;

public class PictureForCreationDto
{
    public int? Id { get; set; } = null;
    public string ImageDataUrl { get; set; } = null!;
    public bool MainImage { get; set; }
    public string? FileExtension { get; set; }
}
