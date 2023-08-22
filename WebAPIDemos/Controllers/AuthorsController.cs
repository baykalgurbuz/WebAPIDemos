using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemos.Controllers.Data.Services;
using WebAPIDemos.Controllers.Data.ViewModels;

namespace WebAPIDemos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private AuthorService _authorService;

        public AuthorsController(AuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorService.AddAuthor(author);
            return Ok();
        }
        [HttpGet("get-author-with-books-by-id")]
        public IActionResult GetAuthorWithBook(int id)
        {
           var response = _authorService.GetAuthorWithBooks(id);
            return Ok(response);
        }
    }
}
