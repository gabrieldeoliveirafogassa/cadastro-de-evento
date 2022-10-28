namespace Pessoas
{
    public abstract class Pessoa
    {
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public abstract void PagarImposto();
    }
}