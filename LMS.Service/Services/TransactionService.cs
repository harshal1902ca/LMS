using Core.Repository.Models;
using Core.Utility.Utils;
using LMS.Abstraction.ComplexModels;
using LMS.Abstraction.Enums;
using LMS.Abstraction.Models;
using LMS.Repository.Interfaces;
using LMS.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Service.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _TransactionRepository;
        private readonly IUserProviderService _userProviderService;
        private readonly IUserService _userService;



        public TransactionService(
            ITransactionRepository TransactionRepository,
            IUserProviderService userProviderService,
            IUserService userService

        )
        {
            _TransactionRepository = TransactionRepository;
            _userProviderService = userProviderService;
            _userService = userService;
        }

        public async Task<ResponseModel> CreateTransaction(Transaction entity)
        {
            var bookAlready = await _TransactionRepository.Find(a => a.TransactionStatus == TransactionStatuses.Aquired.ToString() && a.BookId == entity.BookId);
            if (bookAlready.Any())
            {
                return new ResponseModel
                {
                    Success = false,
                    StatusCode = StatusCodes.Status406NotAcceptable,
                    Message = "You already have this book.",
                    Data = entity
                };

            }
            entity.CreatedBy = _userProviderService.UserClaim.Username;
            entity.UpdatedBy = _userProviderService.UserClaim.Username;
            entity.UserId = _userProviderService.UserClaim.UserId;
            entity.TransactionStatus = TransactionStatuses.Aquired.ToString();
            CommonUtils.EncodeProperties(entity);
            await _TransactionRepository.AddAsync(entity);
            var result = await _TransactionRepository.SaveChangesAsync();
            if (result > 0)
            {
                return new ResponseModel
                {
                    Success = true,
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Transaction created successfully.",
                    Data = entity
                };
            }
            return new ResponseModel { Success = false, StatusCode = StatusCodes.Status500InternalServerError, Message = "Transaction does not created." };
        }

        public async Task<ResponseModel> DeleteTransaction(long id)
        {
            var entityResult = await GetTransactionById(id);

            if (!entityResult.Success) { return entityResult; }

            var entity = entityResult.Data as Transaction;
            //entity.UpdatedBy = _userProviderService.UserClaim.UserId;
            entity.IsDeleted = true;
            var result = await _TransactionRepository.SaveChangesAsync();

            if (result > 0)
            {
                return new ResponseModel
                {
                    Success = true,
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Transaction deleted successfully.",
                    Data = entity
                };
            }
            return new ResponseModel { Success = false, StatusCode = StatusCodes.Status500InternalServerError, Message = "Transaction does not deleted." };
        }

        public async Task<ResponseModel> GetAllTransaction(bool? isActive = null)
        {
            return new ResponseModel
            {
                Success = true,
                StatusCode = StatusCodes.Status200OK,
                Data = await _TransactionRepository.Find(a => a.IsDeleted == false && (!isActive.HasValue || a.IsActive == isActive))
            };
        }
        public async Task<ResponseModel> GetAllUserTransaction(int userId)
        {
            return new ResponseModel
            {
                Success = true,
                StatusCode = StatusCodes.Status200OK,
                Data = await _TransactionRepository.Find(a => a.IsDeleted == false && a.UserId == userId)
            };
        }

        public async Task<ResponseModel> GetTransactionPaged(Pagination pagination)
        {
            return new ResponseModel
            {
                Success = true,
                StatusCode = StatusCodes.Status200OK,
                //Data = await _TransactionRepository.GetTransactionPaged(_userProviderService.UserClaim, pagination)
            };
        }

        public async Task<ResponseModel> GetTransactionById(long id)
        {
            //var result = await _TransactionRepository.SingleOrDefaultAsync(a => a.TransactionId == id, b => b.Users);
            var result = new Transaction();
            if (result != null)
            {
                return new ResponseModel { Success = true, StatusCode = StatusCodes.Status200OK, Data = result };
            }
            else
            {
                return new ResponseModel { Success = false, StatusCode = StatusCodes.Status404NotFound, Message = "Transaction does not exists." };
            }
        }

    }
}
