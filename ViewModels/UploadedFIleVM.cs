using Microsoft.AspNetCore.Components.Forms;

namespace ViewModels;

public class UploadedFIleVM
{
    public IBrowserFile? File { get; set; }
    public ImageForCreationVM PictureForCreationVM { get; set; } = null!;
}
