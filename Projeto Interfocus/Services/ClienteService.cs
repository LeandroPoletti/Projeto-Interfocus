using System.ComponentModel.DataAnnotations;
using Projeto_Interfocus.Entidades;
using NHibernate;

namespace Projeto_Interfocus.Services
{

    public class ClienteService
    {
        private readonly ISessionFactory session;
        public ClienteService(ISessionFactory session)
        {
            this.session = session;
        }

        public static bool Validar(Cliente cliente, out List<ValidationResult> erros){
            erros = new List<ValidationResult>();
            var valido = Validator.TryValidateObject(cliente,
                new ValidationContext(cliente),
                erros,
                true
            );
            return valido;
        }

        public bool Registrar(Cliente cliente, out List<ValidationResult> erros){
            if(Validar(cliente, out erros)){
                using var sessao = session.OpenSession();
                using var transaction = sessao.BeginTransaction();
                sessao.Save(cliente);
                transaction.Commit();
                return true;
            }else{
                return false;
            }
        }

        public bool Editar(Cliente cliente, out List<ValidationResult> erros){
            if(Validar(cliente, out erros)){
                using var sessao = session.OpenSession();
                using var transaction = sessao.BeginTransaction();
                sessao.Merge(cliente);
                transaction.Commit();
                return true;
            }
            return false;
        }

        public Cliente Excluir(int id, out List<ValidationResult> erros)
        {
            erros = new List<ValidationResult>();
            using var sessao = session.OpenSession();
            using var transaction = sessao.BeginTransaction();
            var Aluno = sessao.Query<Cliente>()
                .Where(c => c.Codigo == id)
                .FirstOrDefault();
            if (Aluno == null)
            {
                erros.Add(new ValidationResult("Registro não encontrado",
                    new[] { "id" }));
                return null;
            }

            sessao.Delete(Aluno);
            transaction.Commit();
            return Aluno;
        }

    }


}