using CrudClientes.Web.Data.Context;
using CrudClientes.Web.Data.Dtos;
using CrudClientes.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudClientes.Web.Data.Services;

public interface IClienteServices
{
    List<ClienteDto> Consultar(string filtro, bool solo_activos = true);
    bool Crear(ClienteDto clienteDto);
    (bool success, string message) Eliminar(int Id);
    (bool success, string message) Modificar(ClienteDto clienteDto);
}

public class ClienteServices(ApplicationDbContext db) : IClienteServices
{
    public bool Crear(ClienteDto clienteDto)
    {
        Cliente clienteDb = Cliente.Crear(clienteDto);
        db.Clientes.Add(clienteDb);
        var registrado = db.SaveChanges() > 0;
        var id = clienteDb.Id;
        return registrado;
    }
    public (bool success, string message) Modificar(ClienteDto clienteDto)
    {
        var clienteDb = db.Clientes
            .Where(c => c.Id == clienteDto.Id)
            .FirstOrDefault();
        if (clienteDb == null)
            return (false, "El cliente no existe");

        bool se_cambio_algo = clienteDb.Modificar(clienteDto);
        if (!se_cambio_algo)
            return (false, "No se realizó ningún cambio.");

        var registrado = db.SaveChanges() > 0;
        if (!registrado)
            return (registrado, "No se pudo registrar el cambio.");

        return (true, "Se modificó exitosamente");
    }
    public (bool success, string message) Eliminar(int Id)
    {
        var clienteDb = db.Clientes
            .Where(c => c.Id == Id)
            .FirstOrDefault();
        if (clienteDb == null)
            return (false, "El cliente no existe");

        db.Clientes.Remove(clienteDb);

        var registrado = db.SaveChanges() > 0;
        if (!registrado)
            return (registrado, "No se pudo eliminar el cliente.");

        return (true, "Se eliminó exitosamente");
    }
    public List<ClienteDto> Consultar(string filtro, bool solo_activos = true)
    {
        var clientesQuery = db.Clientes
            .AsNoTracking()
            .Where(c =>
            c.Nombre.Contains(filtro) ||
            (c.Telefono != null && c.Telefono.Contains(filtro)) ||
            (c.Direccion != null && c.Direccion.Contains(filtro)) ||
            c.Email.Contains(filtro)
            );
        if (solo_activos)
        {
            clientesQuery = clientesQuery.Where(c => c.Activo == true);
        }
        var clientes = clientesQuery
            .Select(c => c.ToDto())
            .ToList();
        return clientes;
    }
}
