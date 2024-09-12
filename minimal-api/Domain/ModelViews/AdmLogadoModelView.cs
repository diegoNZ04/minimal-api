using MinimalApi.Domain.Enuns;

namespace MinimalApi.Domain.ModelViews;

public record AdmLogadoModelView
{
    public string Email { get; set; } = default!;
    public string Perfil { get; set; } = default!;
    public string Token { get; set; } = default!;
}