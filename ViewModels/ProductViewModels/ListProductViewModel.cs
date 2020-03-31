using System;

namespace ProductCatalog.ViewModels.ProductViewModels
{
    public class ListProductViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string Image { get; set; }

        public Guid CategoryId { get; set; }


    }
}
