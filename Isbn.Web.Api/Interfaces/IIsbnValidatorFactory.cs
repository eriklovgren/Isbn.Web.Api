using Isbn.Web.Api.Models;

namespace Isbn.Web.Api.Interfaces;

public interface IIsbnValidatorFactory
{
    public IIsbn CreateValidator(IsbnType type, string isbnString);
}