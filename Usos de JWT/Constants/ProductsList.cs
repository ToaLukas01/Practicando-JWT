using Usos_de_JWT.Models;

namespace Usos_de_JWT.Constants
{
    public class ProductsList
    {
        public static List<Product> Products = new List<Product>()
        {
            new Product() { Name = "Telefono" },
            new Product() { Name = "Celular" },
            new Product() { Name = "Iphon" }
        };
    }
}
