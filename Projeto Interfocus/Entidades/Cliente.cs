using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projeto_Interfocus.Entidades
{
    public class Cliente
    {
        public Cliente(string nome, string cpf, DateOnly nascimento, string? email)
        {
            this.nome = nome;


            if (email != null)
            {
                this.email = email;
            }
        }

        private bool verificarCpf(string cpf, out List<ValidationResult> erros)
        {
            erros = new List<ValidationResult>();
            if (cpf.Length == 11)
            {
                StringBuilder sb = new StringBuilder();
                string primeiroDigito = calcularPrimeiroDigito(cpf, out erros);
                if (erros.Count > 0)
                {
                    return false;
                }
                sb.Append(primeiroDigito);
                //segundo digito
                string segundoDigito;
                //alguma logica
                string verificador = sb.ToString();

            }
            else
            {
                erros.Add(new ValidationResult($"Tamnho esperado era 11 digitos porem foi inserido {cpf.Length} digitos"));
                return false;
            }
        }

        private string? calcularPrimeiroDigito(string cpf, out List<ValidationResult> erros)
        {
            erros = new List<ValidationResult>();
            int total = 0;
            int pos = 0;
            for (int multiplicador = 10; multiplicador >= 2; multiplicador--)
            {
                string digito = cpf[pos].ToString();
                int valor;
                if (int.TryParse(digito, out valor) == false)
                {
                    erros.Add(new ValidationResult($"Não é possivel realizar a conversão de {digito} para inteiro"));
                    return null;
                }
                total += valor * multiplicador;
                pos++;
            }
            int primeiroDigito = total % 11;
            if (primeiroDigito < 2)
            {
                primeiroDigito = 0;
            }
            else
            {
                primeiroDigito = 11 - primeiroDigito;

            }
            return primeiroDigito.ToString();
        }

        public string nome { get; set; }
        public string cpf { get; set; }
        public string? email { get; set; }
        public DateOnly nascimento { get; set; }

    }
}
