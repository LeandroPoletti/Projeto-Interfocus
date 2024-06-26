using System.ComponentModel.DataAnnotations;
using System.Text;
using ProjetoInterfocus.Services;

namespace ProjetoInterfocus.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "Nome acima da quantidade de caracteres permitidos")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório")]
        private string cpf;
        public string Cpf
        {
            get { return cpf; }
            set
            {
                if (VerificationService.VerificarCpf(value, out List<ValidationResult> erros))
                {
                    cpf = value;
                }
                else
                {
                    Console.WriteLine(erros);
                    throw new ArgumentException("CPF inválido!");
                }
            }
        }

        [Required(ErrorMessage = "Data de Nascimento é obrigatório")]

        private DateTime nascimento;

        public DateTime Nascimento
        {
            get { return nascimento; }

            set
            {
                if (VerificationService.VerificarNascimento(value, out List<ValidationResult> erros) == false)
                {
                    Console.WriteLine(erros);
                    throw new ArgumentException("Data incorreta");
                }
                nascimento = value;
            }
        }
        private string email = null;
        public string? Email { get {return email;} set {
            if(value != null){
                email = value.ToLower();
            }
        } }

        public float TotalEmAberto { get; set; }


        public virtual IList<Divida> DividasDoCliente{ get; set; } = new List<Divida>();
    }
}