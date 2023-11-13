using System.ComponentModel;
using Isbn.Web.Api.Exceptions;
using Isbn.Web.Api.Models;

namespace Isbn.Web.Api.Helpers;

public static class Helper
{
    public static IsbnType GetIsbnTypeFromString(this string isbn)
    {
        var length = isbn.Length;

        return length switch
        {
            10 => IsbnType.Isbn10,
            13 => IsbnType.Isbn13,
            _ => throw new IsbnException("Invalid length of a ISBN string")
        };
    }

    public static bool StringIsOnlyDigits(this string isbnString)
    {
        if (string.IsNullOrEmpty(isbnString))
        {
            return false;
        }
        return isbnString.All(char.IsDigit);
    }
}