using Core.Repository.Models;
using LMS.Abstraction.ComplexModels;
using LMS.Abstraction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Service.Interfaces
{
    public interface IUserService
    {
        Task<ResponseModel> GetUserById(long id);
        Task<ResponseModel> GetUserByEmailId(string userEmailId);
        Task<ResponseModel> CreateUser(User entity);
        Task<ResponseModel> CreateUsers(List<User> entities);
        Task<ResponseModel> UpdateUser(User updateEntity);
        Task<ResponseModel> AuthenticateUser(LoginModel model);
    }
}
