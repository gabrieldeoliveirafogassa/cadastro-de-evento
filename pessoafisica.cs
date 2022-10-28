using System;

namespace Pessoas
{
    public class PessoaFisica : Pessoa
    {
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public override void PagarImposto()
        {
            Console.WriteLine("Calculo de 3%");
        }
        public bool ValidarDataNascimento(DateTime dataNascimento)
        {
            var anos = (DateTime.Today - dataNascimento).TotalDays / 365;
            if (anos >= 18)
            {
                return true;
            }
            return false;
        }
    }
}