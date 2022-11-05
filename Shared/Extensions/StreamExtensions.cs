namespace Shared.Extensions;

public static class StreamExtensions
{
    public static async Task<string> ToImageDataURL(this IBrowserFile file)
    {
        Stream fs = file.OpenReadStream();
        string base64;

        using (var memoryStream = new MemoryStream())
        {
            await file.OpenReadStream().CopyToAsync(memoryStream);
            base64 = Convert.ToBase64String(memoryStream.ToArray());
        }

        return $"data:{file.ContentType};base64,{base64}";
    }
}
