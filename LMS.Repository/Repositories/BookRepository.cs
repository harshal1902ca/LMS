using Core.Repository;
using Core.Repository.Models;
using Core.Utility.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.Abstraction.ComplexModels;
using LMS.Abstraction.Models;
using LMS.Repository.Contexts;
using LMS.Repository.Interfaces;
using Microsoft.OpenApi.Writers;
using LMS.Abstraction.Enums;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using System.Runtime.Intrinsics.Arm;

namespace LMS.Repository.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LMSDbContext context)
            : base(context)
        { }

        private LMSDbContext LMSDbContext
        {
            get { return _dbContext as LMSDbContext; }
        }

      
    }
}
