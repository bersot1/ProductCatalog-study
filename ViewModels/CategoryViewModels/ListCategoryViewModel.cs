using ProductCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.ViewModels.CategoryViewModels
{
    public class ListCategoryViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
