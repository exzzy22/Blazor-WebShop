﻿namespace ViewModels;

public class ImageForCreationVM
{
    public int? Id { get; set; } = null;
    public string ImageDataUrl { get; set; } = null!;
    public bool MainImage { get; set; } = false;
    public string FileExtension { get; set; } = null!;
}
