using System.ComponentModel.DataAnnotations;
using ProjetoInterfocus.Entidades;
using NHibernate;

namespace ProjetoInterfocus.Services
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
            var cliente = sessao.Query<Cliente>()
                .Where(c => c.Id == id)
                .FirstOrDefault();
            if (cliente == null)
            {
                erros.Add(new ValidationResult("Registro não encontrado",
                    new[] { "id" }));
                return null;
            }

            sessao.Delete(cliente);
            transaction.Commit();
            return cliente;
        }

         public List<Cliente> Listar()
        {
            using var sessao = session.OpenSession();
            var clientes = sessao.Query<Cliente>().ToList();
            return clientes;
        }


        public List<Cliente> Listar(string busca)
        {
            using var sessao = session.OpenSession();
            var Clientes = sessao.Query<Cliente>()
                .Where(c => c.Nome.Contains(busca) ||
                            c.Email.Contains(busca))
                .OrderBy(c => c.Id)
                .ToList();
            return Clientes;
        }

        public Cliente GetCliente(int id){
            using var sessao = session.OpenSession();
            Cliente cliente = sessao.Get<Cliente>(id);
            return cliente;
        }

    }


}