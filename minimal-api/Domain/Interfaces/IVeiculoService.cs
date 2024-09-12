using MinimalApi.Domain.Entities;
using MinimalApi.DTOs;

namespace MinimalApi.Domain.Interfaces;

public interface IVeiculoService
{
    List<Veiculo> Todos(int? pagina = 1, string? modelo = null, string? marca = null);
    
    Veiculo? BuscaPorId(int id);

    void Incluir(Veiculo veiculo);

    void Atualizar(Veiculo veiculo);

    void Apagar(Veiculo veiculo);
}