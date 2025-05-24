namespace Exercicio05;

public class CalculadorTempoRestante
{
    
    public DateTime DataAtual { get; set; }
    public DateTime DataFormatura { get; set; }

    public string CalcularTempoRestante()
    {
        if (DataAtual > DateTime.Now)
        {
            return "Erro: A data informada não pode ser no futuro!";
        }

        if (DataFormatura < DateTime.Now)
        {
            return "Parabéns! Você já deveria estar formado!";
        }

        var anosRestantes = DataFormatura.Year - DataAtual.Year;
        var mesesRestantes = DataFormatura.Month - DataAtual.Month;
        var diasRestantes = DataFormatura.Day - DataAtual.Day;

        if (diasRestantes < 0)
        {
            mesesRestantes--;
            diasRestantes += DateTime.DaysInMonth(DataAtual.Year, DataAtual.Month);
        }

        if (mesesRestantes < 0)
        {
            anosRestantes--;
            mesesRestantes += 12;
        }

        var resultado = $"Faltam {anosRestantes} anos, {mesesRestantes} meses e {diasRestantes} dias para sua formatura!";

        if (anosRestantes == 0 && mesesRestantes < 6)
        {
            resultado += "\nA reta final chegou! Prepare-se para a formatura!";
        }

        return resultado;
    }
}
