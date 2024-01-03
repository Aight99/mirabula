using UnityEngine;

public enum Color
{
    Red,
    Yellow,
    Purple
}

public static class ColorExtensions
{
    public static string ToHex(this Color color)
    {
        switch (color)
        {
            case Color.Red:
                return "#b52240";
            case Color.Yellow:
                return "#ffb22e";
            case Color.Purple:
                return "#ab2eff";
            default:
                return "";
        }
    }
}


public static partial class Utils
{
    public static void Print(string text, Color? colorNullable = null)
    {
        if (colorNullable is Color color)
        {
            var colorString = $"<color={color.ToHex()}>{text}</color>";
            Debug.Log(colorString);
            return;
        }
        var NonColorString = $"{text}";
        Debug.Log(NonColorString);
    }

    public static void Print(string prefix, string text, Color? colorNullable = null)
    {
        if (colorNullable is Color color)
        {
            var colorString = $"<color={color}>{prefix}</color>\t{text}";
            Debug.Log(colorString);
            return;
        }
        var NonColorString = $"{prefix}{text}";
        Debug.Log(NonColorString);
    }
}