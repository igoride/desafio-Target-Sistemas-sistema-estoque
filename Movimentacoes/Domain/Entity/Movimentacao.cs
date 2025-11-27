using Movimentacoes.Domain.Enum;

namespace Movimentacoes.Domain.Entity;

public class Movimentacao
{
    public Movimentacao(string tipoMovimentacao, int quantidadeEstoque, int codigoMovimentacao)
    {
        this.quantidadeEstoque = quantidadeEstoque;
        this.codigoMovimentacao = codigoMovimentacao;
        if (tipoMovimentacao == "SAIDA")
        {
            this.tipoMovimentacao = TipoMovimentacao.SAIDA;
        }
        else
        {
            this.tipoMovimentacao = TipoMovimentacao.ENTRADA;
        }
    }

    public int codigoMovimentacao {get; set;}
    public int quantidadeEstoque {get; set;}
    public TipoMovimentacao tipoMovimentacao {get; set;}
    
    public override string ToString()
    {
        return $"Codigo Movimentacao: {codigoMovimentacao}\n" +
               $"Tipo Movimentação: {tipoMovimentacao}\n" +
               $"Quantidade estoque: {quantidadeEstoque}";
    }
}