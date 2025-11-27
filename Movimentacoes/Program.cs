using System.Text.Json;
using Movimentacoes.Domain;
using Movimentacoes.Domain.Entity;
using Movimentacoes.Service;

namespace  Movimentacoes
{
  class Program
  {
    private static readonly MovimentacaoService _movimentacaoService = new MovimentacaoService();
    
    static void Main(string[] args)
    {
      Boolean finish = false;
      string? operacao;
      string? aux;
      string json;
      List<Movimentacao> movimentacoes = new List<Movimentacao>();

      try
      {
        string path = Path.Combine(AppContext.BaseDirectory, @"Assets", "EstoqueJson.txt");
        json = File.ReadAllText(path);
      }
      catch (Exception e)
      {
        Console.WriteLine("Erro: " + e.Message);
        throw;
      }
      
      var rootEstoque = JsonSerializer.Deserialize<RootEstoque>(json);
      Console.WriteLine(rootEstoque.estoque.Count);
      while (!finish)
      {
        Console.WriteLine("----- Estoque ------\n" +
                          "1 - Listar todo o estoque\n" +
                          "2 - Buscar produto por código\n" +
                          "3 - Criar movimentação\n" +
                          "4 - Buscar movimentação por codigo\n" +
                          "5 - Listar movimentações\n" +
                          "6 - Sair");
        operacao = Console.ReadLine();
        switch (operacao)
        {
          case "1":
            rootEstoque.estoque.ForEach(estoque =>
            {
              Console.WriteLine(estoque.ToString() +
                                "\n------------------------\n");
            });
            break;
          case "2":
            aux = Console.ReadLine();
            int codigoProduto;
            int.TryParse(aux, out codigoProduto);
            
            rootEstoque.estoque.ForEach(estoque =>
            {
              if (estoque.codigoProduto == codigoProduto)
              {
                Console.WriteLine(estoque.ToString());
              }  
            });
            break;
          case "3":
            _movimentacaoService.criarMovimentacao(movimentacoes, rootEstoque.estoque);
            break;
          case "4":
            Console.WriteLine("Digite o codigo da movimentacao:");
            aux = Console.ReadLine();
            int codigoMovimentacao;
            int.TryParse(aux, out codigoMovimentacao);
            
            _movimentacaoService.printByCodigo(codigoMovimentacao,  movimentacoes);
            break;
          case "5":
            _movimentacaoService.printAll(movimentacoes);
            break;
          default:
            finish = false; 
            break;
        }
      }
      
    }
  }
}