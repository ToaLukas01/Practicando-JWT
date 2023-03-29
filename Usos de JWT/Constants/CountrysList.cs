using Usos_de_JWT.Models;

namespace Usos_de_JWT.Constants
{
    public class CountrysList
    {
        public static List<Country> Countrys = new List<Country>()
        {
            new Country() { Name = "Peru" },
            new Country() { Name = "España" },
            new Country() { Name = "Kanada" }
        };
    }
}
