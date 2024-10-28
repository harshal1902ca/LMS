using LMS.Abstraction.ComplexModels;
using LMS.Abstraction.Models;
using LMS.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Web.Controllers
{
    public class BookController : BaseController
    {
        private readonly IBookService _bookService;
        private readonly IUserProviderService _userProviderService;
        private readonly IUserService _userService;
        private readonly ITransactionService _transactionService;


        public BookController(
            IBookService bookService,
            IUserProviderService userProviderService,
            IUserService userService,
            ITransactionService transactionService

        )
        {
            _bookService = bookService;
            _userProviderService = userProviderService;
            _userService = userService;
            _transactionService = transactionService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.IsAdmin = _userProviderService.UserClaim.IsAdmin;
            return View();
        }
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAllBook(isActive: true);
            return Json(new { data = books.Data });
        }

        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookService.GetBookById(id);
            return View(book.Data);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(include: "BookId,BookTitle,BookCategory,BookAuthor,BookCopies,BookPub,BookPubName,BookISBN,Copyright,DateAdded,Status")] Book book)
        {
            if (ModelState.IsValid)
            {
                await _bookService.CreateBook(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public ActionResult OperationAlert()
        {
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.GetBookById(id);
            return View(book.Data);
        }
        public async Task<IActionResult> Aquired()
        {
            ViewBag.IsAdmin = _userProviderService.UserClaim.IsAdmin;
            return View();
        }
        public async Task<IActionResult> AquiredBook()
        {
            var books = await _bookService.GetBookAquiredByUser();
            return Json(new { data = books.Data });

        }
        public async Task<IActionResult> Aquire(int id)
        {
            var bookResult = await _bookService.GetBookById(id);
            var book = bookResult.Data as Book;
            if (book != null && book.BookCopies > 0)
            {
                book.BookCopies = book.BookCopies - 1;

                var transaction = await _transactionService.CreateTransaction(
                    new Transaction() { BookId = book.BookId, TransactionDate = DateTime.Now }
                    );
                if (transaction.Success)
                {
                    await _bookService.UpdateBook(book);
                }
                return RedirectToAction("Aquired");
            }

            else
            {
                return View(new ResponseModel
                {
                    Success = false,
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Book not available"
                });
            }
        }

        // POST: tblBooks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind(include: "BookId,BookTitle,BookCategory,BookAuthor,BookCopies,BookPub,BookPubName,BookISBN,Copyright,DateAdded,Status")] Book book)
        {
            if (ModelState.IsValid)
            {
                //Session["operationMsg"] = "Book updated successfully";
                await _bookService.UpdateBook(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: tblBooks/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var request = await _bookService.GetBookById(id);
            if (request.Success)
            {
                return View(request.Data);
            }
            return View(request.Data);
        }

        //POST: tblBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var request = await _bookService.DeleteBook(id);
            if (!request.Success)
            {
                return View(request.Data);
            }

            return RedirectToAction("Index");
        }
    }
}