using System.Text.RegularExpressions;

namespace Shared.Extensions;

public static class StringExtensions
{
    public static string SaveDataUrlToFile(this string dataUrl, string savePath)
    {
        GroupCollection matchGroups = Regex.Match(dataUrl, @"^data:((?<type>[\w\/]+))?;base64,(?<data>.+)$").Groups;
        string base64Data = matchGroups["data"].Value;
        byte[] binData = Convert.FromBase64String(base64Data);
        File.WriteAllBytes(savePath, binData);
        return Path.GetFileName(savePath);
    }
}
