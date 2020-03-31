using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.ViewModels.ProductViewModels
{
    public class CreateProductViewModel: Notifiable, IValidatable
    {

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string Image { get; set; }

        public Guid CategoryId { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .HasMaxLen(Title, 120, "Title", "O Titulo não deve ser maior que 120 caracteres")
                    .HasMinLen(Title, 0, "Title", "Titulo é um campo obrigatório")
                    .IsGreaterThan(Price, 0, "Price", "O preço deve ser maior que 0,00")
                ); ;
        }
    }
}
