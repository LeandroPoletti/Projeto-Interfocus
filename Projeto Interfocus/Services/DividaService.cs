using System.ComponentModel.DataAnnotations;
using NHibernate;
using NHibernate.Linq;
using ProjetoInterfocus.Entidades;

namespace ProjetoInterfocus.Services
{
    public class DividaService
    {
        private readonly ISessionFactory session;



        public DividaService(ISessionFactory session)
        {
            this.session = session;
        }

        public static bool Validar(Divida divida, out List<ValidationResult> erros)
        {
            erros = new List<ValidationResult>();
            var valido = Validator.TryValidateObject(divida,
                new ValidationContext(divida),
                erros,
                true
            );
            return valido;
        }

        public bool Registrar(Divida divida, out List<ValidationResult> erros)
        {
            if (Validar(divida, out erros))
            {
                using var sessao = session.OpenSession();

                Cliente dono = sessao.Get<Cliente>(divida.ClienteDaDivida.Id);
                if (dono == null)
                {
                    erros.Add(new ValidationResult("Cliente não existe"));
                    return false;
                }

                if (divida.Situacao == false)
                {
                    var total = GeneralService.SomarDividas(dono);
                    total += divida.Valor;

                    if (total > 200)
                    {
                        erros.Add(new ValidationResult("Valor ultrapassa limite de 200 reais de divida por cliente"));
                        return false;
                    }
                }

                using var transaction = sessao.BeginTransaction();
                // sessao.Merge(dono);
                sessao.Save(divida);
                transaction.Commit();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Editar(Divida divida, out List<ValidationResult> erros)
        {
            if (Validar(divida, out erros))
            {

                using var sessao = session.OpenSession();
                using var transaction = sessao.BeginTransaction();

                Divida registrada = sessao.Get<Divida>(divida.Id);
                Cliente dono = sessao.Get<Cliente>(registrada.ClienteDaDivida.Id);

                if (divida.Situacao == false)
                {
                    var total = GeneralService.SomarDividas(dono);
                    total = registrada.Situacao ? total : total - registrada.Valor;

                    if (total > 200 || (total+divida.Valor > 200))
                    {
                        return false;
                    }
                }

                sessao.Merge(divida);
                // sessao.Merge(dono);
                transaction.Commit();
                return true;
            }
            return false;
        }

        public Divida Excluir(int id, out List<ValidationResult> erros)
        {
            erros = new List<ValidationResult>();
            using var sessao = session.OpenSession();
            using var transaction = sessao.BeginTransaction();
            var divida = sessao.Query<Divida>()
                .Where(c => c.Id == id)
                .FirstOrDefault();

            if (divida == null)
            {
                erros.Add(new ValidationResult("Registro não encontrado",
                    new[] { "id" }));
                return null;
            }
            var dono = sessao.Get<Cliente>(divida.ClienteDaDivida.Id);
            dono.DividasDoCliente.Remove(divida);
            // var dono = sessao.Get<Cliente>(divida.ClienteDaDivida);
            // dono.LimiteDisponivel += divida.Valor;
            sessao.Delete(divida);
            sessao.Merge(dono);
            transaction.Commit();
            return divida;
        }



        public List<Divida> Listar(int pagina)
        {
            using var sessao = session.OpenSession();
            var dividas = sessao.Query<Divida>()
                .OrderBy(c => c.Id)
                .Skip((pagina - 1) * 10)
                .Take(10)
                .ToList();

            foreach (var divida in dividas)
            {
                divida.ClienteDaDivida.DividasDoCliente = null;
            }

            return dividas;
        }


        public List<Divida> Listar(int pagina,string busca)
        {
            using var sessao = session.OpenSession();
            var dividas = sessao.Query<Divida>()
                .Where(c => c.Descricao.Contains(busca))
                .OrderBy(c => c.Id)
                .Skip((pagina - 1) * 10)
                .Take(10)
                .ToList();

            foreach (var divida in dividas)
            {
                divida.ClienteDaDivida.DividasDoCliente = null;
            }

            return dividas;
        }

        public Divida GetDivida(int id)
        {
            using var sessao = session.OpenSession();
            Divida divida = sessao.Get<Divida>(id);

            divida.ClienteDaDivida.DividasDoCliente = null!;
            return divida;
        }

    }
}