using System.ComponentModel.DataAnnotations;

public enum StatusOrdemServico
{
    [Display(Name = "Na fila para conserto")]
    NaFilaParaConserto,

    [Display(Name = "Em análise")]
    EmAnalise,

    [Display(Name = "Esperando confirmação de orçamento")]
    EsperandoConfirmacaoOrcamento,

    [Display(Name = "Aguardando peça")]
    AguardandoPeca,

    [Display(Name = "Em conserto")]
    EmConserto,

    [Display(Name = "Aguardando cliente retirar")]
    AguardandoClienteRetirar,

    [Display(Name = "Finalizado")]
    Finalizado
}