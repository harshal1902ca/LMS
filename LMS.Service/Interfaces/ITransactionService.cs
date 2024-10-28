using Core.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.Abstraction.ComplexModels;
using LMS.Abstraction.Models;

namespace LMS.Service.Interfaces
{
    public interface ITransactionService
    {
        Task<ResponseModel> GetTransactionById(long id);
        Task<ResponseModel> GetAllUserTransaction(int userId);
        Task<ResponseModel> GetTransactionPaged(Pagination pagination);
        Task<ResponseModel> CreateTransaction(Transaction entity);
        
    }
}
