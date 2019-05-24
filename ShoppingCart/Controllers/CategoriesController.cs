using AutoMapper;
using ShoppingCart.Models;
using ShoppingCart.Services;
using ShoppingCart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class CategoriesController : Controller
    {

        private readonly CategoryService _categoryService = new CategoryService();
        private IMapper mapper;

        [ChildActionOnly]
        public PartialViewResult Menu(int selectedCategoryId)
        {
            var categories = _categoryService.Get();


            mapper = new MapperConfiguration(cfg => {

                cfg.CreateMap<Category, CategoryViewModel>();
            }).CreateMapper();

            ViewBag.SelectedCategoryId = selectedCategoryId;

            return PartialView(mapper.Map<List<Category>, List<CategoryViewModel>>(categories));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _categoryService.Dispose();

            base.Dispose(disposing);
        }
    }
}