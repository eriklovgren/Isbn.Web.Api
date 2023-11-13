using Isbn.Web.Api.Models;

namespace Isbn.Web.Api.Interfaces;

public interface IIsbn
{
    public IsbnValidationResult ValidateString();
    public IsbnValidationResult ValidateIsbn();
    public IsbnType Type { get; set; }
    public string IsbnString { get; set; }
}