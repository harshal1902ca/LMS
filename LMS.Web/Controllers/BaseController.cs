using Core.Repository.Models;
using LMS.Abstraction.ComplexModels;
using LMS.Abstraction.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace LMS.Web.Controllers
{
    [ResponseCache(Location = ResponseCacheLocation.None, Duration = 0, NoStore = true)]
    [Authorize]
    public class BaseController : Controller
    {
        protected ActionResult AccessDeniedView()
        {
            return RedirectToAction("NotFound", "Error");
        }

        public dynamic GetGridPagination(dynamic filters)
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int currentPage = skip / Convert.ToInt32(length) + 1;

            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            filters.searchText = searchValue;

            return new
            {
                draw,
                pagination = new Pagination
                {
                    PageNumber = currentPage,
                    PageSize = pageSize,
                    SortOrderBy = sortColumnDirection,
                    SortOrderColumn = sortColumn,
                    Filters = filters
                }
            };
        }
    }
}
