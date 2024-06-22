using System.ComponentModel.DataAnnotations;
using NHibernate;
using NHibernate.Linq;
using ProjetoInterfocus.Entidades;

namespace ProjetoInterfocus.Services{
    public class DividaService{
        private readonly ISessionFactory session;
        public DividaService(ISessionFactory session){
            this.session = session;
        }

        public static bool Validar(Divida divida, out List<ValidationResult> erros){
            erros = new List<ValidationResult>();
            var valido = Validator.TryValidateObject(divida,
                new ValidationContext(divida),
                erros,
                true
            );
            return valido;
        }

        public bool Registrar(Divida divida, out List<ValidationResult> erros){
            if(Validar(divida, out erros)){
                using var sessao = session.OpenSession();

                Cliente dono = sessao.Get<Cliente>(divida.ClienteDaDivida);
                if(dono == null){
                    erros.Add(new ValidationResult("Cliente não existe"));
                    return false;
                }

                if(dono.LimiteDisponivel < divida.Valor){
                    erros.Add(new ValidationResult("Limite do cliente insuficiente"));
                    return false;
                }

                using var transaction = sessao.BeginTransaction();
                dono.LimiteDisponivel -= divida.Valor;

                sessao.Merge(dono);
                sessao.Save(divida);
                transaction.Commit();
                return true;
            }else{
                return false;
            }
        }

        public bool Editar(Divida divida, out List<ValidationResult> erros){
            if(Validar(divida, out erros)){

                using var sessao = session.OpenSession();
                using var transaction = sessao.BeginTransaction();
                
                Divida registrada = sessao.Get<Divida>(divida.Id);
                Cliente dono = sessao.Get<Cliente>(registrada.ClienteDaDivida);

                if((dono.LimiteDisponivel + registrada.Valor) < divida.Valor){
                    return false;
                }
                
                dono.LimiteDisponivel += registrada.Valor;
                dono.LimiteDisponivel -= divida.Valor;
                
                sessao.Merge(divida);
                sessao.Merge(dono);
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
            var dono = sessao.Get<Cliente>(divida.ClienteDaDivida);
            dono.LimiteDisponivel += divida.Valor;
            sessao.Delete(divida);
            sessao.Merge(dono);
            transaction.Commit();
            return divida;
        }



        //! FIXME arrumar retorno
         public List<Divida> Listar()
        {
            using var sessao = session.OpenSession();
            var dividas = sessao.Query<Divida>()
                .ToList();

            
            
            return dividas;
        }


        public List<Divida> Listar(string busca)
        {
            using var sessao = session.OpenSession();
            var dividas = sessao.Query<Divida>()
                .Where(c => c.Descricao.Contains(busca))
                .OrderBy(c => c.Id)
                .ToList();
                //.Fetch(c => c.DividaCliente)
                //.ThenFetch(c => c.DividasDoCliente)
            return dividas;
                            // c.Email.Contains(busca).Fetch(c => c.DividasDoCliente)
        }

        public Divida GetDivida(int id){
            using var sessao = session.OpenSession();
            Divida divida = sessao.Get<Divida>(id);
            return divida;
        }

    }
}