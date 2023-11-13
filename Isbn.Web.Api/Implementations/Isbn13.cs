using Isbn.Web.Api.Helpers;
using Isbn.Web.Api.Interfaces;
using Isbn.Web.Api.Models;

namespace Isbn.Web.Api.Implementations;

public class Isbn13 : IIsbn
{
    public IsbnType Type { get; set; } = IsbnType.Isbn13;
    public string IsbnString { get; set; }

    public Isbn13(string isbnString)
    {
        IsbnString = isbnString;
    }
    
    
    public IsbnValidationResult ValidateIsbn()
    {
        var index = 1;
        var sum = 0;
        foreach (var c in IsbnString)
        {
            var even = index % 2 == 0;

            var digit = int.Parse(c.ToString());

            sum += even ? digit * 3 : digit;
            ++index;
        }

        if (sum % 10 == 0)
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
        var validString = IsbnString.StringIsOnlyDigits();
        
        if (validString)
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
}