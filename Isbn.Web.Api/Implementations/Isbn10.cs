using Isbn.Web.Api.Helpers;
using Isbn.Web.Api.Interfaces;
using Isbn.Web.Api.Models;

namespace Isbn.Web.Api.Implementations;

public class Isbn10 : IIsbn
{
    public Isbn10(string isbnString)
    {
        IsbnString = isbnString;
    }
    
    public IsbnType Type { get; set; } = IsbnType.Isbn10;
    public string IsbnString { get; set; }
    
    public IsbnValidationResult ValidateIsbn()
    {
        var multiplier = 10;
        var sum = 0;
        foreach (var c in IsbnString)
        {
            if (c is 'X' or 'x')
            {
                sum += 10 * multiplier;
            }
            else
            {
                sum += Convert.ToInt32(c.ToString()) * multiplier;
            }
            --multiplier;
        }

        if (sum % 11 == 0)
        {
            return new IsbnValidationResult
            {
                Valid = true
            };
        }

        return new IsbnValidationResult
        {
            Valid = false,
            Message = $"Not a valid {Type.ToString()} string"
        };
    }


    public IsbnValidationResult ValidateString()
    {
        var substring = IsbnString.Substring(0, IsbnString.Length - 1);

        var validString = substring.StringIsOnlyDigits();

        if (!validString)
        {
            return new IsbnValidationResult
            {
                Message = "String contains invalid characters",
                Valid = false
            };
        }
        
        var lastChar = IsbnString[^1];
        if (IsLastCharValid(lastChar))
        {
            return new IsbnValidationResult
            {
                Valid = true
            };
        }
        
        return new IsbnValidationResult
        {
            Message = "String contains invalid characters",
            Valid = false
        };
    }
    
    private bool IsLastCharValid(char character)
    {
        return char.IsDigit(character) || character == 'X' || character == 'x';
    }
}