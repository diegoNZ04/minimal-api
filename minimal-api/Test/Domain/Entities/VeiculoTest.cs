using MinimalApi.Domain.Entities;

namespace Test.Domain.Entities;

[TestClass]
public class VeiculoTest
{
    [TestMethod]
    public void TestarGetSetPropries()
    {
        // Arrange
        var veiculo = new Veiculo();

        // Act
        veiculo.Id = 1;
        veiculo.Modelo = "teste";
        veiculo.Marca = "teste";
        veiculo.Ano = 1;

         // Assert 
         Assert.AreEqual(1, veiculo.Id);
         Assert.AreEqual("teste", veiculo.Modelo);
         Assert.AreEqual("teste", veiculo.Marca);
         Assert.AreEqual(1, veiculo.Ano);
    }
}