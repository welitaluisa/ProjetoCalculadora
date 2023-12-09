// 1 - bibliotecas
using NUnit.Framework;
using Calc; // namespace da calculadora 

// 2 - namespace
namespace Calculadora139.Tests;

// 3 - classe
[TestFixture] // Marcação que a classe trabalha com teste parametrizados
public class Tests
{
    // 3.1 - Atributos

    // 3.2 - Funções e Métodos

   // Função de Leitura de Dados a partir de um arquivo csv
    public static IEnumerable<TestCaseData> lerDadosDeTeste(String operacao)
    {
        String caminhoMassa = @"C:\Iterasys\ProjetoCalculadora\Calculadora139.test\fixtures\"; // caminho do arquivo csv
        switch(operacao)
        {
        case "+":
        caminhoMassa += @"massaSomar.csv";
        break;
        case "-":
        caminhoMassa += @"massaSubtrair.csv";
        break;
        case "*":
        caminhoMassa += @"massaMultiplicar.csv";
        break;
        case "/":
        caminhoMassa += @"massaDividir.csv";
        break;        
    }
    using(var leitor = new StreamReader(caminhoMassa))
    {
        // pular a primeira linha - cabeçalho
        leitor.ReadLine();
        // repetir as ações até a condição se realizar
        // no caso, seria até o arquivo CSV terminar
        // Repetir enquanto Não(!) for o final 
        while(!leitor.EndOfStream)
        {
            var linha = leitor.ReadLine(); // lendo uma linha
            var valores = linha.Split(","); // dividir em campos

            yield return new TestCaseData(int.Parse(valores[0]),int.Parse(valores[1]), int.Parse(valores[2]));
        }
    }
    }

    [Test] // Método de Teste
    public void testSomarDoisNumeros()
    {
        // Triple A = AAA

        // Configura
        // Dados de entrada
        int num1 = 15;
        int num2 = 35;
        // Resultado esperado / Saida
        int resultadoEsperado = 50;

        // Executa
        int resultadoAtual = Calculadora.somarDoisNumeros(num1, num2);

        // Valida
        Assert.That(resultadoEsperado, Is.EqualTo(resultadoAtual));
    } // Fecha o teste da soma

    [Test]

    public void testSubtrairDoisNumeros()
    {
        // Triple A = AAA

        // Configura
        // Dados de entrada
        int num1 = 20;
        int num2 = 8;
        // Resultado esperado / Saida
        int resultadoEsperado = 12;

        // Executa
        int resultadoAtual = Calculadora.subtrairDoisNumeros(num1,num2);

        // Valida
        Assert.That(resultadoEsperado, Is.EqualTo(resultadoAtual));
    }

    [Test]

    public void testMultiplicarDoisNumeros()
    {
        // Triple A = AAA

        // Configura
        // Dados de entrada
        int num1 = 5;
        int num2 = 3;
        // Resultado esperado / Saida
        int resultadoEsperado = 15;

        // Executa
        int resultadoAtual = Calculadora.multiplicarDoisNumeros(num1,num2);

        // Valida
        Assert.That(resultadoEsperado, Is.EqualTo(resultadoAtual));
    }

    [Test]

    public void testDividirDoisNumeros()
    {
        // Triple A = AAA

        // Configura
        // Dados de entrada
        int num1 = 9;
        int num2 = 3;
        // Resultado esperado / Saida
        int resultadoEsperado = 3;

        // Executa
        int resultadoAtual = Calculadora.dividirDoisNumeros(num1,num2);

        // Valida
        Assert.That(resultadoEsperado, Is.EqualTo(resultadoAtual));
    }

    [Test]

    public void testDividirPorZero()
    {
        // Triple A = AAA

        // Configura
        // Dados de entrada
        int num1 = 7;
        int num2 = 0;
        // Resultado esperado / Saida
        int resultadoEsperado = 0; // O tratamento de erro retornará 0 

        // Executa
        int resultadoAtual = Calculadora.dividirDoisNumeros(num1,num2);

        // Valida
        Assert.That(resultadoEsperado, Is.EqualTo(resultadoAtual));
    }
    // Configura 
    [TestCase(-2,-5,-7)]
    [TestCase(5,8,13)]
    [TestCase(3,3,6)]

    public void testSomarDoisNumerosUsandoTestCase(int num1, int num2, int resultadoEsperado) // Teste case
    {
        // Executa 
        int resultadoAtual = Calculadora.somarDoisNumeros(num1, num2);
        
        // Valida 
        Assert.That(resultadoAtual, Is.EqualTo(resultadoEsperado));
    }
      // Configura 
    [TestCase(5,8,13)]
    [TestCase(0,8,8)]
    [TestCase(5,-1,4)]
    public void testSomarDoisNumerosUsandoTestCase2(int num1, int num2, int resultadoEsperado) // Teste case
    {        
        // Valida // Executa
        Assert.That(Calculadora.somarDoisNumeros(num1, num2), Is.EqualTo(resultadoEsperado));
    }
    // Test Data Driven
    // Configura 
    [Test, TestCaseSource("lerDadosDeTeste", new object[] {"+"})]
    
    public void testSomarDoisNumerosUsandoDataDriven(int num1, int num2, int resultadoEsperado) // Teste case
    {
        // Executa 
        int resultadoAtual = Calculadora.somarDoisNumeros(num1, num2);
        
        // Valida 
        Assert.That(resultadoAtual, Is.EqualTo(resultadoEsperado));
    }

    [Test, TestCaseSource("lerDadosDeTeste", new object[] {"-"})]
    
    public void testSubtrairDoisNumerosUsandoDataDriven(int num1, int num2, int resultadoEsperado) // Teste case
    {
        // Executa 
        int resultadoAtual = Calculadora.subtrairDoisNumeros(num1, num2);
        
        // Valida 
        Assert.That(resultadoAtual, Is.EqualTo(resultadoEsperado));
    }
    
    [Test, TestCaseSource("lerDadosDeTeste", new object[] {"*"})]
    
    public void testMultiplicarDoisNumerosUsandoDataDriven(int num1, int num2, int resultadoEsperado) // Teste case
    {
        // Executa 
        int resultadoAtual = Calculadora.multiplicarDoisNumeros(num1, num2);
        
        // Valida 
        Assert.That(resultadoAtual, Is.EqualTo(resultadoEsperado));
    }

    [Test, TestCaseSource("lerDadosDeTeste", new object[] {"/"})]
    
    public void testDividirDoisNumerosUsandoDataDriven(int num1, int num2, int resultadoEsperado) // Teste case
    {
        // Executa 
        int resultadoAtual = Calculadora.dividirDoisNumeros(num1, num2);
        
        // Valida 
        Assert.That(resultadoAtual, Is.EqualTo(resultadoEsperado));
    }
        
}