using Usos_de_JWT.Models;

namespace Usos_de_JWT.Constants
{
    public class EmplyerList
    {
        public static List<Employer> Employers = new List<Employer>()
        {
            new Employer() {Name = "Mariano", Position = "vendedor", Email = "mariano@gmail.com" },
            new Employer() {Name = "Gorge", Position = "vendedor", Email = "gorge@gmail.com" },
            new Employer() {Name = "Fernando", Position = "vendedor", Email = "fernando@gmail.com" },
        };
    }
}
