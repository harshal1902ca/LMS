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
    public interface IBookService
    {
        Task<ResponseModel> GetBookById(int id);
        Task<ResponseModel> GetAllBook(bool? isActive = null);
        Task<ResponseModel> GetBookAquiredByUser();
        Task<ResponseModel> GetBookPaged(Pagination pagination);
        Task<ResponseModel> CreateBook(Book entity);
        Task<ResponseModel> UpdateBook(Book updateEntity);
        Task<ResponseModel> DeleteBook(int id);
        
    }
}
