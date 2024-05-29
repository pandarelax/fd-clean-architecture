﻿namespace Todo_App.Domain.ValueObjects;

public class Colour : ValueObject
{
    static Colour()
    {
    }

    private Colour()
    {
    }

    private Colour(string code)
    {
        Code = code;
    }

    public static Colour From(string? code)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            return White;
        }

        var colour = new Colour { Code = code };

        if (!SupportedColours.Contains(colour))
        {
            throw new UnsupportedColourException(code);
        }

        return colour;
    }

    public string GetName()
    {
        switch (Code)
        {
            case "#FFFFFF":
                return "White";
            case "#FF5733":
                return "Red";
            case "#FFC300":
                return "Orange";
            case "#FFFF66":
                return "Yellow";
            case "#CCFF99 ":
                return "Green";
            case "#6666FF":
                return "Blue";
            case "#9966CC":
                return "Purple";
            case "#999999":
                return "Grey";
            default:
                return "Unknown";
        }
    }

    public static Colour White => new("#FFFFFF");

    public static Colour Red => new("#FF5733");

    public static Colour Orange => new("#FFC300");

    public static Colour Yellow => new("#FFFF66");

    public static Colour Green => new("#CCFF99 ");

    public static Colour Blue => new("#6666FF");

    public static Colour Purple => new("#9966CC");

    public static Colour Grey => new("#999999");

    public string Code { get; private set; } = "#000000";

    public static implicit operator string(Colour colour)
    {
        return colour.ToString();
    }

    public static explicit operator Colour(string code)
    {
        return From(code);
    }

    public override string ToString()
    {
        return Code;
    }

    public static IEnumerable<Colour> SupportedColours
    {
        get
        {
            yield return White;
            yield return Red;
            yield return Orange;
            yield return Yellow;
            yield return Green;
            yield return Blue;
            yield return Purple;
            yield return Grey;
        }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
    }
}
