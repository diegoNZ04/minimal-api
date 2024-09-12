using MinimalApi.Domain.Enuns;

namespace MinimalApi.Domain.ModelViews;
public record AdministradorModelView
{
    public int Id { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Perfil { get; set; } = default!;
}