using CrudClientes.Web.Data.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CrudClientes.Web.Data.Entities;
[Table("Clientes")]
public class Cliente
{
    [Key]
    public int Id { get; set; }
    [Column(TypeName = "varchar(100)")]
    public string Nombre { get; set; } = null!;
    [Column(TypeName = "varchar(100)")]
    public string Email { get; set; } = null!;
    [Column(TypeName = "varchar(15)")]
    public string? Telefono { get; set; }

    [Column(TypeName = "varchar(200)")]
    public string? Direccion { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    public bool Activo { get; set; } = true;

    internal static Cliente Crear(ClienteDto clienteDto)
    => new()
    {
        Nombre = clienteDto.Nombre,
        Email = clienteDto.Email,
        Direccion = clienteDto.Direccion,
        Telefono = clienteDto.Telefono,
        FechaCreacion = DateTime.Now,
        Activo = clienteDto.Activo
    };

    internal bool Modificar(ClienteDto clienteDto)
    {
        var changed = false;
        if(Nombre != clienteDto.Nombre)
        {
            Nombre = clienteDto.Nombre;
            changed = true;
        }
        if (Telefono != clienteDto.Telefono)
        {
            Telefono = clienteDto.Telefono;
            changed = true;
        }
        if (Direccion != clienteDto.Direccion)
        {
            Direccion = clienteDto.Direccion;
            changed = true;
        }
        if (Email != clienteDto.Email)
        {
            Email = clienteDto.Email;
            changed = true;
        }
        if(Activo != clienteDto.Activo)
        {
            Activo = clienteDto.Activo;
            changed = true;
        }
        return changed;
    }

    internal ClienteDto ToDto()
    =>new ()
    {
        Id = Id,
        Nombre = Nombre,
        Email = Email,
        Direccion = Direccion,
        Telefono = Telefono,
        FechaCreacion = DateTime.Now,
        Activo = Activo
    };
}
