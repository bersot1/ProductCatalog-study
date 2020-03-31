using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.ViewModels.CategoryViewModels
{
    public class CreateCategoryViewModel: Notifiable, IValidatable
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .HasMaxLen(Title, 50, "Title", "O Titulo não deve ser maior que 120 caracteres")
                    .HasMinLen(Title, 3, "Title", "Titulo não pode ser menor que 3 caracteres")
                ); ;
        }

    }
}
