using Isbn.Web.Api.Implementations;
using Isbn.Web.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Isbn.Web.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class IsbnController : ControllerBase
{
    private readonly ILogger<IsbnController> _logger;
    private readonly IIsbnValidator _isbnValidator;

    public IsbnController(ILogger<IsbnController> logger, IIsbnValidator isbnValidator)
    {
        _logger = logger;
        _isbnValidator = isbnValidator;
    }

    [HttpPost("[action]")]
    public IActionResult Validate(string input)
    {
        var validatedIsbn = _isbnValidator.ValidateIsbn(input);

        if (validatedIsbn.Valid)
        {
            return Ok(validatedIsbn.Message);
        }

        return BadRequest(validatedIsbn.Message);
    }
}