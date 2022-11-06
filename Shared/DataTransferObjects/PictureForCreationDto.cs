namespace Shared.DataTransferObjects;

public record PictureForCreationDto()
{
    public string ImageDataUrl { get; set; }
    public bool MainImage { get; init; }
    public string FileExtension { get; init; }
}
