using Calculadora.Services;
using CalculadoraTestes;

namespace CalculadoraTestes;

public class CalculadoraTests
{
    private CalculadoraImp _calc;

    public CalculadoraTests()
    {
        _calc = new CalculadoraImp();
    }

    [Fact] // Atributo que indica que o método é um teste
    public void DeveSomar5com10ERetornar15()
    {
        // Arrange - Preparação
        int num1 = 5;
        int num2 = 10;

        // Act - Ação/Execução // Executar o teste no qual queremos validar.
       int resultado = _calc.Somar(num1, num2);

        // Assert - Verificação/validar // Verificar se o teste passou ou falhou através de asserções.
       Assert.Equal(15, resultado); //Equal é um método da classe Assert que verifica se os dois valores são iguais.
    }

    [Fact] 
    public void DeveSomar10com10ERetornar20()
    {
        int num1 = 10;
        int num2 = 10;

       int resultado = _calc.Somar(num1, num2);

       Assert.Equal(20, resultado); 
    }

    [Fact] 
    public void DeveVerificarSe4EhParERetornarTrue()
    {
        int num = 4;

        bool resultado = _calc.EhPar(num);

        Assert.True(resultado);
    } 

    // E se eu quisesse passar outros numeros para testar se são pares ou não?
    // Para isso, podemos usar a teoria de dados em testes.
    // Vamos ver como fazer isso no próximo tópico.

    [Theory] // Atributo que indica que o método é um teste de teoria. Theory é um teste parametrizado.
    [InlineData(2)] // InlineData é um atributo que indica que o método de teste aceita dados de entrada.
    [InlineData(4)]
    [InlineData(6)]
    [InlineData(8)]
    [InlineData(10)]
    public void DeveVerificarSeOsNumerosSaoParesERetonarTrue(int numero)
    {
        //Arrange não é necessário, pois os dados de entrada são passados como parâmetros.

        //Act
        bool resultado = _calc.EhPar(numero);

        //Assert
        Assert.True(resultado);
    }
    //conjunto de cenarios que vão passar pelo mesmo teste.
    //Ou seja, o método de teste será executado para cada conjunto de dados de entrada.
    //Em um unico teste vamos validar varios cenarios.

    // ---------------------------------------------------------
    //Podemos também Refatorar o código para que fique mais limpo e organizado.
    //Vamos ver como fazer isso no próximo tópico.
    // ---------------------------------------------------------

    [Theory]
    [InlineData(new int[] {2, 4})]
    [InlineData(new int[] {6, 8, 10})]
    public void DeveVerificarSeOsNumerosSaoParesERetonarVerdadeiro(int[] numeros)
    {
        //Act e Assert
        Assert.All(numeros, num => Assert.True(_calc.EhPar(num)));
    }
    // Aqui, estamos passando um array de inteiros como parâmetro para o método de teste.
    // O método de teste será executado para cada conjunto de dados de entrada.
    // O método Assert.All verifica se todos os elementos do array são pares.
    // Se todos os elementos forem pares, o teste passará.
}