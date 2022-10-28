using System;

namespace Pessoas
{
    public class PessoaJuridica : Pessoa
    {

        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public override void PagarImposto()
        {
            Console.WriteLine("Calculo de 5%");
        }
        public bool ValidarCNPJ(string CNPJ)
        {
            if (CNPJ.Length >= 14 && CNPJ.Substring(CNPJ.Length - 4) == "0001")
            {
                return true;
            }
            return false;
        }
    }
}