using ECommerceLabb.Models;

namespace ECommerceLabb.Services
{
    public class ProductStateService
    {
        public Product? SelectedProduct { get; private set; }

        public void SetSelectedProduct(Product product)
        {
            SelectedProduct = product;
        }
    }
}
