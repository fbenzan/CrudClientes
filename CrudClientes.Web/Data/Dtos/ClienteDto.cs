using System.ComponentModel.DataAnnotations;

namespace CrudClientes.Web.Data.Dtos;

/// <summary>
/// DTO para la entidad Cliente.
/// </summary>
public class ClienteDto
{
    /// <summary>
    /// Identificador único del cliente.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nombre completo del cliente.
    /// </summary>
    [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
    [StringLength(100, ErrorMessage = "El Nombre no puede exceder los 100 caracteres.")]
    public string Nombre { get; set; } = null!;

    /// <summary>
    /// Correo electrónico del cliente.
    /// </summary>
    [Required(ErrorMessage = "El campo Email es obligatorio.")]
    [EmailAddress(ErrorMessage = "El Email no tiene un formato válido.")]
    [StringLength(100, ErrorMessage = "El Email no puede exceder los 100 caracteres.")]
    public string Email { get; set; } = null!;

    /// <summary>
    /// Teléfono de contacto del cliente.
    /// </summary>
    [Phone(ErrorMessage = "El Teléfono no tiene un formato válido.")]
    [StringLength(15, ErrorMessage = "El Teléfono no puede exceder los 15 caracteres.")]
    public string? Telefono { get; set; }

    /// <summary>
    /// Dirección del cliente.
    /// </summary>
    [StringLength(200, ErrorMessage = "La Dirección no puede exceder los 200 caracteres.")]
    public string? Direccion { get; set; }

    /// <summary>
    /// Fecha de creación del registro.
    /// </summary>
    public DateTime FechaCreacion { get; set; } = DateTime.Now;

    /// <summary>
    /// Indica si el cliente está activo.
    /// </summary>
    public bool Activo { get; set; } = true;
}

public record ClienteSimpleDto(int Id, string Nombre);
