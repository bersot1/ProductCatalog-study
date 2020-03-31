using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models;
using ProductCatalog.ViewModels;
using ProductCatalog.ViewModels.CategoryViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.Repositories
{
    public class CategoryRepository
    {
        private readonly StoreDataContext _context;

        public CategoryRepository(StoreDataContext context)
        {
            _context = context;
        }

        public IEnumerable<ListCategoryViewModel> GetAll()
        {
            return _context.Categories
                .Include(x => x.Products)
                .Select(x => new ListCategoryViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Products = x.Products
                });
        }

        public Category GetById(Guid id)
        {
            return _context.Categories.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Product> GetAllProductsByCategory(Guid id)
        {
            return _context.Products.AsNoTracking().Where(x => x.Category.Id == id).ToList();
        }

        public void Post(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

        }

        public void Put(Category category)
        {
            _context.Entry<Category>(category).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();

        }
    }
}
