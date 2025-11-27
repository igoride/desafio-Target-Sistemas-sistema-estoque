namespace Movimentacoes.Domain.Entity;

public class Estoque
{
    public int codigoProduto {get; set;}
    public int estoque {get; set;}
    public string descricaoProduto {get; set;}

    public Estoque(int codigoProduto, int estoque, string descricaoProduto)
    {
        this.codigoProduto = codigoProduto;
        this.estoque = estoque;
        this.descricaoProduto = descricaoProduto;
    }

    public override string ToString()
    {
        return $"Codigo do Produto : {codigoProduto}\n" +
               $"Descrição do Produto : {descricaoProduto}\n" +
               $"Quantidade em estoque : {estoque}";
    }
}