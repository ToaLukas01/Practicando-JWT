using Usos_de_JWT.Models;

namespace Usos_de_JWT.Constants
{
    public class UserList
    {
        public static List<User> Users = new List<User>()
        {
            new User() { Username = "Juanchi", 
                         Password = "junachi1", 
                         Rol = "Administrador",
                         Email = "juan@gmail.com",
                         FirstName = "Juan",
                         LastName = "Perez"
                       },
            new User() { Username = "Manuelita",
                         Password = "Manuelita1",
                         Rol = "Vendedor",
                         Email = "manuela@gmail.com",
                         FirstName = "Manuela",
                         LastName = "Perez"
                       }
        };
    }
}
