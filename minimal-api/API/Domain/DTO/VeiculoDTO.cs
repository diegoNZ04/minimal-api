namespace MinimalApi.DTOs;

 public record VeiculoDTO
{
    public int Id { get; set; } = default!;
    public string Modelo { get; set; } = default!;
    public string Marca { get; set; } = default!;
    public int Ano { get; set; } = default!;
}
