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
}
