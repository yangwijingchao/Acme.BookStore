using Acme.BookStore.Application.Contracts.Books;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Acme.BookStore.Web.Pages.Books
{
    [IgnoreAntiforgeryToken]
    public class CreateModalModel : BookStorePageModel
    {
        public CreateModalModel(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        [BindProperty]
        public CreateUpdateBookDto Book { get; set; }
        private readonly IBookAppService _bookAppService;
        public void OnGet()
        {
            Book=new CreateUpdateBookDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _bookAppService.CreateAsync(Book);
            return NoContent();
        }
    }
}
