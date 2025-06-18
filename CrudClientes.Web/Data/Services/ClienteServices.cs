using CrudClientes.Web.Data.Context;
using CrudClientes.Web.Data.Dtos;
using CrudClientes.Web.Data.Entities;

namespace CrudClientes.Web.Data.Services
{
    public class ClienteServices(ApplicationDbContext db)
    {
        //Crear, Modificar, Eliminar, Consultar utilizando db como 
        public bool Crear(ClienteDto clienteDto) {
            Cliente clienteDb = Cliente.Crear(clienteDto);
            db.Clientes.Add(clienteDb);
            return db.SaveChanges() > 0;
        }
    }
}
