using System.ComponentModel;

namespace Movimentacoes.Domain.Enum;

public enum TipoMovimentacao
{ 
        [Description("SAIDA")]
        SAIDA,
        [Description("ENTRADA")]
        ENTRADA,
    
}