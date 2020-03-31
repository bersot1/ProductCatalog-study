using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductCatalog.Data;
using ProductCatalog.Models;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.ViewModels;
using ProductCatalog.ViewModels.ProductViewModels;
using ProductCatalog.ViewModels.CategoryViewModels;
using ProductCatalog.Repositories;

namespace ProductCatalog.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryRepository _repository;

        public CategoryController(CategoryRepository repository)
        {
            _repository = repository;
        }

        [Route("v1/categories")]
        [HttpGet]
        public IEnumerable<ListCategoryViewModel> GetAll()
        {
            return _repository.GetAll();
        }

        [Route("v1/categories/{id}")]
        [HttpGet]
        public Category GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        [Route("v1/categories/{id}/products")]
        [HttpGet]
        public IEnumerable<Product> GetAllProductsByCategory(Guid id)
        {
            return _repository.GetAllProductsByCategory(id);
        }

        [Route("v1/categories")]
        [HttpPost]
        public ResultViewModel Post([FromBody]CreateCategoryViewModel model)
        {
            model.Validate();
            if (model.Invalid)
            {
                return new ResultViewModel
                {
                    Sucess = false,
                    Message = "Não foi possivel cadastrar a categoria",
                    Data = model.Notifications
                };
            }


            var category = new Category();
            category.Title = model.Title;

            _repository.Post(category);

            return new ResultViewModel
            {
                Sucess = true,
                Message = "Categoria criada com sucesso",
                Data = category
            };

            
        }

        [Route("v1/categories")]
        [HttpPut]
        public Category Put([FromBody]Category category)
        {
            _repository.Put(category);

            return category;
        }


        [Route("v1/categories")]
        [HttpDelete]
        public Category Delete([FromBody]Category category)
        {
            _repository.Delete(category);

            return category;
        }
    }
}
