using System.ComponentModel;
using Isbn.Web.Api.Interfaces;
using Isbn.Web.Api.Models;

namespace Isbn.Web.Api.Implementations;

public static class IsbnValidatorFactory
{
    public static IIsbn CreateValidator(IsbnType type, string isbnString)
    {
        return type switch
        {
            IsbnType.Isbn10 => new Isbn10(isbnString),
            IsbnType.Isbn13 => new Isbn13(isbnString),
            _ => throw new InvalidEnumArgumentException()
        };
    }
}