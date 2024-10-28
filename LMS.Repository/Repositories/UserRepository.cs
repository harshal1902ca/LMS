using Core.Repository;
using Core.Repository.Models;
using Core.Utility.Utils;
using LMS.Abstraction.ComplexModels;
using LMS.Abstraction.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.Repository.Contexts;
using LMS.Repository.Interfaces;
using LMS.Abstraction.Enums;

namespace LMS.Repository.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(LMSDbContext context)
            : base(context)
        { }

        private LMSDbContext LMSDbContext
        {
            get { return _dbContext as LMSDbContext; }
        }

        public async Task<PagedList> GetUserPaged(Pagination pagination)
        {
            string searchText = IsPropertyExist(pagination.Filters, "searchText") ? pagination.Filters?.searchText : null;

            IRepository<UserModel> repositoryUserModel = new Repository<UserModel>(LMSDbContext);
            var query = (from u in LMSDbContext.Users
                         where !u.IsDeleted &&
                         !u.IsAdmin && // Skip System Admin to List Anywhere
                         (string.IsNullOrEmpty(searchText) || (u.Email.Contains(searchText) ||
                         u.FirstName.Contains(searchText) || u.LastName.Contains(searchText) 
                          || u.MobileNo.Contains(searchText)
                         ))
                         select new UserModel()
                         {
                             UserId = u.UserId,
                             
                             FirstName = u.FirstName,
                             LastName = u.LastName,
                             Email = u.Email,
                             MobileNo = u.MobileNo
                         });

            return await repositoryUserModel.GetPagedReponseAsync(pagination, null, query);
        }
    }
}
