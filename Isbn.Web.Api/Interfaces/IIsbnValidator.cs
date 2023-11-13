using Isbn.Web.Api.Models;

namespace Isbn.Web.Api.Interfaces;

public interface IIsbnValidator
{
    public IsbnValidationResult ValidateIsbn(string isbn);
}