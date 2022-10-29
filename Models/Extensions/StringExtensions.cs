namespace SocialMedia.Models;


public static class StringExtensions {
    public static bool EqualsNoCase(this string value, string toCompare) => value?.ToLower() == toCompare?.ToLower();

    public static string TrimDescription(this string value) => value.Length > 150 ? $"{value.Substring(0, 147)}..." : value;
    

}