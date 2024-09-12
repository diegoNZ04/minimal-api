using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Entities;
using MinimalApi.Domain.Interfaces;
using MinimalApi.Infrastructure.Db;
using MinimalApi.DTOs;

namespace MinimalApi.Domain.Services;

public class VeiculoService : IVeiculoService
{
    private readonly DbContexto _contexto;
   
    public VeiculoService(DbContexto contexto)
    {
        _contexto = contexto;
    }
    
    public List<Veiculo> Todos(int? pagina = 1, string? modelo = null, string? marca = null)
    {
        var query = _contexto.Veiculos.AsQueryable();
        if(!string.IsNullOrEmpty(modelo))
        {
            query = query.Where(v => EF.Functions.Like(v.Modelo.ToLower(), $"%{modelo.ToLower()}%"));
        }

        int itensPorPagina = 10;

        if(pagina != null)
        {
            query = query.Skip(((int)pagina - 1) * itensPorPagina).Take(itensPorPagina);
        }
       
        
        return query.ToList();
    }
    
    public Veiculo? BuscaPorId(int id)
    {
        return _contexto.Veiculos.Where(v => v.Id == id).FirstOrDefault();
    }

    public void Incluir(Veiculo veiculo)
    {
        _contexto.Veiculos.Add(veiculo);
        _contexto.SaveChanges();
    }

    public void Atualizar(Veiculo veiculo)
    {
        _contexto.Veiculos.Update(veiculo);
        _contexto.SaveChanges();
    }

    public void Apagar(Veiculo veiculo)
    {
        _contexto.Veiculos.Remove(veiculo);
        _contexto.SaveChanges();
    }
}