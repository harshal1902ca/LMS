using Core.Repository.Models;
using Core.Security;
using Core.Utility.Utils;
using LMS.Abstraction.ComplexModels;
using LMS.Abstraction.Models;
using LMS.Repository.Contexts;
using LMS.Repository.Interfaces;
using LMS.Repository.Repositories;
using LMS.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly ITokenBuilder _tokenBuilder;
        private readonly IUserProviderService _userProviderService;
        //private readonly IUserLoginService _userLoginService;

        public UserService(
            IConfiguration configuration,
            ITokenBuilder tokenBuilder,
            IUserRepository userRepository,
            //IUserLoginService userLoginService,
            IUserProviderService userProviderService
        )
        {
            _configuration = configuration;
            _tokenBuilder = tokenBuilder;
            _userRepository = userRepository;
            //_userLoginService = userLoginService;
            _userProviderService = userProviderService;
        }

        public async Task<ResponseModel> CreateUser(User entity)
        {
            
            if (true)
            {
                return new ResponseModel
                {
                    Success = false,
                    StatusCode = StatusCodes.Status409Conflict,
                    Message = "User email already exists.",
                };
            }

            entity.CreatedBy = _userProviderService.UserClaim.Username;
            entity.UpdatedBy = _userProviderService.UserClaim.Username;


            CommonUtils.EncodeProperties(entity);
            await _userRepository.AddAsync(entity);
            var result = await _userRepository.SaveChangesAsync();
            if (result > 0)
            {
                return new ResponseModel
                {
                    Success = true,
                    StatusCode = StatusCodes.Status200OK,
                    Message = "User created successfully.",
                    Data = entity
                };
            }
            return new ResponseModel { Success = false, StatusCode = StatusCodes.Status500InternalServerError, Message = "User does not created." };
        }

        public async Task<ResponseModel> CreateUsers(List<User> entities)
        {
            foreach (var entity in entities)
            {
                entity.CreatedBy = _userProviderService.UserClaim.Username;
                entity.UpdatedBy = _userProviderService.UserClaim.Username;
                CommonUtils.EncodeProperties(entity);
                await _userRepository.AddAsync(entity);
            }
            var result = await _userRepository.SaveChangesAsync();
            if (result > 0)
            {
                return new ResponseModel
                {
                    Success = true,
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Users created successfully."
                };
            }
            return new ResponseModel { Success = false, StatusCode = StatusCodes.Status500InternalServerError, Message = "Users does not created." };
        }

        public async Task<ResponseModel> GetUserById(long id)
        {
            var result = await _userRepository.SingleOrDefaultAsync(a => a.UserId == id);
            if (result != null)
            {
                return new ResponseModel { Success = true, StatusCode = StatusCodes.Status200OK, Data = result };
            }
            else
            {
                return new ResponseModel { Success = false, StatusCode = StatusCodes.Status404NotFound, Message = "User does not exists." };
            }
        }

        public async Task<ResponseModel> GetUserByEmailId(string userEmailId)
        {
            var result = await _userRepository.SingleOrDefaultAsync(a => a.Email.ToLower().Trim() == userEmailId.ToLower().Trim());

            if (result != null)
            {
                return new ResponseModel { Success = true, StatusCode = StatusCodes.Status200OK, Data = result };
            }
            else
            {
                return new ResponseModel { Success = false, StatusCode = StatusCodes.Status404NotFound, Message = "User does not exists." };
            }
        }

        public async Task<ResponseModel> UpdateUser(User updateEntity)
        {
            var entityResult = await GetUserById(updateEntity.UserId);

            if (!entityResult.Success) { return entityResult; }

            var entity = entityResult.Data as User;
            entity.Email = updateEntity.Email;
            entity.FirstName = updateEntity.FirstName;
            entity.LastName = updateEntity.LastName;
            entity.MobileNo = updateEntity.MobileNo;
            entity.UpdatedDate = CommonUtils.GetDefaultDateTime();
            entity.UpdatedBy = _userProviderService.UserClaim.Username;

            CommonUtils.EncodeProperties(entity);
            var result = await _userRepository.SaveChangesAsync();

            if (result > 0)
            {
                return new ResponseModel
                {
                    Success = true,
                    StatusCode = StatusCodes.Status200OK,
                    Message = "User updated successfully.",
                    Data = entity
                };
            }
            return new ResponseModel { Success = false, StatusCode = StatusCodes.Status500InternalServerError, Message = "User does not updated." };
        }

        public async Task<ResponseModel> AuthenticateUser(LoginModel model)
        {
            ResponseModel entityResult = await AuthenticateSystemUser(model);
            if (!entityResult.Success) { return entityResult; }

            var user = entityResult.Data as User;
            return new ResponseModel
            {
                Success = true,
                StatusCode = StatusCodes.Status200OK,
                Message = "User Login successfully.",
                Data = user
            };
        }

        private async Task<ResponseModel> AuthenticateSystemUser(LoginModel model)
        {
            var entityResult = await GetUserByEmailId(model.UserEmail);

            if (!entityResult.Success) { return entityResult; }

            var entity = entityResult.Data as User;

            if (entity.IsDeleted)
            {
                return new ResponseModel { Success = false, StatusCode = StatusCodes.Status404NotFound, Message = "User does not exists." };
            }
            if (!entity.IsActive)
            {
                return new ResponseModel { Success = false, StatusCode = StatusCodes.Status405MethodNotAllowed, Message = "User does not active." };
            }

            var hash = PasswordUtility.GenerateHash(model.Password, entity.Salt);
            if (hash != entity.Password)
            {
                return new ResponseModel { Success = false, StatusCode = StatusCodes.Status406NotAcceptable, Message = "Password did not match." };
            }

            return new ResponseModel
            {
                Success = true,
                StatusCode = StatusCodes.Status200OK,
                Message = "User Login successfully.",
                Data = entity
            };
        }
    }
}
