using System;
using System.IO;

namespace Pessoas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Deseja informar seus dados, sim(sim) ou não(nâo)");
            string decision = Console.ReadLine();
            while ("sim" == decision)
            {
                Console.WriteLine("Inserir dados de pessoa fisica(f) ou juridica(j)?");
                string pessoa = Console.ReadLine();

                if (pessoa == "f")
                {
                    PessoaFisica pf = new PessoaFisica();
                    Endereco endereco = new Endereco();

                    Console.Write("nome da rua: ");
                     endereco.Rua = Console.ReadLine();
                     Console.Write("número da residênsia: ");
                     endereco.Numero = Console.ReadLine();
                     Console.Write("seu endereço : ");
                     endereco.TipoEndereco = Console.ReadLine();

                    Console.Write("Informe os nove primeiro digitos do seu cpf : ");
                    pf.CPF = Console.ReadLine();
                    

                    int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                    int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                    string digito = "00";
                    int soma;
                    int resto;
                    pf.CPF = pf.CPF.Trim();
                    pf.CPF = pf.CPF.Replace(".", "").Replace("-", "");
                    if (pf.CPF.Length != 9)
                    {
                        Console.WriteLine("CPF INVALIDO!!!\n\nDeseja tentar novamente, sim(sim) ou não(não)?");
                        decision = Console.ReadLine();

                    }
                    pf.CPF = pf.CPF.Substring(0, 9);
                    soma = 0;

                    for (int i = 0; i < 9; i++)
                        soma += int.Parse(pf.CPF[i].ToString()) * multiplicador1[i];
                    resto = soma % 11;
                    if (resto < 2)
                    {
                        resto = 0;
                    }
                    else
                    {
                        resto = 11 - resto;
                        digito = resto.ToString();
                        pf.CPF = pf.CPF + digito;
                        soma = 0;
                    }
                    for (int i = 0; i < 10; i++)
                        soma += int.Parse(pf.CPF[i].ToString()) * multiplicador2[i];
                    resto = soma % 11;
                    if (resto < 2)
                    {
                        resto = 0;
                    }
                    else
                    {
                        resto = 11 - resto;

                        digito = digito + resto.ToString();
                    }
                    Console.Write("Informe seu nome: ");
                    pf.Nome = Console.ReadLine();
                    pf.Endereco = endereco;
                    pf.DataNascimento = new DateTime(2001, 03, 19);
                    Console.WriteLine("Seu nome é: {0}\nSua data de nascimento é: {1} ", pf.Nome, pf.DataNascimento);
                    using (StreamWriter sw = new StreamWriter($"Banco_de_Dados.txt"))
                    {
                        sw.Write(endereco.Rua+"\n"+endereco.Numero+"\n"+endereco.TipoEndereco+"\n"+pf.CPF+"\n"+pf.Nome+"\n"+pf.DataNascimento );
                        decision = "";
                    }
                }

                else if (pessoa == "j")
                {
                    PessoaJuridica pj = new PessoaJuridica();
                    Endereco endereco = new Endereco();
                    endereco.Rua = "Rua X";
                    endereco.Numero = "10";
                    endereco.TipoEndereco = "Comercial";
                    // pj.CNPJ = "12345678901234"; // cnpj invalido
                    pj.CNPJ = "12345678900001"; // cnpj valido
                    pj.Nome = "Clasmisson";
                    pj.Endereco = endereco;
                    Console.WriteLine(pj.Nome);
                    Console.WriteLine(pj.CNPJ);
                    //using (StreamWriter sw = new StreamWriter($"{pj.Nome}.txt"))
                    {
                        // sw.Write(pj.Nome);
                        decision = "";
                    }
                }
                else
                {
                    Console.WriteLine("\n!!!ERROR!!\nDesculpe, não pude indetificar o usuário.\n\nDeseja tentar novamente, sim(s) ou não(n)?");
                    decision = Console.ReadLine();
                }
            }
        }
    }
}
