using Microsoft.AspNetCore.Components.Forms;

namespace ViewModels;

public class UploadedFIleVM
{
    public IBrowserFile? File { get; set; }
    public PictureForCreationVM PictureForCreationVM { get; set; } = null!;
}
