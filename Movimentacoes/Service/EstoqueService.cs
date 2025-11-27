using Movimentacoes.Domain.Entity;

namespace Movimentacoes.Service;


public class EstoqueService
{
    public void ModificaEstoque(List<Estoque> estoques, int codigoProduto, int quantidade, bool adicao) 
    {
        estoques.ForEach(estoque =>
        {
            if (estoque.codigoProduto.Equals(codigoProduto))
            {
                if (adicao)
                {
                    estoque.estoque = estoque.estoque + quantidade;
                }
                else
                {
                    estoque.estoque = estoque.estoque - quantidade;
                }
            }
        });
    }
}