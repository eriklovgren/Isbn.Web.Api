using Isbn.Web.Api.Helpers;
using Isbn.Web.Api.Interfaces;
using Isbn.Web.Api.Models;

namespace Isbn.Web.Api.Implementations;

public class IsbnValidator : IIsbnValidator
{
    public IsbnValidationResult ValidateIsbn(string isbn)
    {
        var isbnType = isbn.GetIsbnTypeFromString();

        var validator = IsbnValidatorFactory.CreateValidator(isbnType, isbn);

        var validStringResult = validator.ValidateString();
        
        if (!validStringResult.Valid)
        {
            return validStringResult;
        }
        
        var validatedIsbn = validator.ValidateIsbn();

        if (!validatedIsbn.Valid)
        {
            return validatedIsbn;
        }

        return new IsbnValidationResult
        {
            Valid = true,
            Message = $"String is valid {isbnType.ToString()}"
        };
    }
}