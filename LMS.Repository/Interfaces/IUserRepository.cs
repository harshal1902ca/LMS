using Core.Repository;
using Core.Repository.Models;
using LMS.Abstraction.ComplexModels;
using LMS.Abstraction.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<PagedList> GetUserPaged(Pagination pagination);
    }
}
