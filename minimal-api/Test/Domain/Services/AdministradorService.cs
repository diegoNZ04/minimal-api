using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MinimalApi.Domain.Entities;
using MinimalApi.Domain.Services;
using MinimalApi.Infrastructure.Db;

namespace Test.Domain.Services;

[TestClass]
public class AdministradorServiceTest
{
    private DbContexto CriarContextoDeTeste()
    {
        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = Path.GetFullPath(Path.Combine(assemblyPath ??"", "..", "..", ".."));
        
        // configurar builder
        var builder = new ConfigurationBuilder()
            .SetBasePath(path ?? Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        var configuration = builder.Build();

        return new DbContexto(configuration);
    }
    
    [TestMethod]
    public void TestarSalavandoAdministrador()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        var adm = new Administrador();
        adm.Id = 1;
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";
  
        var administradorService = new AdministradorService(context);

        // Act
        administradorService.Incluir(adm);

        // Assert  
        Assert.AreEqual(1, administradorService.Todos(1).Count());
    }

    [TestMethod]
    public void TestarBuscandoPorId()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        var adm = new Administrador();
        adm.Id = 1;
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";
  
        var administradorService = new AdministradorService(context);

        // Act
        administradorService.Incluir(adm);
        var admBanco = administradorService.BuscaPorId(adm.Id);

        // Assert  
        Assert.AreEqual(1, admBanco.Id);
    }
}

