using Core.Repository.Models;
using Core.Security;
using Core.Utility.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.Abstraction.ComplexModels;
using LMS.Abstraction.Models;
using LMS.Repository.Interfaces;
using LMS.Service.Interfaces;
using LMS.Abstraction.Enums;
using System.Dynamic;
using LMS.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Service.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ITransactionService _transactionService;
        private readonly IUserProviderService _userProviderService;


        public BookService(
            IBookRepository bookRepository,
            IUserProviderService userProviderService,
            ITransactionService transactionService
        )
        {
            _bookRepository = bookRepository;
            _userProviderService = userProviderService;
            _transactionService = transactionService;
        }

        public async Task<ResponseModel> CreateBook(Book entity)
        {
            entity.CreatedBy = _userProviderService.UserClaim.Username;
            entity.UpdatedBy = _userProviderService.UserClaim.Username;
            CommonUtils.EncodeProperties(entity);
            await _bookRepository.AddAsync(entity);
            var result = await _bookRepository.SaveChangesAsync();
            if (result > 0)
            {
                return new ResponseModel
                {
                    Success = true,
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Book created successfully.",
                    Data = entity
                };
            }
            return new ResponseModel { Success = false, StatusCode = StatusCodes.Status500InternalServerError, Message = "Book does not created." };
        }
        public async Task<ResponseModel> DeleteBook(int id)
        {
            var entityResult = await GetBookById(id);

            if (!entityResult.Success) { return entityResult; }

            var entity = entityResult.Data as Book;
            //entity.UpdatedBy = _userProviderService.UserClaim.UserId;
            entity.IsDeleted = true;
            var result = await _bookRepository.SaveChangesAsync();

            if (result > 0)
            {
                return new ResponseModel
                {
                    Success = true,
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Book deleted successfully.",
                    Data = entity
                };
            }
            return new ResponseModel { Success = false, StatusCode = StatusCodes.Status500InternalServerError, Message = "Book does not deleted." };
        }
        public async Task<ResponseModel> GetAllBook(bool? isActive = null)
        {
            return new ResponseModel
            {
                Success = true,
                StatusCode = StatusCodes.Status200OK,
                Data = await _bookRepository.Find(a => a.IsDeleted == false && (!isActive.HasValue || a.IsActive == isActive))
            };
        }
        public async Task<ResponseModel> GetBookPaged(Pagination pagination)
        {
            return new ResponseModel
            {
                Success = true,
                StatusCode = StatusCodes.Status200OK,
                //Data = await _BookRepository.GetBookPaged(_userProviderService.UserClaim, pagination)
            };
        }

        public async Task<ResponseModel> GetBookById(int id)
        {
            var result = await _bookRepository.SingleOrDefaultAsync(a => a.BookId == id);
            if (result != null)
            {
                return new ResponseModel { Success = true, StatusCode = StatusCodes.Status200OK, Data = result };
            }
            else
            {
                return new ResponseModel { Success = false, StatusCode = StatusCodes.Status404NotFound, Message = "Book does not exists." };
            }
        }
        public async Task<ResponseModel> GetBookAquiredByUser()
        {
            var transaction = await _transactionService.GetAllUserTransaction(_userProviderService.UserClaim.UserId);
            var listTrans = transaction.Data as IList<Transaction>;

            var result = await _bookRepository.Find(a => listTrans.Select(a => a.BookId).Contains(a.BookId));
            if (result != null)
            {
                return new ResponseModel { Success = true, StatusCode = StatusCodes.Status200OK, Data = result };
            }
            else
            {
                return new ResponseModel { Success = false, StatusCode = StatusCodes.Status404NotFound, Message = "Book does not exists." };
            }
        }

        public async Task<ResponseModel> UpdateBook(Book updateEntity)
        {
            var entityResult = await GetBookById(updateEntity.BookId);

            if (!entityResult.Success) { return entityResult; }

            var entity = entityResult.Data as Book;

            entity.BookTitle = updateEntity.BookTitle;
            entity.BookAuthor = updateEntity.BookAuthor;
            entity.BookCategory = updateEntity.BookCategory;
            entity.BookCopies = updateEntity.BookCopies;
            entity.Status = updateEntity.Status;
            entity.UpdatedDate = CommonUtils.GetDefaultDateTime();
            entity.UpdatedBy = _userProviderService.UserClaim.Username;

            CommonUtils.EncodeProperties(entity);
            var result = await _bookRepository.SaveChangesAsync();

            if (result > 0)
            {
                return new ResponseModel
                {
                    Success = true,
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Book updated successfully.",
                    Data = entity
                };
            }
            return new ResponseModel { Success = false, StatusCode = StatusCodes.Status500InternalServerError, Message = "Book does not updated." };
        }
    }
}
