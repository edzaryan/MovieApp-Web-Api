

public static class CustomStringExtensions
{
    public static string Capitalize(this string s)
    {
        return s[0].ToString().ToUpper() + s.Substring(1);
    }


    public static string RegulateSpaces(this string s)
    {
        return Regex.Replace(s, @"\s+", " ");
    }

}