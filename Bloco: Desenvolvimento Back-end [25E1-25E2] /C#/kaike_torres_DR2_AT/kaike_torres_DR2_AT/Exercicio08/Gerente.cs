class Gerente : Funcionario
{
    public Gerente(string nome, double salarioBase)
        : base(nome, "Gerente", salarioBase) { }

    public override double CalcularSalario()
    {
        return SalarioBase * 1.2; // Bônus de 20%
    }
}