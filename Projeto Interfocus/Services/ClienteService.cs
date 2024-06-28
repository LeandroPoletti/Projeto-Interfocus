using System.ComponentModel.DataAnnotations;
using ProjetoInterfocus.Entidades;
using NHibernate;
using NHibernate.Linq;

namespace ProjetoInterfocus.Services
{

    public class ClienteService
    {
        private readonly ISessionFactory session;
        public ClienteService(ISessionFactory session)
        {
            this.session = session;
        }

        public static bool Validar(Cliente cliente, out List<ValidationResult> erros)
        {
            erros = new List<ValidationResult>();
            var valido = Validator.TryValidateObject(cliente,
                new ValidationContext(cliente),
                erros,
                true
            );

            return valido;
        }

        public bool Registrar(Cliente cliente, out List<ValidationResult> erros)
        {
            if (Validar(cliente, out erros))
            {
                using var sessao = session.OpenSession();
                using var transaction = sessao.BeginTransaction();
                cliente.DividasDoCliente = null;
                sessao.Save(cliente);
                transaction.Commit();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Editar(Cliente cliente, out List<ValidationResult> erros)
        {
            if (Validar(cliente, out erros))
            {
                using var sessao = session.OpenSession();
                using var transaction = sessao.BeginTransaction();
                var registrado = sessao.Get<Cliente>(cliente.Id);

                //! Implementaçao

                cliente.DividasDoCliente = registrado.DividasDoCliente;

                // foreach (var divida in cliente.DividasDoCliente)
                // {
                //     divida.ClienteDaDivida = cliente;
                // }


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

        //TODO Paginamento, skip e take

        public List<Cliente> Listar(int page)
        {
            using var sessao = session.OpenSession();
            var clientes = sessao.Query<Cliente>()
            .ToList();

            clientes = clientes.OrderByDescending(c => GeneralService.SomarDividas(c)).ToList();
            clientes.ForEach(cliente =>
            {
                cliente.DividasDoCliente = cliente.DividasDoCliente.OrderByDescending(d => d.Valor)
                .OrderByDescending(d => d.Situacao == false)
                .ToList();
            });
            if (page == -1)
            {
                return clientes;
            }

            clientes = clientes.Skip((page - 1) * 10)
            .Take(10)
            .ToList();

            return clientes;
        }


        public List<Cliente> Listar(string busca, int page)
        {
            using var sessao = session.OpenSession();
            var clientes = sessao.Query<Cliente>()
                .Where(c => c.Nome.Contains(busca) ||
                            c.Email.Contains(busca)
                        )
                .OrderBy(c => c.Id)
                .ToList();

            clientes = clientes.OrderByDescending(c => GeneralService.SomarDividas(c))
            .Skip((page - 1) * 10)
            .Take(10)
            .ToList();

            return clientes;
        }

        public Cliente GetCliente(int id)
        {
            using var sessao = session.OpenSession();
            Cliente cliente = sessao.Query<Cliente>()
            .Where(c => c.Id == id)
            .FirstOrDefault();
            return cliente;
        }

    }


}