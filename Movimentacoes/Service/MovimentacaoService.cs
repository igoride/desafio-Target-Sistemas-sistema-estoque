using Movimentacoes.Domain.Entity;
using Movimentacoes.Domain.Enum;

namespace Movimentacoes.Service;

public class MovimentacaoService
{
    private static readonly EstoqueService _estoqueService = new EstoqueService();
    public static void criarMovimentacao(List<Movimentacao> movimentacoes, List<Estoque> estoques)
    {
        int quantidadeEstoque;
        int codigoProduto;
        int codigoMovimentacao = movimentacoes.Count + 1;
        string? tipoMovimentacao;
        string? aux;
        bool adicao = true;
        
        Console.WriteLine("Digite o codigo do Produto: \n");
        aux = Console.ReadLine();
        int.TryParse(aux, out codigoProduto);
        
        Console.WriteLine("Digite a quantidade de estoque: \n");
        aux = Console.ReadLine();
        int.TryParse(aux, out quantidadeEstoque);
        
        Console.WriteLine("Digite o tipo de Movimentacao: (Entrada ou Saida(Não é case sensitive))\n");
        tipoMovimentacao = Console.ReadLine()!.ToUpper();

        if (tipoMovimentacao.Equals("SAIDA"))
        {
            adicao = false;
        } 
        else if (tipoMovimentacao.Equals("ENTRADA"))
        {
            adicao = true;
        }
        
        _estoqueService.ModificaEstoque(estoques, codigoProduto, quantidadeEstoque, adicao);
        
        movimentacoes.Add(new Movimentacao(tipoMovimentacao, quantidadeEstoque, codigoMovimentacao));
    }

    public static void printByCodigo(int codigo, List<Movimentacao> movimentacoes)
    {
        movimentacoes.ForEach(movimentacao =>
        {
            if (movimentacao.codigoMovimentacao.Equals(codigo))
            {
                Console.WriteLine(movimentacao.ToString());
            }
        });
    }

    public static void printAll(List<Movimentacao> movimentacoes)
    {
        movimentacoes.ForEach(movimentacao => Console.WriteLine(movimentacao + "\n----------------\n"));
    }
}